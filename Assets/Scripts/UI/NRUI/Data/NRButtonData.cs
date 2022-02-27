using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.UI.Components
{
    [CreateAssetMenu(menuName = "NotReaper UI/Data/Button Data")]
    public class NRButtonData : ScriptableObject
    {
        [Header("Button colors")]
        public Color defaultColor;
        public Color highlightedColor;
        public Color pressedColor;
        [Space, Header("Outline Settings")]
        public Color outlineColor;
    }
}

