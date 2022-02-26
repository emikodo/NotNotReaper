﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.InputSystem;
using NotReaper.Timing;
using System;

namespace NotReaper.BpmAlign
{
    public class BPMDragView : NRMenu
    {
        [Header("References")]
        [SerializeField] private BPMDragAlign dragAlign;
        [Space, Header("UI Elements")]
        [SerializeField] private TMP_InputField bpmInput;
        [SerializeField] private TMP_InputField nominatorInput;
        [SerializeField] private TMP_InputField denominatorInput;
        [SerializeField] private TMP_InputField beatLengthInput;
        [Space, Header("Views")]
        [SerializeField] private CanvasGroup bpmView;
        [SerializeField] private CanvasGroup trimView;
        private CanvasGroup canvas;

        private float bpm;
        private uint numerator;
        private uint denominator;
        [NRInject] private Timeline timeline;

        protected override void Awake()
        {
            base.Awake();
            canvas = GetComponent<CanvasGroup>();
        }

        public void Show()
        {
            OnActivated();
            canvas.DOFade(1f, .3f);
            dragAlign.enabled = true;
            canvas.blocksRaycasts = true;
            bpm = (float)timeline.GetBpmFromTime(new QNT_Timestamp(0));
            bpmInput.text = bpm.ToString();
        }

        public void Hide()
        {
            canvas.DOFade(0f, .3f);
            dragAlign.enabled = false;
            canvas.blocksRaycasts = false;
            OnDeactivated();
        }

        public void ApplyBPM()
        {
            float.TryParse(bpmInput.text, out bpm);
            if (bpm == 0f) bpm = 150f;
            uint.TryParse(nominatorInput.text, out numerator);
            uint.TryParse(denominatorInput.text, out denominator);

            if (numerator == 0) numerator = 4;
            if (denominator == 0) denominator = 4;

            timeline.SetBPM(new QNT_Timestamp(0), Constants.MicrosecondsPerQuarterNoteFromBPM(bpm), true, numerator, denominator);
        }

        private void ChangeView(CanvasGroup from, CanvasGroup to)
        {
            var animation = DOTween.Sequence();
            animation.Append(from.DOFade(0f, .3f));
            animation.Append(to.DOFade(1f, .3f));
            animation.Play();
            from.blocksRaycasts = false;
            to.blocksRaycasts = true;
        }

        public void GoToTrimAudio()
        {
            dragAlign.ModifyAudio();
            dragAlign.enabled = false;
            ChangeView(bpmView, trimView);
        }

        public void GoToBpm()
        {
            ChangeView(trimView, bpmView);
            dragAlign.enabled = true;
        }

        public void Finish()
        {
            Hide();
        }

        public void AddSilence()
        {
            var duration = GetTimeFromLabels();
            if (duration == null)
            {
                return;
            }

            if (duration.Value.tick < 0)
            {
                return;
            }

            timeline.RemoveOrAddTimeToAudio(duration.Value);
        }

        public void RemoveSilence()
        {
            var duration = GetTimeFromLabels();
            if (duration == null)
            {
                return;
            }

            timeline.RemoveOrAddTimeToAudio(new Relative_QNT(-duration.Value.tick));
        }

        private Relative_QNT? GetTimeFromLabels()
        {
            float beatValue;
            if (float.TryParse(beatLengthInput.text, out beatValue))
            {
                if (beatValue > 0.0f)
                {
                    return new Relative_QNT((long)Math.Round(Constants.PulsesPerQuarterNote * beatValue));
                }
            }

            return null;
        }

        protected override void OnEscPressed(InputAction.CallbackContext context)
        {
            
        }
    }
}

