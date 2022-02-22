﻿using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Windows.Forms;
using UnityEngine.InputSystem;

namespace NotReaper.UI
{
    public class NRButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField]
        public UnityEvent NROnClick;

        public Image buttonBackground;

        public Image icon;

        public bool destroyOnClick = false;

        public string ButtonTooltip = "";

        public float onHoverValue = 0.8f;

        public Window parentWindow;

        public float onHoverSpeed = .15f;
        public float onHoverExitSpeed = .5f;

        [SerializeField] private InputActionReference action;

        private float originalBackgroundHoverValue;
        private float originalIconHoverValue;

        private void Awake()
        {
            buttonBackground = gameObject.GetComponent<Image>();
            parentWindow = gameObject.GetComponentInParent<Window>();
            originalBackgroundHoverValue = buttonBackground.color.a;
            if(icon) originalIconHoverValue = icon.color.a;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (destroyOnClick)
            {
                buttonBackground.DOFade(0.0f, 0.3f).SetEase(Ease.OutQuart).OnComplete(() => { Destroy(gameObject); NROnClick.Invoke(); });
            }
            else
            {
                NROnClick.Invoke();
                buttonBackground.DOKill(true);
                transform.DOKill(true);
                transform.DOPunchScale(new Vector3(0.04f, 0.04f, 0.04f), 0.13f, 2, 0.2f);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            buttonBackground.DOKill(true);
            buttonBackground.DOFade(onHoverValue, onHoverSpeed).SetEase(Ease.OutQuart);
            if (icon)
            {
                originalIconHoverValue = icon.color.a;
                icon.DOKill(true);
                icon.DOFade(onHoverValue, onHoverSpeed).SetEase(Ease.OutQuart);
            }
        
            if(parentWindow != null) parentWindow.canDrag = false;
            if (action != null) ToolTips.I.SetText(action);
            else ToolTips.I.SetText(ButtonTooltip);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            buttonBackground.DOKill(true);
            buttonBackground.DOFade(originalBackgroundHoverValue, onHoverExitSpeed).SetEase(Ease.InQuart);
            if (icon)
            {
                icon.DOKill(true);
                icon.DOFade(originalIconHoverValue, onHoverExitSpeed).SetEase(Ease.InQuart);
            }       
            if (parentWindow != null) parentWindow.canDrag = true;
            ToolTips.I.SetText("");
        }
    }

}
