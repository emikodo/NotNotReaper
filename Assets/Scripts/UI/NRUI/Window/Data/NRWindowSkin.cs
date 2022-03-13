using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.UI.Components
{
    [CreateAssetMenu(menuName = "NotReaper UI/Skins/Window Skin")]
    public class NRWindowSkin : ScriptableObject
    {
        [Header("Background")]
        public Color backgroundColor;
        [Space, Header("Blur")]
        public bool blurEnabled;
        public float blurOpacity;
        [Space, Header("Text")]
        public Color textColor;
    }
}

