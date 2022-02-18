using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using NotReaper.UserInput;
using NotReaper.Grid;
using NotReaper.Models;
using System;
using UnityEngine.InputSystem;

public class DragHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isMouseDown = false;
    private Vector3 startMousePosition;
    private Vector3 startPosition;
    public bool shouldReturn;
    private Camera cam;
    public bool shouldSnap;
    public float minMoveDistanceBeforeDragStart = 0f;
    private Vector2 mouseStartPosScreen;

    private InputAction mousePosition;
    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        mousePosition = KeybindManager.Global.MousePosition;
    }

    public void OnPointerDown(PointerEventData dt)
    {
        isMouseDown = true;
        startPosition = transform.position;
        startMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseStartPosScreen = mousePosition.ReadValue<Vector2>();
    }

    public void OnPointerUp(PointerEventData dt)
    {

        isMouseDown = false;

        if (shouldReturn)
        {
            transform.position = startPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseDown)
        {
            float moveDistance = Math.Abs(mouseStartPosScreen.magnitude - mousePosition.ReadValue<Vector2>().magnitude);
            if (moveDistance > minMoveDistanceBeforeDragStart)
            {
                Vector3 mousePos = cam.ScreenToWorldPoint(mousePosition.ReadValue<Vector2>());

                Vector3 currentPosition = mousePos;

                Vector3 diff = currentPosition - startMousePosition;

                Vector3 pos = startPosition + diff;
                pos.z = transform.position.z;

                if (!shouldSnap)
                {
                    transform.position = pos;
                }
                else transform.position = NoteGridSnap.SnapToGrid(new Vector3(pos.x, pos.y, -1f), SnappingMode.Grid);
            }          
        }
    }
}