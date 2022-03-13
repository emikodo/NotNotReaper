using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.UI.Components
{
    [CreateAssetMenu(menuName = "NotReaper UI/Skins/InputField Skin")]
    public class NRInputFieldSkin : ScriptableObject
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

