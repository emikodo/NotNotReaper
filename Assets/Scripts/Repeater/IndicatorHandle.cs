using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NotReaper.Repeaters
{
    public class IndicatorHandle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private RepeaterIndicator indicator;
        [SerializeField] private bool isStartHandle;
        public void OnPointerDown(PointerEventData eventData)
        {
            indicator.StartDrag(isStartHandle);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            indicator.EndDrag();
        }
    }
}
