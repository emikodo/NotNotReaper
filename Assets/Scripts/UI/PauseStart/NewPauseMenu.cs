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
    public class NewPauseMenu : NRInputWithoutKeybinds
    {
        [NRInject] private Timeline timeline;

        private CanvasGroup canvas;
        [Header("References")]
        [SerializeField] private GameObject volumePanel;
        [SerializeField] private ScrollRect scroll;
        [Space, Header("Views")]
        [SerializeField] private View defaultView;
        [SerializeField] private View recentsView;
        [SerializeField] private View newView;
        [SerializeField] private View browserView;
        [SerializeField] private View settingsView;
        [Space, Header("Maudica")]
        [SerializeField] private GameObject startScreenView;
        [SerializeField] private GameObject pauseView;
        [SerializeField] private GameObject hintPanel;
        [SerializeField] private GameObject curationPanel;
        [SerializeField] private GameObject votePanel;

        private View activeView;

        private bool isInStartScreen = true;

        protected override void Awake()
        {
            base.Awake();

            canvas = GetComponent<CanvasGroup>();
            defaultView.Initialize();
            recentsView.Initialize();
            newView.Initialize();
            browserView.Initialize();
            settingsView.Initialize();
            Reset();
            transform.localPosition = Vector3.zero;
            Show();
        }

        private void Reset()
        {
            activeView = defaultView;
            SetViewEnabled(defaultView, true);
            SetViewEnabled(recentsView, false);
            SetViewEnabled(newView, false);
            SetViewEnabled(browserView, false);
            SetViewEnabled(settingsView, false);
            defaultView.gameObject.SetActive(true);
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
            //canvas.gameObject.SetActive(enabled);
        }

        public void Show()
        {
            OnActivated();
            gameObject.SetActive(true);
            if (!isInStartScreen)
            {
                volumePanel.SetActive(true);
                startScreenView.SetActive(false);
                pauseView.SetActive(true);
                if (MaudicaHandler.HasToken)
                {
                    hintPanel.SetActive(false);
                    votePanel.SetActive(true);
                }
                else
                {
                    hintPanel.SetActive(true);
                    votePanel.SetActive(false);
                }
            }
            canvas.DOFade(1f, .3f);
        }

        public void Hide()
        {
            Sequence animation = DOTween.Sequence();
            animation.Append(canvas.DOFade(0f, .3f));
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
        }

        public void OnOpenFile()
        {
            if (timeline.LoadAudicaFile(false))
            {
                Hide();
            }
            //editorInput.FigureOutIsInUI();
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

        public void OnBrowserPressed()
        {
            ChangeView(browserView);
        }

        public void OnSettingsPressed()
        {
            ChangeView(settingsView);
        }


        private void ChangeView(View newView) 
        {
            if (newView == activeView) return;
            //newCanvas.gameObject.SetActive(true);
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
            });

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

