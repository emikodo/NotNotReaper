using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NotReaper.UI.Components
{
    [CreateAssetMenu(menuName = "NotReaper UI/Skins/Title Skin")]
    public class NRTitleSkin : ScriptableObject
    {
        [Header("Text")]
        public Color textColor;
        public TMP_FontAsset font;
        [Space, Header("Underline")]
        public Color underlineColor;
        public UnderlineColor underlineColorMode = UnderlineColor.Custom;

        public enum UnderlineColor
        {
            Custom,
            LeftHand,
            RightHand,
            CurrentHand,
            OppositeHand
        }
    }
}

