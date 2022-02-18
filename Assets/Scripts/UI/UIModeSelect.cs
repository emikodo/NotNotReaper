using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NotReaper.Timing;
using NotReaper.UserInput;
using UnityEngine;
using UnityEngine.UI;
using NotReaper.Models;

namespace NotReaper.UI {

    public class UIModeSelect : MonoBehaviour {

        public UIInput uiInput;
        public GameObject slider;
        public RectTransform sliderRTrans;

        public UIMetadata uIMetadata;
        public UITiming uITiming;
        public UISettings uISettings;
        public float startOffset = 80f;
        public float indexOffset = 66.6f;

    
        public void SelectFromUI(string mode) {
            switch (mode) {
                case "compose":
                    EditorState.SelectMode(EditorMode.Compose);
                    break;
                case "metadata":
                    EditorState.SelectMode(EditorMode.Metadata);
                    break;
                case "settings":
                    EditorState.SelectMode(EditorMode.Settings);
                    break;
                case "timing":
                    EditorState.SelectMode(EditorMode.Timing);
                    break;
                
            }

        }


        public void UpdateUI(EditorMode mode) {
            switch (mode) {
                
                case EditorMode.Compose:
                    

                    DOSliderToButton(0, NRSettings.config.leftColor);

                    uIMetadata.StopAllCoroutines();
                    StartCoroutine(uIMetadata.FadeOut());

                    uITiming.StopAllCoroutines();
                    StartCoroutine(uITiming.FadeOut());
                    
                    uISettings.Deactivate();
                    

                    break;

                case EditorMode.Metadata:
                    uIMetadata.gameObject.SetActive(true);
                    DOSliderToButton(1, NRSettings.config.rightColor);

                    uIMetadata.StopAllCoroutines();
                    StartCoroutine(uIMetadata.FadeIn());

                    uITiming.StopAllCoroutines();
                    StartCoroutine(uITiming.FadeOut());
                    
                    uISettings.Deactivate();
                    




                    break;
                
                case EditorMode.Timing:
                    uITiming.gameObject.SetActive(true);

                    DOSliderToButton(2, NRSettings.config.leftColor);

                    uITiming.StopAllCoroutines();
                    StartCoroutine(uITiming.FadeIn());

                    uIMetadata.StopAllCoroutines();
                    StartCoroutine(uIMetadata.FadeOut());
                    
                    uISettings.Deactivate();

                    break;

                case EditorMode.Settings:

                    DOSliderToButton(2, Color.white);

                    uIMetadata.StopAllCoroutines();
                    StartCoroutine(uIMetadata.FadeOut());

                    uITiming.StopAllCoroutines();
                    StartCoroutine(uITiming.FadeOut());
                    
                    uISettings.Activate();
                    
                    

                    break;

  
            }
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