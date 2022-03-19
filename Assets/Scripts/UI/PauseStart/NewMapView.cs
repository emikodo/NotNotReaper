﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NotReaper.BpmAlign;
using TMPro;
using NotReaper.Notifications;
using NotReaper.UI.Components;

namespace NotReaper.UI
{
    public class NewMapView : View
    {
        [Header("References")]
        [SerializeField] private NewMapManager manager;
        [SerializeField] private GameObject skipAlignmentButton;
        [Space, Header("Views")]
        [SerializeField] private CanvasGroup metadataView;
        [SerializeField] private CanvasGroup genreView;
        [Space, Header("Input Group")]
        [SerializeField] private NRIconInputGroup inputGroup;

        [NRInject] private NewPauseMenu pauseMenu;
        private CanvasGroup activeView, previousView;
        [NRInject] private BPMDragView bpmView;
        private bool skipAlignment;
        private void Start()
        {
            inputGroup.enabled = false;
            activeView = metadataView;
            genreView.blocksRaycasts = false;
            skipAlignmentButton.SetActive(false);
            bool skipUnlocked = PlayerPrefs.GetInt("s_align", 0) == 1;
            skipAlignmentButton.SetActive(skipUnlocked);
        }
        public override void Hide()
        {
            inputGroup.enabled = false;
        }

        public override void Show()
        {
            inputGroup.enabled = true;
            manager.UpdateUIVales();
        }

        public void ContinueToGenre()
        {
            manager.ApplyValues();
            if (!manager.CheckAllUIFilled())
            {
                NotificationCenter.SendNotification("Please fill out all data.", NotificationType.Warning);
                return;
            }
            ChangeView(metadataView, genreView);
        }

        public void GenerateOgg(bool skipAlignment)
        {
            this.skipAlignment = skipAlignment;
            manager.GenerateOgg();
        }

        internal void ContinueToBPM()
        {
            pauseMenu.Hide();
            if (!skipAlignment)
            {
                bpmView.Show();
            }
        }

        private void ChangeView(CanvasGroup from, CanvasGroup to)
        {
            from.blocksRaycasts = false;
            to.blocksRaycasts = true;
            Sequence animation = DOTween.Sequence();
            animation.Append(from.DOFade(0f, .3f));
            animation.Append(to.DOFade(1f, .3f));
            previousView = from;
            activeView = to;
        }

        public void GoBack()
        {
            ChangeView(activeView, previousView);
        }
    }
}
