﻿using System;
using System.Collections;
using System.Collections.Generic;
using NotReaper.Models;
using UnityEngine;
using UnityEngine.UI;
using NotReaper.Timing;
using NotReaper.Tools.ChainBuilder;
using System.Linq;
using NotReaper.Notifications;

namespace NotReaper.Targets {

	public enum TargetIconLocation {
		Timeline,
		Grid
	}

    public class TargetIcon : MonoBehaviour {

        [Header("Main sprites")]
        public Sprite standard;
        public Sprite hold;
        public Sprite horizontal;
        public Sprite vertical;
        public Sprite chainStart;
        public Sprite chain;
        public Sprite melee;
        public Sprite mine;
        public Sprite pathbuilder;
        public Sprite none;

        [Header("Ring sprites")]
        public Sprite standardRing;
        public Sprite holdRing;
        public Sprite horizontalRing;
        public Sprite verticalRing;
        public Sprite chainStartRing;
        public Sprite chainRing;
        public Sprite meleeRing;
        public Sprite mineRing;
        public Sprite noneRing;

        [Header("Telegraph sprites")]
        public Sprite standardTelegraph;
        public Sprite holdTelegraph;
        public Sprite horizontalTelegraph;
        public Sprite verticalTelegraph;
        public Sprite chainStartTelegraph;
        public Sprite chainTelegraph;
        public Sprite meleeTelegraph;
        public Sprite mineTelegraph;
        public Sprite noneTelegraph;

        [Header("Select ring sprites")]
        public Sprite standardSelect;
        public Sprite holdSelect;
        public Sprite horizontalSelect;
        public Sprite verticalSelect;
        public Sprite chainStartSelect;
        public Sprite chainSelect;
        public Sprite meleeSelect;
        public Sprite mineSelect;
        public Sprite noneSelect;

        public GameObject beatLengthLine;
        public GameObject pathBuilder;

        [Header("Other")]

        [SerializeField] SpriteRenderer prefade;
        [SerializeField] SpriteRenderer ring;
        [SerializeField] SpriteRenderer note;


        [Header("New Pathbuilder")]
        [SerializeField] private LineRenderer activeSegmentIndicator;

        public SpriteRenderer selection;

        [SerializeField] float timelineSpread = 1.5f;

        public float targetSize = 1f;
        public float timelineTargetSize = 1f;


        public TargetData data;
        public Target target;

        public float sustainDirection = 0.6f;

        [SerializeField] private float collisionRadiusClick = 0.95f;
        [SerializeField] private float collisionRadiusDrag = 0.95f;
        public bool isSelected = false;
        public TargetIconLocation location;

        public ParticleSystem holdParticles;

        public GameObject sustainButtons;

        public Transform holdEndTrans;
        [Header("Optimization")]
        [Space, SerializeField] private Transform childComponents;
        [SerializeField] private Camera timelineCamera;
        private Transform timelineTargetCollector;

        public bool SustainButtonsActive => sustainButtons.activeSelf;

        /// <summary>
        /// For when the note is right clicked on.
        /// </summary>
        public event Action OnTryRemoveEvent;

        public void OnTryRemove() {
            if(!target.transient) {
                OnTryRemoveEvent();
            }
        }

        public void Remove() {
            Destroy(gameObject);
        }

        public event Action IconEnterLoadedNotesEvent;
        public event Action IconExitLoadedNotesEvent;

        public void IconEnterLoadedNotes() {
            IconEnterLoadedNotesEvent();
        }

        public void IconExitLoadedNotes() {
            IconExitLoadedNotesEvent();
        }

        public event Action TrySelectEvent;
        public event Action TryDeselectEvent;

        public void TrySelect() {
            TrySelectEvent();
        }

        public void TryDeselect() {
            TryDeselectEvent();
        }

        public void Init(Target target, TargetData targetData, Transform timelineTargetCollector = null) {
            data = targetData;
            data.HandTypeChangeEvent += OnHandTypeChanged;
            data.BehaviourChangeEvent += OnBehaviorChanged;
            data.BeatLengthChangeEvent += OnSustainLengthChanged;
            data.TickChangeEvent += OnTickChanged;
            this.timelineTargetCollector = timelineTargetCollector;
            this.target = target;
            sustainButtons.GetComponent<Canvas>().worldCamera = timelineCamera;

            foreach (Renderer r in gameObject.GetComponentsInChildren<Renderer>(true)) {
                r.material.SetFloat("_FadeThreshold", 1.7f);
                r.material.SetFloat("_OpaqueDuration", 0f);
                r.material.SetFloat("_FadeOutThreshold", 0.5f);
            }

            SetupFade();
        }

        public void OnDestroy() {
            data.HandTypeChangeEvent -= OnHandTypeChanged;
            data.BehaviourChangeEvent -= OnBehaviorChanged;
            data.BeatLengthChangeEvent -= OnSustainLengthChanged;
            data.TickChangeEvent -= OnTickChanged;
            if(location == TargetIconLocation.Timeline)
            {
                Destroy(childComponents.gameObject);
            }
        }

        public void ReplaceData(TargetData newData) {
            data.HandTypeChangeEvent -= OnHandTypeChanged;
            data.BehaviourChangeEvent -= OnBehaviorChanged;
            data.BeatLengthChangeEvent -= OnSustainLengthChanged;
            
            data = newData;

            newData.HandTypeChangeEvent += OnHandTypeChanged;
            newData.BehaviourChangeEvent += OnBehaviorChanged;
            newData.BeatLengthChangeEvent += OnSustainLengthChanged;
        }

        public void EnableSelected(TargetBehavior behavior) {
            selection.enabled = true;

            isSelected = true;

            if(location == TargetIconLocation.Grid) {
                foreach (LineRenderer l in gameObject.GetComponentsInChildren<LineRenderer>(true)) {
                    l.enabled = true;
                }
            }
        }

        public void DisableSelected() {
            selection.enabled = false;

            isSelected = false;
            if(location == TargetIconLocation.Grid) {
                foreach (LineRenderer l in gameObject.GetComponentsInChildren<LineRenderer>(true)) {
                    l.enabled = false;
                }
            }
        }


        public void SetOutlineColor(Color color) {
            selection.color = color;
        }

        private bool updatingColors = false;
        public void UpdateColors()
        {
            updatingColors = true;
            OnHandTypeChanged(data.handType);
        }

        private void OnHandTypeChanged(TargetHandType handType) {
            foreach (Renderer r in gameObject.GetComponentsInChildren<Renderer>(true)) {

                if (r.name == "WhiteRing") continue;

                switch (handType) {
                    case TargetHandType.Left:
                        r.material.SetColor("_Tint", NRSettings.config.leftColor);
                        break;
                    case TargetHandType.Right:
                        r.material.SetColor("_Tint", NRSettings.config.rightColor);
                        break;
                    case TargetHandType.Either:
                        r.material.SetColor("_Tint", UserPrefsManager.bothColor);
                        break;
                    default:
                        r.material.SetColor("_Tint", UserPrefsManager.neitherColor);
                        break;
                }
            }

            foreach (LineRenderer l in gameObject.GetComponentsInChildren<LineRenderer>(true)) {
                if(data.behavior == TargetBehavior.Legacy_Pathbuilder) {
                    handType = data.legacyPathbuilderData.handType;
                }

                switch (handType) {
                    case TargetHandType.Left:
                        l.startColor = NRSettings.config.leftColor;
                        l.endColor = NRSettings.config.leftColor;
                        sustainDirection = 0.6f;
                        if(location == TargetIconLocation.Timeline && !updatingColors) transform.localPosition += Vector3.up * timelineSpread;
                        break;
                    case TargetHandType.Right:
                        l.startColor = NRSettings.config.rightColor;
                        l.endColor = NRSettings.config.rightColor;
                        sustainDirection = -0.6f;
                        if (location == TargetIconLocation.Timeline && !updatingColors) transform.localPosition += Vector3.down * timelineSpread;
                        break;
                    case TargetHandType.Either:
                        l.startColor = UserPrefsManager.bothColor;
                        l.endColor = UserPrefsManager.bothColor;
                        sustainDirection = 0.6f;
                        if (location == TargetIconLocation.Timeline)
                        {
                            Vector3 newPos = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z); // Resets y offset
                            transform.localPosition = newPos; 
                        }
                        break;
                    default:
                        l.startColor = UserPrefsManager.neitherColor;
                        l.endColor = UserPrefsManager.neitherColor;
                        sustainDirection = 0.6f;
                        break;
                }

                if (data.supportsBeatLength && l.positionCount >= 3) {
                    l.SetPosition(1, new Vector3(0.0f, sustainDirection, 0.0f));
                    var pos2 = l.GetPosition(2);
                    l.SetPosition(2, new Vector3(pos2.x, sustainDirection, pos2.z));
                }


            }
            updatingColors = false;
        }

        private void OnSustainLengthChanged(QNT_Duration beatLength) {
            UpdateTimelineSustainLength();
        }

        public void IncreaseBeatLength() {

            QNT_Duration increment = Constants.DurationFromBeatSnap((uint)Timeline.instance.beatSnap);
            QNT_Duration targetLength = data.beatLength;
            if (targetLength < increment)
            {
                targetLength = new QNT_Duration(0);
            }
            targetLength += increment;
            QNT_Timestamp endTime = new QNT_Timestamp(data.time.tick + targetLength.tick);
            if (data.isRepeaterTarget)
            {
                
                if(!data.repeaterData.Section.Contains(endTime))
                {
                    NotificationCenter.SendNotification("Can't change beat length: target would be outside of repeater zone.", NotificationType.Warning);
                    return;
                }
            }
            else
            {
                if (Timeline.instance.repeaterManager.IsTargetInRepeaterZone(endTime))
                {
                    NotificationCenter.SendNotification("Can't change beat length: target would cross into a repater zone.", NotificationType.Warning);
                    return;
                }
            }


            if (target.data.legacyPathbuilderData != null && ChainBuilder.Instance.snapAngle)              
            {
                if (ChainBuilder.Instance.activated) ChainBuilder.Instance.ChangeInterval(true);
                else target.data.legacyPathbuilderData.interval = GetInterval(target.data.legacyPathbuilderData.interval, true);
                
                ChainBuilder.GenerateChainNotes(target.data);

            }
            else
            {
                target.MakeTimelineUpdateSustainLength(true);
            }
            
        }

        public void DescreseBeatLength() {

            if (target.data.legacyPathbuilderData != null && ChainBuilder.Instance.snapAngle)
            {
                if(ChainBuilder.Instance.activated) ChainBuilder.Instance.ChangeInterval(false);
                else target.data.legacyPathbuilderData.interval = GetInterval(target.data.legacyPathbuilderData.interval, false);
               
                ChainBuilder.GenerateChainNotes(target.data);
                
            }
            else
            {
                target.MakeTimelineUpdateSustainLength(false);
            }
        }

        private int GetInterval(int currentInterval, bool increase)
        {
            List<int> intervals = new List<int>();
            foreach(string s in NRSettings.config.snaps)
            {
                string temp = s;
                int snap = 4;
                int.TryParse(temp.Substring(2), out snap);
                intervals.Add(snap);
            }
            int index = intervals.IndexOf(currentInterval);
            if (index == intervals.Count - 1 && increase) return currentInterval;
            else if (index == 0 && !increase) return currentInterval;
            else if (increase) return intervals[index + 1];
            else return intervals[index - 1];
        }

        public void UpdateTimelineSustainLength() {
            if (!data.supportsBeatLength) {
                return;
            }
            float scale = 20.0f / Timeline.scale;
            QNT_Duration beatLength = data.isPathbuilderTarget ? data.pathbuilderData.BeatLength : data.beatLength;
            var lineRenderers = gameObject.GetComponentsInChildren<LineRenderer>(true);
            foreach (LineRenderer l in lineRenderers) {
                if (l.positionCount < 3) {
                    continue;
                }

                l.SetPosition(0, new Vector3(0.0f, 0.0f, 0.0f));
                l.SetPosition(1, new Vector3(0.0f, sustainDirection, 0.0f));
                l.SetPosition(2, new Vector3((beatLength.ToBeatTime() / 0.7f) * scale * 1.75f, sustainDirection, 0.0f)); //was * 1.32f
            }
        }

        public void MakeSustainIndicatorTransparent(bool transparent)
        {
            var lineRenderers = gameObject.GetComponentsInChildren<LineRenderer>(true);
            foreach (LineRenderer l in lineRenderers)
            {
                if (l.positionCount < 3)
                {
                    continue;
                }
                var color = l.startColor;
                color.a = transparent ? .3f : 1f;
                l.startColor = color;
                l.endColor = color;
                l.sortingOrder = transparent ? -1 : 1;
            }
            if (transparent)
            {
                UpdateTimelineSustainLength();
            }
        }

        public void SetBeatlengthLineActive(bool active)
        {
            beatLengthLine.SetActive(active);
            if(active)
            {
                UpdateTimelineSustainLength();
            }
            else
            {
                target.DisableSustainButtons();
            }
        }

        private void OnBehaviorChanged(TargetBehavior oldbehavior, TargetBehavior behavior)
        {
            ResetSpriteTransforms();

            UpdateSpriteForBehavior(behavior);

            if(pathBuilder != null) pathBuilder.SetActive(behavior == TargetBehavior.Legacy_Pathbuilder);

            if (location == TargetIconLocation.Timeline)
            {
                beatLengthLine.SetActive(data.supportsBeatLength);
                transform.localScale = Vector3.one * timelineTargetSize * 0.4f;
                collisionRadiusClick = collisionRadiusDrag = 0.50f;
            }
            else
            {
                transform.localScale = Vector3.one * timelineTargetSize * 0.4f;
            }


            if (behavior == TargetBehavior.ChainNode && location == TargetIconLocation.Timeline)
            {
                collisionRadiusClick = 0.2f;
            }
            else if (behavior == TargetBehavior.Melee && location == TargetIconLocation.Grid)
            {
                collisionRadiusClick = collisionRadiusDrag = 1.7f;
            }

            if (behavior == TargetBehavior.Legacy_Pathbuilder)
            {
                data.velocity = InternalTargetVelocity.Silent;
            }

            //Timeline.instance.ReapplyScale();
            if(location == TargetIconLocation.Timeline) transform.localScale = Timeline.instance.GetNoteScale(transform.localScale);
            UpdateTimelineSustainLength();
        }

        private void UpdateSpriteForBehavior(TargetBehavior behavior)
        {
            switch (behavior)
            {
                case TargetBehavior.Standard:
                    note.sprite = standard;
                    if (prefade != null) prefade.sprite = standardTelegraph;
                    if (ring != null) ring.sprite = standardRing;
                    selection.sprite = standardSelect;
                    break;
                case TargetBehavior.Sustain:
                    note.sprite = hold;
                    if(prefade != null)prefade.sprite = holdTelegraph;
                    if (ring != null)ring.sprite = holdRing;
                    selection.sprite = holdSelect;
                    break;
                case TargetBehavior.Horizontal:
                    note.sprite = horizontal;
                    if(prefade != null)prefade.sprite = horizontalTelegraph;
                    if (ring != null)ring.sprite = horizontalRing;
                    selection.sprite = horizontalSelect;

                    if (location == TargetIconLocation.Grid)
                    {
                        note.transform.localRotation = Quaternion.Euler(0f, 0f, -45f);
                        prefade.transform.localRotation = Quaternion.Euler(0f, 0f, -45f);
                        ring.transform.localRotation = Quaternion.Euler(0f, 0f, -45f);
                        selection.transform.localRotation = Quaternion.Euler(0f, 0f, -45f); 
                    }
                    else
                    {
                        note.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                        selection.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                    }
                    break;
                case TargetBehavior.Vertical:
                    note.sprite = vertical;
                    if(prefade != null)prefade.sprite = verticalTelegraph;
                    if (ring != null)ring.sprite = verticalRing;
                    selection.sprite = verticalSelect;


                    if (location == TargetIconLocation.Grid)
                    {
                        note.transform.localRotation = Quaternion.Euler(0f, 0f, 45f);
                        prefade.transform.localRotation = Quaternion.Euler(0f, 0f, 45f);
                        ring.transform.localRotation = Quaternion.Euler(0f, 0f, 45f);
                        selection.transform.localRotation = Quaternion.Euler(0f, 0f, 45f);
                    }
                    else
                    {
                        note.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                        selection.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    }
                    break;
                case TargetBehavior.ChainStart:
                    note.sprite = chainStart;
                    if(prefade != null)prefade.sprite = chainStartTelegraph;
                    if (ring != null)ring.sprite = chainStartRing;
                    selection.sprite = chainStartSelect;

                    if (location == TargetIconLocation.Grid) note.transform.localScale = Vector3.one * 1.7f;
                    else note.transform.localScale = Vector3.one * 0.7f;
                    break;
                case TargetBehavior.ChainNode:
                    note.sprite = chain;
                    if(prefade != null)prefade.sprite = chainTelegraph;
                    if (ring != null)ring.sprite = chainRing;
                    selection.sprite = chainSelect;
                    if (location == TargetIconLocation.Timeline) note.transform.localScale = Vector3.one * 0.2f;
                    break;
                case TargetBehavior.Melee:
                    note.sprite = melee;
                    if(prefade != null)prefade.sprite = meleeTelegraph;
                    if (ring != null)ring.sprite = meleeRing;
                    selection.sprite = meleeSelect;
                    if (location == TargetIconLocation.Grid)
                    {
                        note.transform.localScale = Vector3.one * 1.5f;
                        selection.transform.localScale = Vector3.one * 1.25f;
                        ring.transform.localScale = Vector3.one * 1.5f;
                    }
                    break;
                case TargetBehavior.Mine:
                    note.sprite = mine;
                    if(prefade != null)prefade.sprite = mineTelegraph;
                    if (ring != null)ring.sprite = mineRing;
                    selection.sprite = mineSelect;
                    break;
                case TargetBehavior.Legacy_Pathbuilder:
                    note.sprite = pathbuilder;
                    if(prefade != null)prefade.sprite = chainTelegraph;
                    if (ring != null)ring.sprite = chainRing;
                    selection.sprite = chainSelect;
                    break;

                default:
                    break;
            }
        }

        private void ResetSpriteTransforms()
        {
            note.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            if(prefade != null) prefade.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            if(ring != null) ring.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            selection.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            if (location == TargetIconLocation.Grid)
            {
                note.transform.localScale = Vector3.one * 0.728f;
                selection.transform.localScale = Vector3.one * 0.5414f;
                ring.transform.localScale = Vector3.one * 0.728f;
            }
            else
            {
                note.transform.localScale = Vector3.one * 0.657f;
                selection.transform.localScale = Vector3.one * 0.276f;
            }
        }

        private void OnTickChanged(QNT_Timestamp newTime, QNT_Timestamp oldTime) {
            SetupFade();
        }


        private void SetupFade() {
            if(location != TargetIconLocation.Grid) return;

            if(data.behavior == TargetBehavior.ChainNode) {
                NoteEnumerator iter = new NoteEnumerator(new QNT_Timestamp(0), data.time);
                iter.reverse = true;
                
                foreach(Target t in iter) {
                    if(t.data.behavior == TargetBehavior.ChainStart && t.data.handType == data.handType) {
                        foreach (Renderer r in gameObject.GetComponentsInChildren<Renderer>(true)) {
                            float offset = t.data.time.ToBeatTime() - data.time.ToBeatTime();
                            r.material.SetFloat("_WorldPosOffset", offset);
                            r.material.SetFloat("_OpaqueDuration", -offset);
                        }

                        break;
                    }
                }
            }
        }

        public void UpdatePath() {
            if(data.behavior != TargetBehavior.Legacy_Pathbuilder || location != TargetIconLocation.Grid) {
                return;
            }

            if (data.legacyPathbuilderData.parentNotes.Count == 0) {
                return;
            }

            var lineRenderers = gameObject.GetComponentsInChildren<LineRenderer>();
            foreach (LineRenderer l in lineRenderers) {
                switch (data.legacyPathbuilderData.handType) {
                    case TargetHandType.Left:
                        l.startColor = NRSettings.config.leftColor;
                        l.endColor = NRSettings.config.leftColor;
                        break;
                    case TargetHandType.Right:
                        l.startColor = NRSettings.config.rightColor;
                        l.endColor = NRSettings.config.rightColor;
                        break;
                    case TargetHandType.Either:
                        l.startColor = UserPrefsManager.bothColor;
                        l.endColor = UserPrefsManager.bothColor;
                        break;
                    default:
                        l.startColor = UserPrefsManager.neitherColor;
                        l.endColor = UserPrefsManager.neitherColor;
                        break;
                }

                int count = data.legacyPathbuilderData.generatedNotes.Count / data.legacyPathbuilderData.parentNotes.Count;

                Vector3[] positions = new Vector3[count];

                for(int i = 0; i < count; ++i) {
                    var note = data.legacyPathbuilderData.generatedNotes[i];
                    positions[i] = new Vector3(note.x, note.y, 0.0f);
                }

                l.positionCount = positions.Length;
                l.SetPositions(positions);
            }
        }

        public void UpdatePathInitialAngle(float angle) {
            if(data.behavior != TargetBehavior.Legacy_Pathbuilder) {
                return;
            }

            
            UpdatePath();
        }

        public bool IsCloseToPoint(Vector2 point) {
            Vector2 center = transform.TransformPoint(0,0,0);
            float collisionRad = transform.TransformVector(collisionRadiusClick, 0, 0).x;
            return (point - center).sqrMagnitude < collisionRad * collisionRad;
        }

        public bool IsInsideRect(Rect rect) {
            Vector2 center = transform.TransformPoint(0,0,0);
            Vector2 closestPoint = center;
            closestPoint.x = Mathf.Clamp(closestPoint.x, rect.min.x, rect.max.x);
            closestPoint.y = Mathf.Clamp(closestPoint.y, rect.min.y, rect.max.y);
            float collisionRad = transform.TransformVector(collisionRadiusDrag, 0, 0).x;
            return (closestPoint - center).sqrMagnitude < collisionRad * collisionRad;
        }

        public bool IsInValidTime(QNT_Timestamp time) {
            QNT_Duration loadedDuration = Constants.QuarterNoteDuration + Constants.EighthNoteDuration;
            if(location == TargetIconLocation.Grid && Math.Abs((time - target.data.time).tick) > (long)loadedDuration.tick) {
                return false;
            }

            return true;
        }
    }
}