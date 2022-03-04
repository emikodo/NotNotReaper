﻿using System;
using System.Collections;
using System.Collections.Generic;
using NotReaper.Models;
using NotReaper.UserInput;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace NotReaper.Grid {


    public class IsHoveringGrid : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
    {
        public static IsHoveringGrid Instance = null;

        public HoverTarget hover;
        public LayerMask layerMask;
        [Range(1, 60)] public int raycastsPerSecond = 10;
        private BoxCollider2D defaultCollider;
        private BoxCollider2D pathBuilderCollider;

        private Camera cam;
        private InputAction mousePosition;

        private Vector2 defaultSize;
        private Vector2 defaultOffset;

        private Vector2 pathBuilderSize = new Vector2(628.7609f, 339.6537f);
        private Vector2 pathBuilderOffset = new Vector2(-0.9622803f, 27.91457f);
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
        public void Start()
        {
            if (Instance is null) Instance = this;
            else
            {
                Debug.LogWarning("IsHoverhingGrid already exists.");
                return;
            }
            defaultCollider = GetComponent<BoxCollider2D>();
            defaultSize = defaultCollider.size;
            defaultOffset = defaultCollider.offset;
            cam = Camera.main;
            mousePosition = KeybindManager.Global.MousePosition;
            StartCoroutine(Raycast());
            //hover.RegisterOnUIToolUpdatedCallback(OnUIToolUpdated);
        }

        private IEnumerator Raycast()
        {
            while (true)
            {
                if (EditorState.IsInUI)
                {
                    if (hover.iconEnabled)
                    {
                        hover.TryDisable();
                    }
                }
                else
                {

                    if(!hover.iconEnabled && (EditorState.Tool.Current == EditorTool.ChainBuilder || EditorState.Tool.Current == EditorTool.DragSelect))
                    {
                        EditorState.SetIsOverGrid(true);
                        hover.Enable();
                    }
                    else
                    {
                        Vector2 point = cam.ScreenToWorldPoint(mousePosition.ReadValue<Vector2>());
                        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero, 0f, layerMask);
                        if (hit.collider != null)
                        {
                            if (hit.collider.tag == "Grid")
                            {

                                if (!hover.iconEnabled)
                                {
                                    EditorState.SetIsOverGrid(true);
                                    hover.Enable();
                                }
                            }
                            else
                            {
                                if (hover.iconEnabled)
                                {
                                    EditorState.SetIsOverGrid(false);
                                    hover.TryDisable();
                                }
                            }
                        }
                        else
                        {
                            if (hover.iconEnabled)
                            {
                                EditorState.SetIsOverGrid(false);
                                hover.TryDisable();
                            }
                        }
                    }
                }

                yield return new WaitForSeconds(1f / raycastsPerSecond);
            }
        }

        public void ChangeColliderSize(bool grow)
        {
            if (grow)
            {
                defaultCollider.size = pathBuilderSize;
                defaultCollider.offset = pathBuilderOffset;
                if (!hover.iconEnabled)
                {
                    EditorState.SetIsOverGrid(true);
                    hover.Enable();
                }
            }
            else
            {
                defaultCollider.size = defaultSize;
                defaultCollider.offset = defaultOffset;
            }
            defaultCollider.enabled = false;
            defaultCollider.enabled = true;
            //defaultCollider.enabled = enableDefault;
            //pathBuilderCollider.enabled = !enableDefault;
        }

        [NRListener]
        private void OnUIToolUpdated(EditorTool tool)
        {
            ChangeColliderSize(tool == EditorTool.ChainBuilder || tool == EditorTool.Pathbuilder);
        }


        /*public void OnMouseOver()
        {
            if(EditorState.IsInUI)
            {
                if (hover.iconEnabled)
                {
                    hover.TryDisable();
                }
                return;
            }
            if (!hover.iconEnabled || ((EditorState.Tool.Current == EditorTool.ChainBuilder || EditorState.Tool.Current == EditorTool.DragSelect) && !EditorState.IsOverGrid))
            {
                EditorState.SetIsOverGrid(true);
                hover.Enable();
            }
        }
        
        public void OnMouseEnter()
        {
            EditorState.SetIsOverGrid(true);
            hover.Enable();
        }
        
        public void OnMouseExit()
        {
            EditorState.SetIsOverGrid(false);
            hover.TryDisable();
        }*/
       
    }

}