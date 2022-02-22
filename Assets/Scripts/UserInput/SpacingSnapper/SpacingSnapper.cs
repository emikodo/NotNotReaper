using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotReaper.UserInput;
using NotReaper;
using NotReaper.Timing;
using NotReaper.Targets;
using NotReaper.Models;
using NotReaper.Grid;
using NotReaper.UI;
using System;
using System.Linq;
using UnityEngine.InputSystem;
namespace NotReaper.Tools.SpacingSnap
{
    public class SpacingSnapper : NRInput<SpacingSnapKeybinds>
    {

        [SerializeField] private HoverTarget hover;
        [SerializeField] private GameObject orbit;


        private Target nearestTarget;
        private Camera cam;
        private TrailRenderer trail;


        private float radius = 1f;
        private float radiusIncrement = .1f;

        private float msBetweenTargets;

        private bool prepared = false;

        private bool lockDirectional;

        private List<Vector2> directionals = new List<Vector2> { Vector2.up, Vector2.right, Vector2.down, Vector2.left };

        protected override void Awake()
        {
            base.Awake();
            cam = Camera.main;
            orbit.SetActive(false);
            trail = orbit.GetComponent<TrailRenderer>();
            directionals.Add(new Vector2(.7f, .7f));
            directionals.Add(new Vector2(.7f, -.7f));
            directionals.Add(new Vector2(-.7f, .7f));
            directionals.Add(new Vector2(-.7f, -.7f));
        }

        void Update()
        {
            if (prepared)
            {
                if(nearestTarget != null)
                {
                    LockSpacing();
                }
            }
        }

        public void EnableSpacingSnap()
        {
            EditorState.SelectSnappingMode(SnappingMode.None);
            //uiInput.SelectSnappingMode(SnappingMode.None);
            OnActivated();
            Prepare();
        }

        public void DisableSpacingSnap()
        {
            EditorState.SelectSnappingMode(EditorState.Snapping.Previous);
            //uiInput.SelectSnappingMode(EditorState.Snapping.Previous);
            Reset();
            OnDeactivated();
        }

        private void LockSpacing()
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(actions.SpacingSnap.MousePosition.ReadValue<Vector2>());
            Vector2 targetPos = nearestTarget.gridTargetIcon.transform.position;
            var direction = (mousePos - targetPos).normalized;
            if (lockDirectional) direction = GetClosestDirectional(direction);
            var cursorPos = direction * radius;
            var newCursorPos = targetPos + cursorPos;
            hover.transform.position = newCursorPos;
            orbit.transform.position = hover.transform.position;
        }

        private Vector2 GetClosestDirectional(Vector2 direction)
        {
            return directionals.Aggregate((x, y) => Vector2.Distance(x, direction) < Vector2.Distance(y, direction) ? x : y);
        }

        private void HandleScrolling(bool increase)
        {
            if ((KeybindManager.Global.Modifier & KeybindManager.Global.Modifiers.Ctrl) == KeybindManager.Global.Modifiers.Ctrl) return;
            ChangeRadius(increase ? -radiusIncrement : radiusIncrement);
        }

        private void Prepare()
        {
            if (Timeline.time.tick == 0) return;
            var targets = new NoteEnumerator(new QNT_Timestamp(0), new QNT_Timestamp(Timeline.time.tick - 1));
            targets.reverse = true;
            nearestTarget = FindNearestTargetPosition(targets);
            trail.startColor = EditorState.Hand.Current == TargetHandType.Left ? NRSettings.config.leftColor : NRSettings.config.rightColor;
            trail.endColor = EditorState.Hand.Current == TargetHandType.Right ? NRSettings.config.leftColor : NRSettings.config.rightColor;
            if (nearestTarget != null)
            {
                nearestTarget.Select();
                IsHoveringGrid.Instance.ChangeColliderSize(true);
                radius = 0f;
                orbit.SetActive(true);
                ChangeRadius(FindSuggestedDistance());
            }
            if(nearestTarget is null)
            {
                return;
            }
            hover.LockSpacing(true);
            prepared = true;
        }

        private void Reset()
        {
            IsHoveringGrid.Instance.ChangeColliderSize(false);
            if (nearestTarget != null) nearestTarget.Deselect();
            nearestTarget = null;
            hover.LockSpacing(false);
            hover.UpdateDistance("");
            orbit.SetActive(false);
            prepared = false;
        }

        private void ChangeRadius(float amount)
        {
            radius += amount;
            radius = Mathf.Clamp(radius, .1f, 5f);
            radius = (float)Math.Round(radius, 1);
            hover.UpdateDistance(radius.ToString());
        }

        private float FindSuggestedDistance()
        {
            var bpm = Timeline.instance.GetTempoForTime(Timeline.time);
            float beatsBetweenTargets = new QNT_Timestamp(Timeline.time.tick - nearestTarget.data.time.tick).ToBeatTime();
            msBetweenTargets = (bpm.microsecondsPerQuarterNote / 1000) * beatsBetweenTargets;
            msBetweenTargets = Mathf.Floor(msBetweenTargets);
            return .5f + (float)Math.Round(msBetweenTargets / 750f * Mathf.Clamp(msBetweenTargets / 100f, 1f, 3f), 1);
        }

        private Target FindNearestTargetPosition(NoteEnumerator targets)
        {
            foreach (var target in targets)
            {
                TargetBehavior behavior = target.data.behavior;
                if (behavior == TargetBehavior.Mine || behavior == TargetBehavior.Melee) continue;

                return target;
            }
            return null;
        }

        protected override void RegisterCallbacks()
        {
            actions.SpacingSnap.ChangeDistance.performed += ctx => HandleScrolling(ctx.ReadValue<float>() < 0);
            actions.SpacingSnap.LockDirectional.performed += _ => lockDirectional = true;
            actions.SpacingSnap.LockDirectional.canceled += _ => lockDirectional = false;
            actions.SpacingSnap.Tab.performed += _ => DisableSpacingSnap();
        }

        protected override void OnEscPressed(InputAction.CallbackContext context) { }

        protected override void SetRebindConfiguration(ref RebindConfiguration options, SpacingSnapKeybinds myKeybinds)
        {
            options.SetAssetTitle("Spacing Snapper").SetPriority(20);
            options.AddHiddenKeybinds(myKeybinds.SpacingSnap.MousePosition, myKeybinds.SpacingSnap.Tab);
            options.AddNonRebindableKeybinds(myKeybinds.SpacingSnap.ChangeDistance);
            options.AddNonRebindableKeybinds(myKeybinds.SpacingSnap.LockDirectional);
        }
    }

}
