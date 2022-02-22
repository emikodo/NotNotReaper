using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.InputSystem;

namespace NotReaper.UI
{
    public class OnHoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] string onHoverTipText;
        [SerializeField] bool animate;
        [SerializeField] private InputActionReference action;
        public void OnPointerEnter(PointerEventData eventData)
        {
            if(action != null)
            {
                ToolTips.I.SetText(action);
            }
            else
            {
                ToolTips.I.SetText(onHoverTipText);
            }
            if (animate)
            {
                transform.DOKill(true);
                transform.DOPunchScale(new Vector3(0.04f, 0.1f, 0.04f), 0.13f, 2, 0.2f);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ToolTips.I.SetText("");
        }
    }
}

