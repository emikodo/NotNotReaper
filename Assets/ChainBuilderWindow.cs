using NotReaper.Models;
using NotReaper.Overlays;
using NotReaper.Tools.ChainBuilder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace NotReaper.Tools.ChainBuilder
{
    public class ChainBuilderWindow : NROverlay, IPointerEnterHandler, IPointerExitHandler
    {

        public ChainBuilder chainBuilder;

        public void OnPointerEnter(PointerEventData eventData)
        {
            chainBuilder.isHovering = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            chainBuilder.isHovering = false;
        }

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
                chainBuilder.Activate(false);
            }
        }
    }
}

