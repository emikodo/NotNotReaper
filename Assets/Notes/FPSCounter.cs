using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public float updateInterval = 0.5F;
    private float avg = 0f;
    private float fps;

    void OnGUI()
    {
        GUILayout.Label("" + fps.ToString("f2"));
    }

    private void Update()
    {
        avg += ((Time.deltaTime / Time.timeScale) - avg) * 0.03f; //run this every frame
        fps = (1F / avg); //display this value
    }
}
