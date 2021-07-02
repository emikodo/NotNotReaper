using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotReaper.Models;
using NotReaper.UserInput;
using DG.Tweening;
using UnityEngine.UI;
using NotReaper.Tools;

namespace NotReaper.UI {


    public class UIToolSelect : MonoBehaviour {

        
        public EditorInput editorInput;



        [Header("Tool Sprites")]
        [SerializeField] private SpriteRenderer srstandard;
        [SerializeField] private SpriteRenderer srhold;
        [SerializeField] private SpriteRenderer srhorizontal;
        [SerializeField] private SpriteRenderer srvertical;
        [SerializeField] private SpriteRenderer srchainstart;
        [SerializeField] private SpriteRenderer srchainnode;
        [SerializeField] private SpriteRenderer srmelee;

        [SerializeField] private Image imgDragSelect;
        [SerializeField] private Image imgChainBuilder;



        [Header("Extras")]
        [SerializeField] private GameObject selectedSlider;
        [SerializeField] private RectTransform sliderRTrans;

        [Header("Configuration")]
        public float fadeAmount = 0.4f;
        


        private float yOffset = -1.5f;
        private float indexOffset = 40f;

        
        //Easings


        public void SelectFromUI(string name) {
            TargetBehavior behavior = TargetBehavior.None;
            switch (name) {
                case "standard":
                    behavior = TargetBehavior.Standard;
                    editorInput.SelectTool(EditorTool.Standard);      
                    break;
                case "hold":
                    behavior = TargetBehavior.Hold;
                    editorInput.SelectTool(EditorTool.Hold);
                    break;
                case "vertical":
                    behavior = TargetBehavior.Vertical;
                    editorInput.SelectTool(EditorTool.Vertical);
                    break;
                case "horizontal":
                    behavior = TargetBehavior.Horizontal;
                    editorInput.SelectTool(EditorTool.Horizontal);
                    break;
                case "chainstart":
                    behavior = TargetBehavior.ChainStart;
                    editorInput.SelectTool(EditorTool.ChainStart);
                    break;
                case "chainnode":
                    behavior = TargetBehavior.Chain;
                    editorInput.SelectTool(EditorTool.ChainNode);
                    break;
                case "melee":
                    behavior = TargetBehavior.Melee;
                    editorInput.SelectTool(EditorTool.Melee);
                    break;
                case "dragselect":
                    editorInput.SelectTool(EditorTool.DragSelect);
                    break;
                case "chainbuilder":
                    editorInput.SelectTool(EditorTool.ChainBuilder);
                    break;
                default:
                    break;
            }

            if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                if(behavior != TargetBehavior.None)
                {
                    DragSelect.Instance.SetBehaviorAction(behavior);
                }
            }
        }

        public void UpdateUINoteSelected(EditorTool type) {

            Color color = EditorInput.GetSelectedColor();
            float fadeDuration = (float)NRSettings.config.UIFadeDuration;         

            switch (type) {
                case EditorTool.Standard:
                    DOSliderToNote(0);
                    //selectedSlider.GetComponent<Image>().DOFade(1f, fadeDuration);

                    srstandard.DOFade(1, fadeDuration);
                    srstandard.DOColor(color, fadeDuration);

                    srhold.DOColor(Color.white, fadeDuration);
                    srhorizontal.DOColor(Color.white, fadeDuration);
                    srvertical.DOColor(Color.white, fadeDuration);
                    srchainstart.DOColor(Color.white, fadeDuration);
                    srchainnode.DOColor(Color.white, fadeDuration);
                    srmelee.DOColor(Color.white, fadeDuration);

                    srhold.DOFade(fadeAmount, fadeDuration);
                    srhorizontal.DOFade(fadeAmount, fadeDuration);
                    srvertical.DOFade(fadeAmount, fadeDuration);
                    srchainstart.DOFade(fadeAmount, fadeDuration);
                    srchainnode.DOFade(fadeAmount, fadeDuration);
                    srmelee.DOFade(fadeAmount, fadeDuration);

                    imgChainBuilder.DOFade(fadeAmount, fadeDuration);
                    //imgDragSelect.DOFade(fadeAmount, fadeDuration);
                
                    break;

                case EditorTool.Hold:
                    DOSliderToNote(1);
                    //selectedSlider.GetComponent<Image>().DOFade(1f, fadeDuration);

                    srhold.DOFade(1, fadeDuration);
                    srhold.DOColor(color, fadeDuration);

                    srstandard.DOColor(Color.white, fadeDuration);
                    srhorizontal.DOColor(Color.white, fadeDuration);
                    srvertical.DOColor(Color.white, fadeDuration);
                    srchainstart.DOColor(Color.white, fadeDuration);
                    srchainnode.DOColor(Color.white, fadeDuration);
                    srmelee.DOColor(Color.white, fadeDuration);
                    
                    srstandard.DOFade(fadeAmount, fadeDuration);
                    srhorizontal.DOFade(fadeAmount, fadeDuration);
                    srvertical.DOFade(fadeAmount, fadeDuration);
                    srchainstart.DOFade(fadeAmount, fadeDuration);
                    srchainnode.DOFade(fadeAmount, fadeDuration);
                    srmelee.DOFade(fadeAmount, fadeDuration);

                    imgChainBuilder.DOFade(fadeAmount, fadeDuration);
                    //imgDragSelect.DOFade(fadeAmount, fadeDuration);

                    break;

                case EditorTool.Horizontal:
                    DOSliderToNote(2);
                    //selectedSlider.GetComponent<Image>().DOFade(1f, fadeDuration);

                    srhorizontal.DOFade(1, fadeDuration);
                    srhorizontal.DOColor(color, fadeDuration);

                    srstandard.DOColor(Color.white, fadeDuration);
                    srhold.DOColor(Color.white, fadeDuration);
                    srvertical.DOColor(Color.white, fadeDuration);
                    srchainstart.DOColor(Color.white, fadeDuration);
                    srchainnode.DOColor(Color.white, fadeDuration);
                    srmelee.DOColor(Color.white, fadeDuration);
                    
                    srstandard.DOFade(fadeAmount, fadeDuration);
                    srhold.DOFade(fadeAmount, fadeDuration);
                    srvertical.DOFade(fadeAmount, fadeDuration);
                    srchainstart.DOFade(fadeAmount, fadeDuration);
                    srchainnode.DOFade(fadeAmount, fadeDuration);
                    srmelee.DOFade(fadeAmount, fadeDuration);

                    imgChainBuilder.DOFade(fadeAmount, fadeDuration);
                    //imgDragSelect.DOFade(fadeAmount, fadeDuration);

                    break;

                case EditorTool.Vertical:
                    DOSliderToNote(3);
                    //selectedSlider.GetComponent<Image>().DOFade(1f, fadeDuration);

                    srvertical.DOFade(1, fadeDuration);
                    srvertical.DOColor(color, fadeDuration);

                    srstandard.DOColor(Color.white, fadeDuration);
                    srhold.DOColor(Color.white, fadeDuration);
                    srhorizontal.DOColor(Color.white, fadeDuration);
                    srchainstart.DOColor(Color.white, fadeDuration);
                    srchainnode.DOColor(Color.white, fadeDuration);
                    srmelee.DOColor(Color.white, fadeDuration);
                    
                    srstandard.DOFade(fadeAmount, fadeDuration);
                    srhold.DOFade(fadeAmount, fadeDuration);
                    srhorizontal.DOFade(fadeAmount, fadeDuration);
                    srchainstart.DOFade(fadeAmount, fadeDuration);
                    srchainnode.DOFade(fadeAmount, fadeDuration);
                    srmelee.DOFade(fadeAmount, fadeDuration);

                    imgChainBuilder.DOFade(fadeAmount, fadeDuration);
                    //imgDragSelect.DOFade(fadeAmount, fadeDuration);

                    break;
                case EditorTool.ChainStart:
                    DOSliderToNote(4);
                    //selectedSlider.GetComponent<Image>().DOFade(1f, fadeDuration);

                    srchainstart.DOFade(1, fadeDuration);
                    srchainstart.DOColor(color, fadeDuration);

                    srstandard.DOColor(Color.white, fadeDuration);
                    srhold.DOColor(Color.white, fadeDuration);
                    srhorizontal.DOColor(Color.white, fadeDuration);
                    srvertical.DOColor(Color.white, fadeDuration);
                    srchainnode.DOColor(Color.white, fadeDuration);
                    srmelee.DOColor(Color.white, fadeDuration);
                    
                    srstandard.DOFade(fadeAmount, fadeDuration);
                    srhold.DOFade(fadeAmount, fadeDuration);
                    srhorizontal.DOFade(fadeAmount, fadeDuration);
                    srvertical.DOFade(fadeAmount, fadeDuration);
                    srchainnode.DOFade(fadeAmount, fadeDuration);
                    srmelee.DOFade(fadeAmount, fadeDuration);

                    imgChainBuilder.DOFade(fadeAmount, fadeDuration);
                    //imgDragSelect.DOFade(fadeAmount, fadeDuration);

                    break;
                case EditorTool.ChainNode:
                    DOSliderToNote(5);
                    //selectedSlider.GetComponent<Image>().DOFade(1f, fadeDuration);

                    srchainnode.DOFade(1, fadeDuration);
                    srchainnode.DOColor(color, fadeDuration);

                    srstandard.DOColor(Color.white, fadeDuration);
                    srhold.DOColor(Color.white, fadeDuration);
                    srhorizontal.DOColor(Color.white, fadeDuration);
                    srvertical.DOColor(Color.white, fadeDuration);
                    srchainstart.DOColor(Color.white, fadeDuration);
                    srmelee.DOColor(Color.white, fadeDuration);
                    
                    srstandard.DOFade(fadeAmount, fadeDuration);
                    srhold.DOFade(fadeAmount, fadeDuration);
                    srhorizontal.DOFade(fadeAmount, fadeDuration);
                    srvertical.DOFade(fadeAmount, fadeDuration);
                    srchainstart.DOFade(fadeAmount, fadeDuration);
                    srmelee.DOFade(fadeAmount, fadeDuration);

                    imgChainBuilder.DOFade(fadeAmount, fadeDuration);
                    //imgDragSelect.DOFade(fadeAmount, fadeDuration);

                    break;
                case EditorTool.Melee:

                    DOSliderToNote(6);
                    //selectedSlider.GetComponent<Image>().DOFade(1f, fadeDuration);
                    

                    srmelee.DOFade(1, fadeDuration);
                    srmelee.DOColor(color, fadeDuration);

                    srstandard.DOColor(Color.white, fadeDuration);
                    srhold.DOColor(Color.white, fadeDuration);
                    srhorizontal.DOColor(Color.white, fadeDuration);
                    srvertical.DOColor(Color.white, fadeDuration);
                    srchainstart.DOColor(Color.white, fadeDuration);
                    srchainnode.DOColor(Color.white, fadeDuration);
                    
                    srstandard.DOFade(fadeAmount, fadeDuration);
                    srhold.DOFade(fadeAmount, fadeDuration);
                    srhorizontal.DOFade(fadeAmount, fadeDuration);
                    srvertical.DOFade(fadeAmount, fadeDuration);
                    srchainstart.DOFade(fadeAmount, fadeDuration);
                    srchainnode.DOFade(fadeAmount, fadeDuration);

                    imgChainBuilder.DOFade(fadeAmount, fadeDuration);
                    //imgDragSelect.DOFade(fadeAmount, fadeDuration);

                    break;


                    //The other editor tools that aren't on the sidebar
                case EditorTool.DragSelect:
                    //DOSliderToNote(6, Color.white);

                    //Fade in the button
                    //imgDragSelect.DOFade(1f, fadeDuration);


                    //Fade out the slider
                    selectedSlider.GetComponent<Image>().DOFade(0f, fadeDuration);

                    //Reset all note toolbar colors
                    srstandard.DOColor(Color.white, fadeDuration);
                    srhold.DOColor(Color.white, fadeDuration);
                    srhorizontal.DOColor(Color.white, fadeDuration);
                    srvertical.DOColor(Color.white, fadeDuration);
                    srchainstart.DOColor(Color.white, fadeDuration);
                    srchainnode.DOColor(Color.white, fadeDuration);
                    srmelee.DOColor(Color.white, fadeDuration);
                    
                    //Fade them out
                    srstandard.DOFade(fadeAmount, fadeDuration);
                    srhold.DOFade(fadeAmount, fadeDuration);
                    srhorizontal.DOFade(fadeAmount, fadeDuration);
                    srvertical.DOFade(fadeAmount, fadeDuration);
                    srchainstart.DOFade(fadeAmount, fadeDuration);
                    srchainnode.DOFade(fadeAmount, fadeDuration);
                    srmelee.DOFade(fadeAmount, fadeDuration);

                    imgChainBuilder.DOFade(fadeAmount, fadeDuration);

                    

                    break;

                
                case EditorTool.ChainBuilder:
                    //DOSliderToNote(6, Color.white);

                    //Fade in the button
                    imgChainBuilder.DOFade(1f, fadeDuration);


                    //Fade out the slider
                    selectedSlider.GetComponent<Image>().DOFade(0f, fadeDuration);

                    //Reset all note toolbar colors
                    srstandard.DOColor(Color.white, fadeDuration);
                    srhold.DOColor(Color.white, fadeDuration);
                    srhorizontal.DOColor(Color.white, fadeDuration);
                    srvertical.DOColor(Color.white, fadeDuration);
                    srchainstart.DOColor(Color.white, fadeDuration);
                    srchainnode.DOColor(Color.white, fadeDuration);
                    srmelee.DOColor(Color.white, fadeDuration);
                    
                    //Fade them out
                    srstandard.DOFade(fadeAmount, fadeDuration);
                    srhold.DOFade(fadeAmount, fadeDuration);
                    srhorizontal.DOFade(fadeAmount, fadeDuration);
                    srvertical.DOFade(fadeAmount, fadeDuration);
                    srchainstart.DOFade(fadeAmount, fadeDuration);
                    srchainnode.DOFade(fadeAmount, fadeDuration);
                    srmelee.DOFade(fadeAmount, fadeDuration);

                    //imgDragSelect.DOFade(fadeAmount, fadeDuration);

                    

                    break;

            }

        }




        private void DOSliderToNote(int index) {
            float finalY = yOffset - (index * indexOffset);

           //selectedSlider.transform.(new Vector3(0f, finalY, 0f), 1f).SetEase(Ease.InOutCubic);
           DOTween.To(SetSelectedSliderPosY, sliderRTrans.anchoredPosition.y, finalY, 0.3f).SetEase(Ease.InOutCubic);

           selectedSlider.GetComponent<Image>().DOColor(EditorInput.GetSelectedColor(), 1f);
            
        }

        private void SetSelectedSliderPosY(float pos) {
            sliderRTrans.anchoredPosition = new Vector3(29.5f, pos, 0);
        }


    }






}