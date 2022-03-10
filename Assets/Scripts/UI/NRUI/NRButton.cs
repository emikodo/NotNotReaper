using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using NotReaper.Audio;
using UnityEngine.InputSystem;

namespace NotReaper.UI.Components
{
    [ExecuteAlways]
    public class NRButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Skin")]
        [SerializeField] private NRButtonData skin;
        [Space, Header("Animation")]
        [SerializeField, Range(.01f, 1f)] private float animationDuration = .25f;
        [SerializeField] private bool growOnHover;
        [SerializeField] private bool growOnClick;
        [SerializeField, Range(0f, 10f)] private float growPercentage = 1f;
        [SerializeField, Range(0f, 20f)] private float moveAmount = .1f;
        [SerializeField] private AnimationMode mode;
        [Space, Header("Background")]
        [SerializeField] private bool hideBackground;
        [Space, Header("Outline")]
        [SerializeField] private bool useOutline = true;
        [Space, Header("Icon")]
        [SerializeField] private Sprite icon;
        [SerializeField] private Color defaultColor = Color.white;
        [SerializeField] private Color highlightedColor = Color.white;
        [SerializeField] private Color pressedColor = Color.white;
        [Space, Header("Text")]
        [SerializeField] private float textSize = 15f;
        [SerializeField] private bool autoSizeText;
        [SerializeField] private string text;
        [Space, Header("Tooltip")]
        [SerializeField] private string tooltipText;
        [SerializeField] private InputActionReference keybind;
        [Space, Header("Group")]
        [SerializeField] private NRButtonGroup buttonGroup;
        [Space]

        public OnClick onClick;
        
        [SerializeField, HideInInspector] private Image background;
        [SerializeField, HideInInspector] private Image outline;
        [SerializeField, HideInInspector] private TextMeshProUGUI textContainer;
        [SerializeField, HideInInspector] private GameObject iconHolder;
        [SerializeField, HideInInspector] private Image iconDisplay;

        private bool isMouseOver = false;
        private Vector2 initialPosition;
        private Vector3 initialScale;
        private float initialRotation;
        private bool initializedPosition = false;
        private bool initialized = false;
        private bool _interactable = true;
        private bool stayOnSelected = false;
        private bool isSelected = false;
        private Action<NRButton> onSelectedAction;

        private SoundEffects effects;

        public bool interactable
        {
            get { return _interactable;  }
            set 
            { 
                _interactable = value;
                SetInteractable(_interactable);
            }
        }

        private void Start()
        {
            if (Application.isPlaying)
            {
                effects = NRDependencyInjector.Get<SoundEffects>();
            }

            if (buttonGroup != null)
            {
                buttonGroup.RegisterButton(this);
            }

            if (Application.isPlaying)
            {
                initialScale = transform.localScale;
                UpdateButton();
            }
        }

#if UNITY_EDITOR
        private void OnDestroy()
        {
            if(buttonGroup != null)
            {
                buttonGroup.UnregisterButton(this);
            }
        }
#endif

        public void Initialize()
        {
            initialized = true;
            background = transform.GetChild(0).GetComponent<Image>();
            outline = background.transform.GetChild(0).GetComponent<Image>();
            textContainer = outline.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            iconHolder = outline.transform.GetChild(1).gameObject;
            iconDisplay = iconHolder.transform.GetChild(0).GetComponent<Image>();
        }

        private void OnValidate()
        {
            if (Application.isPlaying) return;

            if (!initialized)
            {
                Initialize();
            } 

            if(buttonGroup != null)
            {
                buttonGroup.RegisterButton(this);
            }
            UpdateButton();
        }

        private void OnDisable()
        {
            if (!Application.isPlaying) return;
            if (initialized)
            {
                background.transform.localPosition = initialPosition;
                background.transform.localScale = initialScale;
                iconDisplay.transform.rotation = Quaternion.Euler(0f, 0f, initialRotation);
            }
            ToolTips.I.SetText("");
        }

        private void SetInteractable(bool interactable)
        {
            if (!interactable)
            {
                background.color = skin.disabledColor;
            }
            else
            {
                if (isMouseOver)
                {
                    background.color = skin.highlightedColor;
                }
                else if (isSelected)
                {
                    background.color = skin.pressedColor;
                }
                else
                {
                    background.color = skin.defaultColor;
                }
            }
        }

        public void UpdateButton()
        {
            if(buttonGroup != null)
            {
                skin = buttonGroup.skin;
                animationDuration = buttonGroup.animationDuration;
                growOnHover = buttonGroup.growOnHover;
                growOnClick = buttonGroup.growOnClick;
                growPercentage = buttonGroup.growPercentage;
                moveAmount = buttonGroup.moveAmount;
                mode = buttonGroup.mode;
                useOutline = buttonGroup.useOutline;
                autoSizeText = buttonGroup.autoSizeText;
                textSize = buttonGroup.textSize;
                hideBackground = buttonGroup.hideBackground;
                defaultColor = buttonGroup.defaultColor;
                highlightedColor = buttonGroup.highlightedColor;
                pressedColor = buttonGroup.pressedColor;
                stayOnSelected = buttonGroup.stayOnSelected;
            }
            
            background.color = skin.defaultColor;
            background.enabled = !hideBackground;
            
            outline.enabled = useOutline;
            outline.color = skin.outlineColor;

            if (icon == null)
            {
                iconHolder.SetActive(false);
                textContainer.gameObject.SetActive(true);
                textContainer.text = text.ToLower();
                textContainer.enableAutoSizing = autoSizeText;
                textContainer.fontSizeMax = textSize;
                textContainer.fontSizeMin = 0.1f;
                textContainer.fontSize = textSize;
            }
            else
            {
                iconHolder.SetActive(true);
                iconDisplay.sprite = icon;
                iconDisplay.color = defaultColor;
                textContainer.gameObject.SetActive(false);
            }
                       
        }

        public void SetText(string text)
        {
            this.text = text;
            textContainer.text = text.ToLower();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(keybind != null)
            {
                ToolTips.I.SetText(keybind);
            }
            else if (!string.IsNullOrEmpty(tooltipText))
            {
                ToolTips.I.SetText(tooltipText);
            }
            if (!interactable || isSelected) return;
            isMouseOver = true;
            DoBackgroundColorTransition(skin.highlightedColor);
            DoIconColorTransition(highlightedColor);
            DoMove(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ToolTips.I.SetText("");
            if (!interactable || isSelected) return;

            isMouseOver = false;
            DoBackgroundColorTransition(skin.defaultColor);
            DoIconColorTransition(defaultColor);
            DoMove(false);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!interactable || isSelected) return;

            DoBackgroundColorTransition(isMouseOver ? skin.highlightedColor : skin.defaultColor);
            DoIconColorTransition(isMouseOver ? highlightedColor : defaultColor);
            if (growOnClick)
            {
                GrowOnClick(false);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!interactable || isSelected) return;

            DoBackgroundColorTransition(skin.pressedColor);
            DoIconColorTransition(pressedColor);
            if (growOnClick)
            {
                GrowOnClick(true);
            }
            if (stayOnSelected)
            {
                if(buttonGroup != null)
                {
                    buttonGroup.SetSelectedButton(this);
                }
                else
                {
                    onSelectedAction?.Invoke(this);
                }
                isSelected = true;
            }
            effects.PlaySound(SoundEffects.Sound.Click);
            onClick.Invoke();
        }

        public void OverrideStayOnSelected(bool stay, Action<NRButton> onSelectedAction)
        {
            stayOnSelected = stay;
            this.onSelectedAction = onSelectedAction;
        }

        public void Deselect()
        {
            isSelected = false;
            OnPointerExit(null);
        }

        private void DoBackgroundColorTransition(Color newColor)
        {
            background.DOKill();
            background.DOColor(newColor, animationDuration);
        }

        private void DoIconColorTransition(Color newColor)
        {
            if(icon != null)
            {
                iconDisplay.DOKill();
                iconDisplay.DOColor(newColor, animationDuration);
            }
        }

        private void DoMove(bool hover)
        {
            background.transform.DOKill();
            if (!initializedPosition)
            {
                initializedPosition = true;
                initialScale = background.transform.localScale;
                initialPosition = background.transform.localPosition;
                initialRotation = iconDisplay.transform.rotation.z;
            }
            if (growOnHover)
            {
                float amount = Mathf.Abs(initialScale.x * (growPercentage * .01f));
                Vector3 growAmount = new Vector3(Mathf.Sign(initialScale.x) * amount, Mathf.Sign(initialScale.y) * amount, Mathf.Sign(initialScale.z) * amount);
                background.transform.DOScale(hover ? initialScale + growAmount : initialScale, animationDuration);
            }

            if(mode == AnimationMode.Spin && icon != null)
            {
                iconDisplay.transform.DOKill();
                iconDisplay.transform.DORotate(new Vector3(0f, 0f, hover ? 90f : initialRotation), animationDuration, RotateMode.Fast);
            }
            else if(mode != AnimationMode.None)
            {
                
                Vector2 position = initialPosition;
                if (hover)
                {
                    position.x += mode == AnimationMode.MoveLeft ? -moveAmount : mode == AnimationMode.MoveRight ? moveAmount : 0f;
                    position.y += mode == AnimationMode.MoveUp ? moveAmount : mode == AnimationMode.MoveDown ? -moveAmount : 0f;
                }            
                background.transform.DOLocalMove(position, animationDuration);
            }
        }

        private void GrowOnClick(bool clickDown)
        {
            background.transform.DOKill();
            float amount = Mathf.Abs(initialScale.x * (growPercentage * .01f));
            Vector3 growAmount = new Vector3(Mathf.Sign(initialScale.x) * amount, Mathf.Sign(initialScale.y) * amount, Mathf.Sign(initialScale.z) * amount);
            Vector3 target = clickDown ? growOnHover ? initialScale + (growAmount * 2f) : initialScale + growAmount : growOnHover ? initialScale + growAmount : initialScale;
            background.transform.DOScale(target, animationDuration);
        }       
    }

    public enum AnimationMode
    {
        None,
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        Spin
    }

    [Serializable]
    public class OnClick : UnityEvent
    {
        public OnClick OnEvent;
    }
}

