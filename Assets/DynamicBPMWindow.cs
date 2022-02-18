using System;
using DG.Tweening;
using NotReaper;
using TMPro;
using UnityEngine;
using NotReaper.Timing;
using NotReaper.Models;
using UnityEngine.InputSystem;
namespace NotReaper.UI.BPM
{
    public class DynamicBPMWindow : NRInputWithoutKeybinds
    {
        public TMP_InputField dynamicBpmInput;
        public TMP_InputField timeSignatureNumerator;
        public TMP_InputField timeSignatureDenomerator;

        [SerializeField] private Timeline timeline;

        private bool active = false;

        void Start()
        {
            Vector3 defaultPos;
            defaultPos.x = 0;
            defaultPos.y = 0;
            defaultPos.z = -10.0f;
            gameObject.GetComponent<RectTransform>().localPosition = defaultPos;
            gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
            gameObject.SetActive(false);
            dynamicBpmInput.GetComponent<TMP_InputField>().onSubmit.AddListener(delegate { AddDynamicBPM(); });
            timeSignatureNumerator.GetComponent<TMP_InputField>().onSubmit.AddListener(delegate { AddDynamicBPM(); });
            timeSignatureDenomerator.GetComponent<TMP_InputField>().onSubmit.AddListener(delegate { AddDynamicBPM(); });
        }

        public void ToggleWindow()
        {
            active = !active;
            if (active) Activate();
            else Deactivate();
        }

        public void Activate()
        {
            if (!timeline.paused)
            {
                timeline.TogglePlayback();
            }

            gameObject.GetComponent<CanvasGroup>().DOFade(1.0f, 0.3f);
            gameObject.SetActive(true);

            TempoChange tempo = timeline.GetTempoForTime(Timeline.time);
            dynamicBpmInput.GetComponent<TMP_InputField>().text = Constants.DisplayBPMFromMicrosecondsPerQuaterNote(tempo.microsecondsPerQuarterNote);
            timeSignatureNumerator.GetComponent<TMP_InputField>().text = tempo.timeSignature.Numerator.ToString();
            timeSignatureDenomerator.GetComponent<TMP_InputField>().text = tempo.timeSignature.Denominator.ToString();

            dynamicBpmInput.ActivateInputField();
            OnActivated();
        }

        public void Deactivate()
        {
            gameObject.GetComponent<CanvasGroup>().DOFade(0.0f, 0.3f);
            dynamicBpmInput.GetComponent<TMP_InputField>().ReleaseSelection();
            OnDeactivated();
            gameObject.SetActive(false);
        }

        public void AddDynamicBPM()
        {
            double dynamicBpm = 0.0f;
            TimeSignature timeSignature = new TimeSignature(4, 4);
            if (Double.TryParse(dynamicBpmInput.text, out dynamicBpm))
            {

                uint numer = 4;
                uint denom = 4;
                if (uint.TryParse(timeSignatureNumerator.text, out numer) && uint.TryParse(timeSignatureDenomerator.text, out denom))
                {
                    if (numer != 0 && denom != 0)
                    {
                        timeSignature = new TimeSignature(numer, denom);
                    }
                }

                timeline.SetBPM(Timeline.time, Constants.MicrosecondsPerQuarterNoteFromBPM(dynamicBpm), true, timeSignature.Numerator, timeSignature.Denominator);
                Deactivate();
            }
        }

        protected override void OnEscPressed(InputAction.CallbackContext context)
        {
            Deactivate();
        }
    }
}

