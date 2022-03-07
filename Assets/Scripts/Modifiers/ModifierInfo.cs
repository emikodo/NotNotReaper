using System.Collections;
using System.Collections.Generic;
using NotReaper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using NotReaper.UserInput;
using UnityEngine.InputSystem;

public class ModifierInfo : NRMenu
{
    public static bool isOpened = false;
    public static ModifierInfo Instance = null;
    public CanvasGroup window;
    protected override void Awake()
    {
        base.Awake();
        if(Instance is null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Trying to create second ModiferInfo Instance.");
            return;
        }

        var t = transform;
        var position = t.localPosition;
        t.localPosition = new Vector3(0, position.y, position.z);

        gameObject.SetActive(false);
    }

    public override void Show()
    {
        OnActivated();
        gameObject.SetActive(true);
        gameObject.GetComponent<CanvasGroup>().DOFade(1.0f, 0.3f);

        Transform camTrans = Camera.main.transform;

        window.transform.position = new Vector3(camTrans.position.x, camTrans.position.y, transform.position.z);

        window.transform.DOMove(new Vector3(transform.position.x, camTrans.position.y + 5.5f, transform.position.z), 1.0f).SetEase(Ease.OutQuint);
        isOpened = true;
    }



    public override void Hide()
    {
        isOpened = false;
        OnDeactivated();
        gameObject.SetActive(false);


    }

    protected override void OnEscPressed(InputAction.CallbackContext context)
    {
        Hide();
    }
}
