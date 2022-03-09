using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NotReaper.Timing;
using NotReaper.UserInput;
using UnityEngine;
using UnityEngine.UI;
using NotReaper.Models;
using NotReaper.Statistics;
namespace NotReaper.UI {

    public class UIModeSelect : MonoBehaviour {

        [NRInject] private UIInput uiInput;
        [NRInject] private MappingInput mappingInput;
        [NRInject] private StatisticsUI stats;
        public GameObject slider;
        public RectTransform sliderRTrans;
        public List<GameObject> buttons = new();
        [NRInject] private UIMetadata uIMetadata;
        [NRInject] private UITiming uITiming;
        public UISettings uISettings;
        public float startOffset = 80f;
        public float indexOffset = 66.6f;      

        public void EnableButtons(bool enable)
        {
            foreach(var button in buttons)
            {
                button.SetActive(enable);
            }
        }

        public void OpenSongInfo()
        {
            EditorState.SelectMode(EditorMode.Metadata);
        }

        public void OpenHelp()
        {
            uiInput.ShowHelpWindow();
        }

        public void OpenTiming()
        {
            uiInput.ShowTimingPointsWindow();
        }

        public void OpenModifiers()
        {
            mappingInput.ToggleModifiers();
        }

        public void OpenReviews()
        {
            uiInput.ShowReviewWindow();
        }

        public void OpenStatistics()
        {
            stats.Show();
        }


        public void UpdateUI(EditorMode mode) {
            if(mode == EditorMode.Metadata)
            {
                uIMetadata.Show();
            }
            else if(mode == EditorMode.Compose)
            {
                uIMetadata.Hide();
            }
            /*
            switch (mode) {
                
                case EditorMode.Compose:
                    

                    DOSliderToButton(0, NRSettings.config.leftColor);

                    uIMetadata.StopAllCoroutines();
                    StartCoroutine(uIMetadata.FadeOut());

                    uITiming.StopAllCoroutines();
                    StartCoroutine(uITiming.FadeOut());
                    

                    break;

                case EditorMode.Metadata:
                    uIMetadata.gameObject.SetActive(true);
                    DOSliderToButton(1, NRSettings.config.rightColor);

                    uIMetadata.StopAllCoroutines();
                    StartCoroutine(uIMetadata.FadeIn());

                    uITiming.StopAllCoroutines();
                    StartCoroutine(uITiming.FadeOut());
                    




                    break;
                
                case EditorMode.Timing:
                    uITiming.gameObject.SetActive(true);

                    DOSliderToButton(2, NRSettings.config.leftColor);

                    uITiming.StopAllCoroutines();
                    StartCoroutine(uITiming.FadeIn());

                    uIMetadata.StopAllCoroutines();
                    StartCoroutine(uIMetadata.FadeOut());

                    break;

                case EditorMode.Settings:

                    DOSliderToButton(2, Color.white);

                    uIMetadata.StopAllCoroutines();
                    StartCoroutine(uIMetadata.FadeOut());

                    uITiming.StopAllCoroutines();
                    StartCoroutine(uITiming.FadeOut());
                    
                    

                    break;

  
            }
            */
        }


 




        private void DOSliderToButton(int index, Color colorChange) {
           float final = startOffset + (index * indexOffset);
           

           //selectedSlider.transform.(new Vector3(0f, finalY, 0f), 1f).SetEase(Ease.InOutCubic);
           DOTween.To(SetSliderPosX, sliderRTrans.anchoredPosition.x, final, 0.3f).SetEase(Ease.InOutCubic);

           slider.GetComponent<Image>().DOColor(colorChange, 0.3f);
            
        }

        private void SetSliderPosX(float pos) {
            sliderRTrans.anchoredPosition = new Vector3(pos, -10.75f, 0);
        }


    }

}