using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.UI.Components
{
    public class NRButtonGroup : MonoBehaviour
    {
        [Header("Skin")]
        public NRButtonData skin;
        [Space, Header("Animation")]
        [Range(.01f, 1f)] public float animationDuration = .25f;
        public bool growOnHover;
        public bool growOnClick;
        [Range(0f, 10f)] public float growPercentage = 1f;
        [Range(0f, 20f)] public float moveAmount = .1f;
        public AnimationMode mode;
        [Space, Header("Background")]
        public bool hideBackground;
        [Space, Header("Outline")]
        public bool useOutline = true;
        [Space, Header("Icon")]
        public Color defaultColor = Color.white;
        public Color highlightedColor = Color.white;
        public Color pressedColor = Color.white;
        [Space, Header("Text")]
        public float textSize = 15f;
        public bool autoSizeText;

        private List<NRButton> buttons = new List<NRButton>();

        public void RegisterButton(NRButton button)
        {
            if (!buttons.Contains(button))
            {
                buttons.Add(button);
            }
        }

        public void UnregisterButton(NRButton button)
        {
            if (buttons.Contains(button))
            {
                buttons.Remove(button);
            }
        }

        private void OnValidate()
        {

            foreach(var button in buttons)
            {
                button.UpdateButton();
            }
        }
    }
}
