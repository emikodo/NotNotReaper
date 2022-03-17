using DG.Tweening;
using NotReaper.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NotReaper.UI.Components
{
    [ExecuteAlways]
    public class NRToggle : NRThemeable, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        [Header("Skin")]
        [SerializeField] private NRToggleSkin skin;
        [Space, Header("Toggle")]
        [SerializeField] public bool isOn = false;
        [Header("Animation")]
        [SerializeField] private float animationDuration = .3f;
        [Space, Header("Text")]
        [SerializeField] private string text = "";
        [SerializeField] private float textSize = 20f;
        [SerializeField] private bool autoSize = false;
        [Space, Header("Icon")]
        [SerializeField] private float iconScale = 1f;
        [Space, Header("Toggle Group")]
        [SerializeField] private NRToggleGroup toggleGroup;

        public OnSelected onSelected;

        [HideInInspector, SerializeField] public TextMeshProUGUI textContainer;
        [HideInInspector, SerializeField] public Image background;
        [HideInInspector, SerializeField] public Image fill;
        private Camera cam;
        private bool _selected;
        [SerializeField] public bool selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                SetSelected(value);
            }
        }

        private bool initialized;
        private SoundEffects effects;
        private float initialRotation;
        private bool initializedPosition;

        private LayoutGroup layout;

        private void Awake()
        {
            if (Application.isPlaying)
            {
                layout = GetComponent<LayoutGroup>();

                selected = isOn;
                var color = GetFillColor();
                color.a = selected ? 1f : 0f;
                fill.color = color;


                if (toggleGroup != null)
                {
                    toggleGroup.RegisterToggle(this);
                }
                if (Application.isPlaying)
                {
                    //UpdateVisuals();
                    StartCoroutine(UpdateLayout());
                }
            }
            
        }

        private IEnumerator UpdateLayout()
        {
            layout.enabled = false;
            yield return new WaitForEndOfFrame();
            layout.enabled = true;
            //fitter.enabled = false;
        }

        protected override void Start()
        {
            base.Start();
            if (Application.isPlaying)
            {
                effects = NRDependencyInjector.Get<SoundEffects>();
                cam = NRDependencyInjector.Get<NewPauseMenu>().GetMainMenuCamera();
            }


        }

        private void SetSelected(bool selected)
        {
            isOn = selected;
            var color = fill.color;
            color.a = selected ? 1f : 0f;
            fill.color = color;


        }

        public void Deselect()
        {
            isOn = false;
            selected = false;
        }

        public override void ApplyDarkTheme(ThemeData theme)
        {
            if (toggleGroup != null)
            {
                toggleGroup.skin = theme.toggle.dark;
            }
            else
            {
                skin = theme.toggle.dark;
            }
        }

        public override void ApplyLightTheme(ThemeData theme)
        {
            if(toggleGroup != null)
            {
                toggleGroup.skin = theme.toggle.light;
            }
            else
            {
                skin = theme.toggle.light;
            }
        }

        public override void Initialize()
        {
            initialized = true;
            background = transform.GetChild(0).GetComponent<Image>();
            fill = background.transform.GetChild(0).GetComponent<Image>();
            textContainer = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            textContainer.fontSize = textSize;
        }

        public override void UpdateVisuals()
        {
            if(toggleGroup != null)
            {
                skin = toggleGroup.skin;
                autoSize = toggleGroup.autoSize;
                textSize = toggleGroup.textSize;
                iconScale = toggleGroup.iconScale;
                if (isOn)
                {
                    selected = true;
                    toggleGroup.SetSelectedToggle(this);
                }
                else
                {
                    selected = false;
                    toggleGroup.DeselectToggle(this);
                }
            }
            else
            {
                selected = isOn;
            }

            background.color = skin.backgroundColor;
            var color = GetFillColor();
            color.a = selected ? 1f : 0f;
            fill.color = color;
            textContainer.text = text.ToLower();
            textContainer.color = skin.textColor;
            textContainer.enableAutoSizing = autoSize;
            textContainer.fontSize = textSize;
            textContainer.fontSizeMax = textSize;
            textContainer.fontSizeMin = .1f;
            background.transform.localScale = Vector3.one * iconScale;
            

        }

        private Color GetFillColor()
        {
            switch (skin.fillColorMode)
            {
                case NRToggleSkin.FillColor.Custom:
                    return skin.fillColor;
                case NRToggleSkin.FillColor.CurrentHand:
                    return EditorState.Hand.Current == Models.TargetHandType.Left ? NRSettings.config.leftColor : NRSettings.config.rightColor;
                case NRToggleSkin.FillColor.OppositeHand:
                    return EditorState.Hand.Current == Models.TargetHandType.Left ? NRSettings.config.rightColor : NRSettings.config.leftColor;
                case NRToggleSkin.FillColor.LeftHand:
                    return NRSettings.config.leftColor;
                case NRToggleSkin.FillColor.RightHand:
                    return NRSettings.config.rightColor;
                default:
                    return skin.fillColor;
            }
        }

        protected override void OnValidate()
        {
            if (Application.isPlaying) return;

            if (!initialized)
            {
                Initialize();
            }

            if (toggleGroup != null)
            {
                toggleGroup.RegisterToggle(this);
            }

            UpdateVisuals();
        }

#if UNITY_EDITOR
        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (toggleGroup != null)
            {
                toggleGroup.UnregisterToggle(this);
            }
        }
#endif



        private void DoSpinAnimation(bool hover)
        {
            int direction = 1;
            if (hover)
            {
                var iconPos = background.transform.position;
                var mousePos = cam.ScreenToWorldPoint(KeybindManager.Global.MousePosition.ReadValue<Vector2>());
                if (mousePos.y < iconPos.y && mousePos.x > iconPos.x)
                {
                    direction = -1;
                }
                else if(mousePos.y > iconPos.y && mousePos.x < iconPos.x)
                {
                    direction = -1;
                }
            }
            

            background.transform.DOKill();
            background.transform.DORotate(new Vector3(0f, 0f, hover ? -90f * direction : initialRotation), animationDuration, RotateMode.Fast);
        }

        private void DoFillAnimation()
        {
            fill.DOFade(selected ? 1f : 0f , animationDuration);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!initializedPosition)
            {
                initializedPosition = true;
                initialRotation = background.transform.rotation.z;
            }
            DoSpinAnimation(true);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            _selected = !_selected;
            effects.PlaySound(SoundEffects.Sound.Click);
            DoFillAnimation();
            onSelected?.Invoke(selected);
            if (toggleGroup != null)
            {
                toggleGroup.SetSelectedToggle(this);
            }
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            DoSpinAnimation(false);
        }


        private void OnDisable()
        {
            if (!Application.isPlaying) return;
            if (initialized)
            {
                background.transform.rotation = Quaternion.Euler(0f, 0f, initialRotation);
            }
        }

        [Serializable]
        public class OnSelected : UnityEvent<bool>
        {
            public OnSelected OnEvent;
        }
    }
}
