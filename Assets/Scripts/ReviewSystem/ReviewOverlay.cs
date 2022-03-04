using NotReaper.Models;
using NotReaper.Overlays;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.ReviewSystem
{
    public class ReviewOverlay : NROverlay
    {
        [NRInject] ReviewManager manager;
        public void Show()
        {
            OnActivated();
        }

        public void Hide()
        {
            OnDeactivated();
        }

        [NRListener]
        protected override void OnEditorModeChanged(EditorMode mode)
        {
            if (!gameObject.activeInHierarchy) return;

            if(mode != EditorMode.Compose)
            {
                manager.ToggleWindow();
            }
        }
    }
}

