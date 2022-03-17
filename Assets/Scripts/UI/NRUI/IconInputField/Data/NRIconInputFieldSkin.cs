using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.UI.Components
{
    [CreateAssetMenu(menuName = "NotReaper UI/Skins/IconInputField Skin")]
    public class NRIconInputFieldSkin : ScriptableObject
    {
        [Header("Text")]
        public Color textColor;
        public Color placeholderColor;
        [Space, Header("Outline")]
        public Color outlineColor;
        public Color selectedOutlineColor;
        public OutlineColorMode outlineColorMode;
        [Space, Header("Background")]
        public Color backgroundColor;
        [Space, Header("Icon")]
        public Color iconColor;

        public enum OutlineColorMode
        {
            LeftHand,
            RightHand,
            CurrentHand,
            OppositeHand,
            Custom
        }
    }
}

