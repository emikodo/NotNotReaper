using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.UI.Components
{
    [CreateAssetMenu(menuName = "NotReaper UI/Skins/Toggle Skin")]
    public class NRToggleSkin : ScriptableObject
    {
        [Header("Toggle")]
        public Color backgroundColor;
        public Color fillColor;
        public FillColor fillColorMode = FillColor.Custom;
        [Space, Header("Text")]
        public Color textColor;


        public enum FillColor
        {
            Custom,
            LeftHand,
            RightHand,
            CurrentHand,
            OppositeHand
        }
    }
}

