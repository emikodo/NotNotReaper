using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NotReaper
{
    public class TimelineCameraMouseHandler : MonoBehaviour
    {
        private Timeline timeline;
        private Camera cam;
        private InputAction mousePosition;
        [SerializeField] private LayerMask layerMask;
        [SerializeField, Range(1, 60), Tooltip("How many times per second we raycast")] private int raycastsPerSecond = 10;
        private void Start()
        {
            timeline = NRDependencyInjector.Get<Timeline>();
            cam = Camera.main;
            mousePosition = KeybindManager.Global.MousePosition;
            StartCoroutine(Raycast());
        }

        private IEnumerator Raycast()
        {
            while (true)
            {
                Vector2 point = cam.ScreenToWorldPoint(mousePosition.ReadValue<Vector2>());
                RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero, 0f, layerMask);
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Timeline")
                    {
                        timeline.hover = true;
                    }
                    else
                    {
                        timeline.hover = false;
                    }
                }
                else
                {
                    timeline.hover = false;
                }

                yield return new WaitForSeconds(1f / raycastsPerSecond);
            }
        }
    }
}

