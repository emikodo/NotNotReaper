using System;
using System.Collections;
using System.Collections.Generic;
using NotReaper.UserInput;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NotReaper.Grid {


    public class IsHoveringGrid : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
    {

        public HoverTarget hover;
        /*
        public void OnPointerEnter(PointerEventData eventData)
        {
            EditorInput.isOverGrid = true;
            hover.TryEnable();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            EditorInput.isOverGrid = false;
            hover.TryDisable();
        }

        */
        public void OnMouseOver()
        {
            if(EditorInput.inUI)
            {
                if (hover.iconEnabled)
                {
                    hover.TryDisable();
                }
                return;
            }
            if (!hover.iconEnabled || ((EditorInput.selectedTool == EditorTool.ChainBuilder || EditorInput.selectedTool == EditorTool.DragSelect) && !EditorInput.isOverGrid))
            {
                EditorInput.isOverGrid = true;
                hover.TryEnable();
            }
        }
        /*
        public void OnMouseEnter()
        {
            EditorInput.isOverGrid = true;
            hover.TryEnable();
        }
        */
        public void OnMouseExit()
        {
            EditorInput.isOverGrid = false;
            hover.TryDisable();
        }
       
    }

}