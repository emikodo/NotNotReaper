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
        public override void Show()
        {
            OnActivated();
        }

        public override void Hide()
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

