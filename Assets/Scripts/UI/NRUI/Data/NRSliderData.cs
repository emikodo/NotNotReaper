using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.UI.Components
{
    [CreateAssetMenu(menuName = "NotReaper UI/Data/Slider Data")]
    public class NRSliderData : ScriptableObject
    {
        [Header("Slider colors")]
        public Color sliderBGColor;
    }
}

