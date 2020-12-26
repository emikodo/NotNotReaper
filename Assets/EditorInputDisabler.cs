using NotReaper.UserInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorInputDisabler : MonoBehaviour
{
    private void Awake()
    {
        EditorInput.disableInputWhenActive.Add(gameObject);
    }
}
