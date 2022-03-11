using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using NotReaper.Audio;
using UnityEngine.InputSystem;

namespace NotReaper.UI.Components
{
    [ExecuteAlways]
    public class NRSlider : MonoBehaviour
    {
        [Header("Skin")]
        [SerializeField] private NRSliderData skin;

        [Space, Header("Fill Bar")]
        [SerializeField] private Theme fillTheme = Theme.fillColor;
        // [SerializeField] private Theme sliderBGTheme = Theme.sliderBGColor;

        [SerializeField, HideInInspector] private Image sliderBG;
        [SerializeField, HideInInspector] private GameObject fillArea;
        [SerializeField, HideInInspector] private Image fill;

        private bool initialized = false;

        private void Start()
        {
            if (Application.isPlaying)
            {
                UpdateSlider();
            }
        }
        public void Initialize()
        {
            initialized = true;
            sliderBG = transform.GetChild(0).GetComponent<Image>();
            fillArea = transform.GetChild(1).gameObject;
            fill = fillArea.transform.GetChild(0).GetComponent<Image>();
        }

        private void OnValidate()
        {
            if (Application.isPlaying) return;

            if (!initialized)
            {
                Initialize();
            }
        }

        public void UpdateSlider()
        {

            sliderBG.color = skin.sliderBGColor;

            fill.color = fillTheme == Theme.LeftHand ? NRSettings.config.leftColor : fillTheme == Theme.RightHand ? NRSettings.config.rightColor : NRSettings.config.selectedHighlightColor;

        }

        public enum Theme
        {
            fillColor,
            sliderBGColor,
            LeftHand,
            RightHand,
        }
    }
}

