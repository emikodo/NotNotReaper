using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using NotReaper.Models;
using NotReaper.MenuBrowser;

namespace NotReaper.Overlays
{
    [RequireComponent(typeof(CanvasGroup), typeof(RectTransform))]
    public abstract class NROverlay : MonoBehaviour
    {
        [Header("Overlay Settings")]
        [SerializeField] private string overlayName = "";
        [SerializeField] protected bool browsable = true;
        [SerializeField] protected bool isCanvasInOverlayMode = false;
        [SerializeField] private RectTransform parentCanvas;
        [Header("Dragging")]
        [SerializeField] private bool draggable = true;
        [SerializeField] private bool shouldReturn = false;
        [SerializeField] private float minMoveDistanceBeforeDragStart = 2f;
        [Space, Header("Fading")]
        [SerializeField] private bool doFadeAnimation = true;
        [SerializeField] private float fadeDuration = .3f;
        [Space, Header("Behavior")]
        [SerializeField] private bool avoidOpeningOverTargets = false;
        [SerializeField] private bool rememberPosition = true;
        [SerializeField] private Location defaultOpeningLocation = Location.BottomRight;
        [Space]
        private DragHandler drag;
        protected Timeline timeline;
        protected RectTransform rect;
        protected CanvasGroup canvas;
        private Camera cam;

        protected virtual void Start()
        {
            if (draggable)
            {
                drag = gameObject.AddComponent<DragHandler>();
                drag.isCanvasInOverlayMode = isCanvasInOverlayMode;
                drag.minMoveDistanceBeforeDragStart = minMoveDistanceBeforeDragStart;
                drag.shouldReturn = shouldReturn;
            }
            canvas = GetComponent<CanvasGroup>();
            rect = GetComponent<RectTransform>();
            timeline = NRDependencyInjector.Get<Timeline>();
            cam = Camera.main;
            canvas.alpha = 0f;
            rect.localPosition = GetCornerLocation(defaultOpeningLocation);
            if (browsable)
            {
                MenuRegistration.RegisterOverlay(overlayName, this);
            }
            gameObject.SetActive(false);
        }

        public abstract void Show();
        public abstract void Hide();

        protected virtual void OnActivated()
        {
            gameObject.SetActive(true);
            PositionOverlay();
            if (doFadeAnimation)
            {
                canvas.DOKill();
                canvas.DOFade(1f, fadeDuration);
            }
        }

        protected virtual void OnDeactivated()
        {
            if (doFadeAnimation)
            {
                canvas.DOKill();
                canvas.DOFade(0f, fadeDuration).OnComplete(() =>
                {
                    gameObject.SetActive(false);
                });
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        protected abstract void OnEditorModeChanged(EditorMode mode);

        private void PositionOverlay()
        {
            Vector3 position = rememberPosition ? rect.localPosition : GetCornerLocation(defaultOpeningLocation);

            if (avoidOpeningOverTargets)
            {
                if (timeline.areNotesSelected)
                {
                    if (timeline.selectedNotes.Count == 1)
                    {
                        Vector3[] corners = new Vector3[4];
                        rect.GetWorldCorners(corners);
                        if (isCanvasInOverlayMode)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                corners[i] = cam.ScreenToWorldPoint(corners[i]);
                            }
                        }                 
                        var bounds = Rect.MinMaxRect(corners[0].x, corners[0].y, corners[2].x, corners[2].y);
                        Debug.Log(bounds.xMin);
                        Debug.Log(bounds.xMax);
                        if (timeline.selectedNotes[0].IsInsideRectAtTime(Timeline.time, bounds))
                        {
                            if (rect.localPosition.x > 0)
                            {
                                position = GetCornerLocation(Location.BottomLeft);
                            }
                            else
                            {
                                position = GetCornerLocation(Location.BottomRight);
                            }
                        }
                        
                    }
                }
            }          
            rect.localPosition = position;
        }

        private Vector3 GetCornerLocation(Location location)
        {
            Vector3 position;
            if (location == Location.Center)
            {
                rect.pivot = new Vector2(.5f, .5f);
                position = cam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
            }
            else
            {
                rect.pivot = new Vector2(location == Location.BottomLeft ? 0 : 1, 0);
                position = cam.ViewportToWorldPoint(new Vector3(location == Location.BottomLeft ? 0 : 1, 0, 0));
                if (isCanvasInOverlayMode)
                {
                    var pos = cam.ViewportToScreenPoint(new Vector3(location == Location.BottomLeft ? 0 : 1, 0, 0));
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas, pos, null, out Vector2 point);
                    position = point;
                    //position = new Vector3(location == Location.BottomLeft ? 0 : 1, 0, 0);
                }
            }
            position.z = 0f;
            return position;
        }
    }
}
