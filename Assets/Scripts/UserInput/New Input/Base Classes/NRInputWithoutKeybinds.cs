using NotReaper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// Disables all keybinds when this object gets enabled. Enables standard keybinds again when this object gets disabled. Creates an input catcher zone that prevents any input to go through the object.
/// </summary>
public abstract class NRInputWithoutKeybinds : MonoBehaviour
{
    /// /// <summary>
    /// Keybinds to exclude from being disabled from editor keybinds.
    /// </summary>
    [SerializeField]
    private List<string> keybindsToEnable = new List<string>();

    private GameObject inputCatcher;
    protected virtual void Awake()
    {
        inputCatcher = Instantiate(Resources.Load<GameObject>("InputCatcher"), transform);
        inputCatcher.transform.position = Vector3.zero;
        inputCatcher.SetActive(false);
    }
    /// <summary>
    /// Callback function that gets called when Esc/Start gets pressed. Use this to close your window, or leave it empty if you don't need to do anything.
    /// </summary>
    /// <param name="context">1 if ESC pressed, 0 if not.</param>
    protected abstract void OnEscPressed(InputAction.CallbackContext context);

    /// <summary>
    /// Disables all keybinds when this object gets enabled. Call this whenever this object gets activated/shown/enabled.
    /// </summary>
    protected virtual void OnActivated()
    {
        KeybindManager.Global.RegisterEscCallback(OnEscPressed);
        KeybindManager.EnableAsset(null, new KeybindManager.KeybindOverrides(null, keybindsToEnable));
        EditorState.SetIsInUI(true);
        inputCatcher.transform.localPosition = Vector3.zero;
        inputCatcher.SetActive(true);
    }
    /// <summary>
    /// Enables standard keybinds when this object gets disabled. Call this whenever this object gets deactivated/hidden/disabled.
    /// </summary>
    protected virtual void OnDeactivated()
    {
        KeybindManager.Global.UnregisterEscCallback(OnEscPressed);
        KeybindManager.DisableUIMenu();
        inputCatcher.SetActive(false);
    }



}
