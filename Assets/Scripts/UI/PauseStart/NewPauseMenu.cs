using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
using NotReaper;
using TMPro;
using UnityEngine.UI;
using NotReaper.Maudica;

namespace NotReaper.UI
{
    public class NewPauseMenu : NRMenu
    {
        [NRInject] private Timeline timeline;

        private CanvasGroup canvas;
        [Header("References")]
        [SerializeField] private GameObject volumePanel;
        [SerializeField] private GameObject maudicaMenuButton;
        [SerializeField] private Image nrStartOverlay;
        [SerializeField] private TextMeshProUGUI title;
        [Space, Header("Views")]
        [SerializeField] private View defaultView;
        [SerializeField] private View maudicaView;
        [SerializeField] private View recentsView;
        [SerializeField] private View newView;
        [SerializeField] private View browserView;
        [SerializeField] private View settingsView;

        private View activeView;

        private bool isInStartScreen = true;

        protected override void Awake()
        {
            base.Awake();

            canvas = GetComponent<CanvasGroup>();
            canvas.alpha = 0f;
            defaultView.Initialize();
            recentsView.Initialize();
            newView.Initialize();
            browserView.Initialize();
            settingsView.Initialize();
            maudicaView.Initialize();
            Reset();
            transform.localPosition = Vector3.zero;
            Color c = nrStartOverlay.color;
            c.a = 1f;
            nrStartOverlay.color = c;

            var can = GetComponent<Canvas>();
            can.renderMode = RenderMode.ScreenSpaceOverlay;
            var scaler = GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Shrink;


            Show();
        }

        private void Start()
        {
            nrStartOverlay.DOFade(0f, 1f).SetDelay(.5f).OnComplete(() =>
            {
                nrStartOverlay.gameObject.SetActive(false);
            });
        }

        private void Reset()
        {
            activeView = defaultView;
            SetViewEnabled(defaultView, true);
            SetViewEnabled(recentsView, false);
            SetViewEnabled(newView, false);
            SetViewEnabled(browserView, false);
            SetViewEnabled(settingsView, false);
            SetViewEnabled(maudicaView, false);
            maudicaMenuButton.SetActive(false);
            defaultView.gameObject.SetActive(true);
            maudicaView.gameObject.SetActive(true);
            recentsView.gameObject.SetActive(true);
            newView.gameObject.SetActive(true);
            browserView.gameObject.SetActive(true);
            settingsView.gameObject.SetActive(true);
            volumePanel.SetActive(false);
        }

        private void SetViewEnabled(View menu, bool enabled)
        {
            menu.canvas.blocksRaycasts = enabled;
            menu.canvas.alpha = enabled ? 1f : 0f;
            if (enabled) menu.canvas.interactable = true;
        }

        public void Show()
        {
            OnActivated();
            gameObject.SetActive(true);
            if (!isInStartScreen)
            {
                volumePanel.SetActive(true);
                maudicaMenuButton.SetActive(true);
            }
            // canvas.DOFade(1f, .3f);
            canvas.alpha = 1f;
        }

        public void Hide()
        {
            canvas.alpha = 0f;
            if (isInStartScreen)
            {
                isInStartScreen = false;
            }
            Reset();
            OnDeactivated();
            /*
            Sequence animation = DOTween.Sequence();
            animation.Append(canvas.DOFade(0f, .5f));
            animation.OnComplete(() =>
            {
                gameObject.SetActive(false);
                if (isInStartScreen)
                {
                    isInStartScreen = false;
                }
                Reset();
                OnDeactivated();
            });
            animation.Play();
            */
        }

        public void OnOpenFile()
        {
            StartCoroutine(timeline.LoadAudicaFile(false, null, -1, OnLoaded));
            //editorInput.FigureOutIsInUI();
        }

        private void OnLoaded(bool success)
        {
            if (success)
            {
                Hide();
            }
        }

        public void OnOpenPressed()
        {
            ChangeView(defaultView);
        }

        public void OnNewPressed()
        {
            ChangeView(newView);
        }

        public void OnRecentsPressed()
        {
            ChangeView(recentsView);
        }

        public void OnMaudicaPressed()
        {
            ChangeView(maudicaView);
        }

        public void OnBrowserPressed()
        {
            ChangeView(browserView);
        }

        public void OnSettingsPressed()
        {
            ChangeView(settingsView);
        }

        private Sequence fadeOutAnimation;
        private Sequence fadeInAnimation;
        private void ChangeView(View newView) 
        {
            if (newView == activeView) return;
            if (fadeInAnimation != null) fadeInAnimation.Complete();
            if (fadeOutAnimation != null) fadeOutAnimation.Complete();
            Sequence animation = DOTween.Sequence();
            animation.Append(activeView.canvas.DOFade(0f, .3f));
            animation.OnComplete(() =>
            {
                newView.Show();
                var fadeInAnimation = DOTween.Sequence();
                fadeInAnimation.Append(newView.canvas.DOFade(1f, .3f));
                fadeInAnimation.OnComplete(() =>
                {
                    SetViewEnabled(activeView, false);
                    SetViewEnabled(newView, true);
                    activeView.Hide();
                    activeView = newView;
                });
                fadeInAnimation.Play();
                this.fadeInAnimation = fadeInAnimation;
            });
            this.fadeOutAnimation = animation;
            animation.Play();
        }

        protected override void OnEscPressed(InputAction.CallbackContext context)
        {
            if (Timeline.audicaLoaded)
            {
                Hide();
            }
        }
    }
}

