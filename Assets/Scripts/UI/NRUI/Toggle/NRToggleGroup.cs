using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.UI.Components
{
    public class NRToggleGroup : MonoBehaviour
    {
        [Header("Skin")]
        public NRToggleSkin skin;
        [Space, Header("Group")]
        public bool allowMultipleSelected = false;
        [Header("Animation")]
        public float animationDuration = .3f;
        [Space, Header("Text")]
        public float textSize = 20f;
        public bool autoSize = false;
        [Space, Header("Icon")]
        public float iconScale = 1f;

        private List<NRToggle> toggles = new();
        private NRToggle selectedToggle;

        public void RegisterToggle(NRToggle toggle)
        {
            if (!toggles.Contains(toggle))
            {
                toggles.Add(toggle);
            }
        }

        public void UnregisterToggle(NRToggle toggle)
        {
            if (toggles.Contains(toggle))
            {
                toggles.Remove(toggle);
            }
        }

        public void SetSelectedToggle(NRToggle button)
        {
            if (allowMultipleSelected) return;

            if (selectedToggle != null)
            {
                selectedToggle.Deselect();
            }
            selectedToggle = button;
        }

        private void OnValidate()
        {
            foreach (var toggle in toggles)
            {
                toggle.UpdateVisuals();
            }
        }

        private void OnDisable()
        {
            if (selectedToggle != null)
            {
                selectedToggle.Deselect();
            }
            selectedToggle = null;
        }
    }
}

