using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NotReaper;
using TMPro;
using UnityEngine;
using NotReaper.UserInput;
using UnityEngine.EventSystems;
using NotReaper.Timing;
using UnityEngine.InputSystem;

public class BPMListWindow : NRMenu
{
    public TMP_Text bpmTextList;
    public bool isActive;
    void Start() {
        Vector3 defaultPos = Vector3.zero;
        gameObject.GetComponent<RectTransform>().localPosition = defaultPos;
        gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
        gameObject.SetActive(false);
    }

    public void Activate(List<float> bpmList) {
        isActive = true;
        OnActivated();
        gameObject.GetComponent<CanvasGroup>().DOFade(1.0f, 0.3f);
        gameObject.SetActive(true);

        bpmTextList.text = "";
        foreach(float f in bpmList) {
            bpmTextList.text += f.ToString() + "\n";
        }
    }

    public void Deactivate() {
        isActive = false;
        OnDeactivated();
        gameObject.GetComponent<CanvasGroup>().DOFade(0.0f, 0.3f);
        gameObject.SetActive(false);
    }

    protected override void OnEscPressed(InputAction.CallbackContext context)
    {
        Deactivate();
    }
}
