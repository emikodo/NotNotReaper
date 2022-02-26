using NotReaper.Tools.ChainBuilder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using NotReaper.UI;
using NotReaper.Overlays;

namespace NotReaper.Modifier
{
    public class ModifierWindow : NROverlay, IPointerEnterHandler, IPointerExitHandler
    {
        public ModifierHandler modifierCreator;

        public void Show()
        {
            OnActivated();
        }

        public void Hide()
        {
            OnDeactivated();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            modifierCreator.isHovering = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            modifierCreator.isHovering = false;
        }
    }
}

