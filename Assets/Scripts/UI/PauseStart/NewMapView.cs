using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NotReaper.BpmAlign;
using TMPro;

namespace NotReaper.UI
{
    public class NewMapView : View
    {
        [Header("References")]
        [SerializeField] private NewMapManager manager;
        [Space, Header("Views")]
        [SerializeField] private CanvasGroup metadataView;
        [SerializeField] private CanvasGroup genreView;

        [NRInject] private NewPauseMenu pauseMenu;
        private CanvasGroup activeView, previousView;
        [NRInject] private BPMDragView bpmView;
        private void Start()
        {
            activeView = metadataView;
            genreView.blocksRaycasts = false;
        }
        public override void Hide()
        {

        }

        public override void Show()
        {
            manager.UpdateUIVales();
        }

        public void ContinueToGenre()
        {
            ChangeView(metadataView, genreView);
        }

        public void GenerateOgg()
        {
            manager.GenerateOgg();
        }

        internal void ContinueToBPM()
        {
            pauseMenu.Hide();
            bpmView.Show();
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
