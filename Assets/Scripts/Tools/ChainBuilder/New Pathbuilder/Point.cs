using NotReaper.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NotReaper.Tools.PathBuilder
{

    public class Point : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Segment segment;
        private Pathbuilder pathbuilder;
        private Image image;
        private DragHandler drag;

        private bool initialized = false;

        public void Initialize(Segment segment, Pathbuilder pathbuilder)
        {
            if (initialized) return;

            this.segment = segment;
            this.pathbuilder = pathbuilder;
            image = GetComponent<Image>();
            drag = GetComponent<DragHandler>();
            initialized = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            segment.OnHandleDragStart();       
            pathbuilder.OnPointClicked(segment, this);
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            segment.OnHandleDragStop();
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public void SetColor(Color color)
        {
            image.color = color;
        }

        public void ShouldSnap(bool snap)
        {
            drag.shouldSnap = snap;
        }
    }
}

