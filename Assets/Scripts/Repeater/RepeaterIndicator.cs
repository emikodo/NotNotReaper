using NotReaper.Timing;
using NotReaper.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
namespace NotReaper.Repeaters
{
    public class RepeaterIndicator : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private RectTransform rect;
        [SerializeField] private Image background;
        [SerializeField] private TextMeshProUGUI textContainer;
        [SerializeField] private Transform startHandle;
        [SerializeField] private Transform endHandle;
        [SerializeField] private RectTransform miniTimelineIndicatorPrefab;
        [Space]
        [SerializeField] private Color normalColor;
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color miniNormalColor;
        [SerializeField] private Color miniSelectedColor;
        private Timeline timeline;
        private InputAction mousePosition;
        private RepeaterSection section;

        private QNT_Timestamp minTime;
        private QNT_Timestamp maxTime;
        private QNT_Timestamp lastTime = new QNT_Timestamp(0);

        private bool dragging = false;
        private RepeaterMenu overlay;
        private GraphicRaycaster raycaster;
        private MiniTimeline miniTimeline;
        private Transform miniTimelineParent;
        private RectTransform miniTimelineIndicator;
        private Image miniBackground;

        public void Initialize(Transform miniTimelineParent)
        {
            miniTimeline = NRDependencyInjector.Get<MiniTimeline>();
            raycaster = GetComponent<GraphicRaycaster>();
            overlay = NRDependencyInjector.Get<RepeaterMenu>();
            timeline = NRDependencyInjector.Get<Timeline>();
            mousePosition = KeybindManager.Global.MousePosition;
            this.miniTimelineParent = miniTimelineParent;
            miniTimelineIndicator = Instantiate(miniTimelineIndicatorPrefab, miniTimelineParent);
            miniBackground = miniTimelineIndicator.GetComponent<Image>();
        }

        public void SetSection(RepeaterSection section)
        {
            this.section = section;
        }

        public void SetText(string text)
        {
            textContainer.text = text;
        }

        public void SetWidth(float width)
        {
            rect.sizeDelta = new Vector2(width, 1f);
            Bounds bounds = new(rect.position, rect.sizeDelta);
            startHandle.position = new Vector2(bounds.min.x + rect.sizeDelta.x * .5f, bounds.min.y);
            endHandle.position = new Vector2(bounds.max.x + rect.sizeDelta.x * .5f, bounds.min.y);
            transform.localScale = Vector3.one;
            Vector3 pos = miniTimelineIndicator.localPosition;
            pos.x = miniTimeline.TimestampToMinitimeline(section.activeStartTime);
            miniTimelineIndicator.localPosition = pos;
            float miniWidth = miniTimeline.TimestampToMinitimeline(section.activeEndTime) - pos.x;
            miniTimelineIndicator.sizeDelta = new Vector2(miniWidth, 22.1f);

        }

        public void FixScaling()
        {
            transform.localScale = Vector3.one;
            Vector3 scale = startHandle.localScale;
            scale.x = Timeline.scale / 20f;
            startHandle.localScale = scale;
            endHandle.localScale = scale;
        }

        public void SetInteractable(bool interactable)
        {
            startHandle.gameObject.SetActive(interactable);
            endHandle.gameObject.SetActive(interactable);
            raycaster.enabled = interactable;
        }

        public void StartDrag(bool isStartHandle)
        {
            if (dragging) return;
            OnPointerDown(null);
            dragging = true;
            if (isStartHandle)
            {
                minTime = section.startTime;
                maxTime = section.activeEndTime;
            }
            else
            {
                minTime = section.activeStartTime;
                maxTime = timeline.ShiftTick(new QNT_Timestamp(0), timeline.songPlayback.song.Length);
            }
            StopAllCoroutines();
            StartCoroutine(DoDrag(isStartHandle));
        }

        public void EndDrag()
        {
            StopAllCoroutines();
            lastTime = new QNT_Timestamp(0);
            dragging = false;
        }

        private IEnumerator DoDrag(bool isStartHandle)
        {
            bool foundTransient = false;
            bool foundBoundary = false;
            while (dragging)
            {
                var mousePos = Camera.main.ScreenToWorldPoint(mousePosition.ReadValue<Vector2>());
                mousePos.x /= Timeline.scaleTransform;
                mousePos.x -= timeline.transform.position.x;
                QNT_Timestamp newTime = SnapToBeat(mousePos.x);
                if (newTime != lastTime)
                {
                    lastTime = newTime;

                    float length = isStartHandle ? (section.activeEndTime.tick - newTime.tick) : newTime.tick - section.activeStartTime.tick;
                    if(length > 0f)
                    {
                        var search = Timeline.BinarySearchOrderedNotes(newTime);
                        bool found = search.found;
                        if (!foundBoundary && !isStartHandle && timeline.repeaterManager.IsTargetInRepeaterZone(newTime, section.startTime))
                        {
                            foundBoundary = true;
                            maxTime = newTime;
                        }
                        else if (found)
                        {
                            var foundTarget = Timeline.orderedNotes[search.index];
                            found = foundTarget.data.time < section.activeStartTime || foundTarget.data.time > section.activeEndTime;
                            if (found)
                            {
                                maxTime = foundTarget.data.time;
                                foundBoundary = true;
                            }
                            if (foundTarget.transient && !foundTransient)
                            {
                                foundTransient = true;
                                minTime = new QNT_Timestamp(foundTarget.data.time.tick - 1);
                            }
                            else if (foundTarget.data.isPathbuilderTarget || foundTarget.data.legacyPathbuilderData != null)
                            {
                                maxTime = new QNT_Timestamp(foundTarget.data.time.tick + 1);
                            }
                        }

                        if (!found && newTime >= minTime && newTime <= maxTime)
                        {
                            if (isStartHandle)
                            {
                                section.SetActiveStartTime(newTime);
                                transform.localPosition = new Vector3(newTime.ToBeatTime(), 0f, 0f);
                            }
                            else
                            {
                                section.SetActiveEndTime(newTime);
                            }
                            SetWidth((section.activeEndTime - section.activeStartTime).ToBeatTime());
                        }
                        else
                        {
                            if (!isStartHandle && !foundBoundary) maxTime = newTime;
                        }
                    }
                    
                }
                yield return null;
            }
            yield return null;
        }

        private QNT_Timestamp SnapToBeat(float posX)
        {
            QNT_Timestamp time = Timeline.time + Relative_QNT.FromBeatTime(posX);
            return timeline.GetClosestBeatSnapped(time + Constants.DurationFromBeatSnap((uint)timeline.beatSnap) / 2, (uint)timeline.beatSnap);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            overlay.SetActiveSection(this);
        }

        public void SetSectionActive(bool active)
        {
            if (active)
            {
                background.color = selectedColor;
                miniBackground.color = miniSelectedColor;
            }
            else
            {
                background.color = normalColor;
                miniBackground.color = miniNormalColor;
            }
        }

        public RepeaterSection GetSection()
        {
            return section;
        }

        public void RemoveMiniIndicator()
        {
            Destroy(miniTimelineIndicator);
        }
    }
}

