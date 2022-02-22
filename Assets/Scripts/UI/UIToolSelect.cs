using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotReaper.Models;
using NotReaper.UserInput;
using DG.Tweening;
using UnityEngine.UI;
using NotReaper.Tools;
using NotReaper.Tools.ChainBuilder;
using System;

namespace NotReaper.UI {


    public class UIToolSelect : MonoBehaviour 
    {

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

        [Space, Header("Buttons")]
        [SerializeField] private List<Button> buttons;

        [Space, Header("Extras")]
        [SerializeField] private GameObject selectedSlider;
        [SerializeField] private RectTransform sliderRTrans;

        [Space, Header("Configuration")]
        public float fadeAmount = 0.4f;

        private float fadeDuration;


        private float yOffset = -1.5f;
        private float indexOffset = 40f;

        [NRInject] private MappingInput mapping;
        [NRInject] private EditorKeybindController controller;

        private void Start()
        {
           fadeDuration = (float)NRSettings.config.UIFadeDuration;
        }

        public void SetInteractable(bool interactable)
        {
            foreach(var button in buttons)
            {
                button.interactable = interactable;
            }
        }

        public void SwitchHandColor()
        {
            EditorState.SelectHand(EditorState.Hand.Current == TargetHandType.Left ? TargetHandType.Right : TargetHandType.Left);
        }

        
        //Easings

        public void SelectPathbuilder()
        {
            controller.SelectPathbuilder(new UnityEngine.InputSystem.InputAction.CallbackContext());
        }

        public void SelectFromUI(string name) 
        {
            Debug.Log("CLICK!");
            name = char.ToUpper(name[0]) + name.Substring(1);
            Enum.TryParse(name, out TargetBehavior behavior);
            if (KeybindManager.Global.Modifier.IsCtrlDown())
            {
                mapping.SetTargetBehaviorAction(behavior);
            }
            else
            {
                EditorState.SelectBehavior(behavior);
            }
            return;
            switch (name) 
            {
                case "standard":
                    EditorState.SelectBehavior(TargetBehavior.Standard);      
                    break;
                case "hold":
                    EditorState.SelectBehavior(TargetBehavior.Sustain);
                    break;
                case "vertical":
                    EditorState.SelectBehavior(TargetBehavior.Vertical);
                    break;
                case "horizontal":
                    EditorState.SelectBehavior(TargetBehavior.Horizontal);
                    break;
                case "chainstart":
                    EditorState.SelectBehavior(TargetBehavior.ChainStart);
                    break;
                case "chainnode":
                    EditorState.SelectBehavior(TargetBehavior.ChainNode);
                    break;
                case "melee":
                    EditorState.SelectBehavior(TargetBehavior.Melee);
                    break;
                case "dragselect":
                    EditorState.SelectTool(EditorTool.DragSelect);
                    break;
                case "chainbuilder":
                    if (ChainBuilder.Instance.activated)
                    {
                        ChainBuilder.Instance.Activate(false);
                    }
                    EditorState.SelectTool(EditorTool.Pathbuilder);
                    break;
                default:
                    break;
            }
        }
        [NRListener]
        private void OnHandUpdated(TargetHandType _)
        {
            UpdateUIBehaviorSelected(EditorState.Behavior.Current);
            //UpdateUINoteSelected(EditorState.Tool.Current);
        }

        private void FadeoutBehaviors()
        {
            srstandard.DOColor(Color.white, fadeDuration);
            srhold.DOColor(Color.white, fadeDuration);
            srhorizontal.DOColor(Color.white, fadeDuration);
            srvertical.DOColor(Color.white, fadeDuration);
            srchainstart.DOColor(Color.white, fadeDuration);
            srchainnode.DOColor(Color.white, fadeDuration);
            srmelee.DOColor(Color.white, fadeDuration);

            srstandard.DOFade(fadeAmount, fadeDuration);
            srhold.DOFade(fadeAmount, fadeDuration);
            srhorizontal.DOFade(fadeAmount, fadeDuration);
            srvertical.DOFade(fadeAmount, fadeDuration);
            srchainstart.DOFade(fadeAmount, fadeDuration);
            srchainnode.DOFade(fadeAmount, fadeDuration);
            srmelee.DOFade(fadeAmount, fadeDuration);

            imgChainBuilder.DOFade(fadeAmount, fadeDuration);
        }

        [NRListener]
        private void UpdateUIBehaviorSelected(TargetBehavior behavior)
        {
            Color color = NRSettings.GetSelectedColor();
            FadeoutBehaviors();
            SpriteRenderer selected = null;
            switch (behavior)
            {
                case TargetBehavior.Standard:
                    DOSliderToNote(0);
                    selected = srstandard;
                    break;
                case TargetBehavior.Sustain:
                    DOSliderToNote(1);
                    selected = srhold;
                    break;
                case TargetBehavior.Horizontal:
                    DOSliderToNote(2);
                    selected = srhorizontal;
                    break;
                case TargetBehavior.Vertical:
                    DOSliderToNote(3);
                    selected = srvertical;
                    break;
                case TargetBehavior.ChainStart:
                    DOSliderToNote(4);
                    selected = srchainstart;
                    break;
                case TargetBehavior.ChainNode:
                    DOSliderToNote(5);
                    selected = srchainnode;
                    break;
                case TargetBehavior.Melee:
                    DOSliderToNote(6);
                    selected = srmelee;
                    break;
                default:
                    break;
            }
            if(selected != null)
            {
                selected.DOKill();
                selected.DOFade(1, fadeDuration);
                selected.DOColor(color, fadeDuration);
            }
        }

        [NRListener]
        private void UpdateUIToolSelected(EditorTool tool)
        {
            FadeoutBehaviors();
            selectedSlider.GetComponent<Image>().DOFade(0f, fadeDuration);
            switch (tool)
            {
                case EditorTool.ChainBuilder:
                    imgChainBuilder.DOKill();
                    imgChainBuilder.DOFade(1f, fadeDuration);
                    break;
                default:
                    break;
            }
        }

        /*
        [NRListener]
        private void UpdateUINoteSelected(EditorTool type) {
            Color color = NRSettings.GetSelectedColor();
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

                case EditorTool.Sustain:
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
        */



        private void DOSliderToNote(int index) {
            float finalY = yOffset - (index * indexOffset);

           //selectedSlider.transform.(new Vector3(0f, finalY, 0f), 1f).SetEase(Ease.InOutCubic);
           DOTween.To(SetSelectedSliderPosY, sliderRTrans.anchoredPosition.y, finalY, 0.3f).SetEase(Ease.InOutCubic);

           selectedSlider.GetComponent<Image>().DOColor(NRSettings.GetSelectedColor(), 1f);
            
        }

        private void SetSelectedSliderPosY(float pos) {
            sliderRTrans.anchoredPosition = new Vector3(29.5f, pos, 0);
        }


    }






}