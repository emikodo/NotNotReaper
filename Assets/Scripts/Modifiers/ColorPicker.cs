﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace NotReaper.Modifier
{
    public class ColorPicker : MonoBehaviour
    {
        public float value
        {
            set
            {
                var slider = hueSlider.GetComponent<Slider>();
                slider.value = value;
                inputFieldHue.GetComponent<TMP_InputField>().text = value.ToString("F2");
            }
        }

        public GameObject inputFieldHue;
        public GameObject inputFieldSaturation;
        public GameObject hueSlider;
        public GameObject saturationSlider;
        public SpriteRenderer colorField;
        public LabelSetter labelSetter;
        public event Action<float> OnValueChanged = delegate { };


        // Start is called before the first frame update
        void Start()
        {
            var slider = hueSlider.GetComponent<Slider>();
            slider.onValueChanged.AddListener(delegate { SliderValueChangeCheck(); });
            inputFieldHue.GetComponent<TMP_InputField>().text = slider.value.ToString("F2");
            inputFieldHue.GetComponent<TMP_InputField>().onEndEdit.AddListener(delegate { TextValueChangeCheck(); });

            slider = saturationSlider.GetComponent<Slider>();
            slider.onValueChanged.AddListener(delegate { SliderValueChangeCheck(); });
            inputFieldSaturation.GetComponent<TMP_InputField>().text = slider.value.ToString("F2");
            inputFieldSaturation.GetComponent<TMP_InputField>().onEndEdit.AddListener(delegate { TextValueChangeCheck(); });
        }

        public void UpdateValues()
        {
            //inputFieldHue.GetComponent<TMP_InputField>().text = hueSlider.GetComponent<Slider>().value.ToString("F2");
            //inputFieldSaturation.GetComponent<TMP_InputField>().text = saturationSlider.GetComponent<Slider>().value.ToString("F2");
            inputFieldHue.GetComponent<TMP_InputField>().SetTextWithoutNotify(hueSlider.GetComponent<Slider>().value.ToString("F2"));
            inputFieldSaturation.GetComponent<TMP_InputField>().SetTextWithoutNotify(saturationSlider.GetComponent<Slider>().value.ToString("F2"));
        }

        public void SliderValueChangeCheck()
        {
            var sliderHue = hueSlider.GetComponent<Slider>();
            float valueHue = sliderHue.value;
            var sliderSaturation = saturationSlider.GetComponent<Slider>();
            float valueSaturation = sliderSaturation.value;

            inputFieldHue.GetComponent<TMP_InputField>().text = valueHue.ToString("F2");
            inputFieldSaturation.GetComponent<TMP_InputField>().text = valueSaturation.ToString("F2");
            if(labelSetter != null)
            {
                if (!labelSetter.IsColorPicker())
                {
                    //float[] col = labelSetter.GetSkyboxColor();
                    labelSetter.UpdateSkyboxColor();
                    /*if (isLeftHandColorPicker)
                    {
                        colorField.color = new Color(col[0], col[1], col[2]);
                    }
                    else
                    {
                        labelSetter.color
                    }*/
                    return;
                }
            }
            colorField.color = Color.HSVToRGB(valueHue, valueSaturation, 1f);
            // OnValueChanged(value);
        }

        public void TextValueChangeCheck()
        {
            var textHue = inputFieldHue.GetComponent<TMP_InputField>().text;
            var textSaturation = inputFieldSaturation.GetComponent<TMP_InputField>().text;

            float newValueHue = hueSlider.GetComponent<Slider>().value;
            float newValueSaturation = saturationSlider.GetComponent<Slider>().value;
            float.TryParse(textHue, out newValueHue);
            float.TryParse(textSaturation, out newValueSaturation);

            hueSlider.GetComponent<Slider>().value = newValueHue;
            saturationSlider.GetComponent<Slider>().value = newValueSaturation;
            if (labelSetter != null)
            {
                if (!labelSetter.IsColorPicker())
                {
                    labelSetter.UpdateSkyboxColor();
                    return;
                    /*float[] col = labelSetter.GetSkyboxColor();
                    colorField.color = new Color(col[0], col[1], col[2]);
                    return;*/
                }
            }
            colorField.color = Color.HSVToRGB(newValueHue, newValueSaturation, 1f);
            //OnValueChanged(newValue);
        }
    }

}
