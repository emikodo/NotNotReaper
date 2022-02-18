using NotReaper.UserInput;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public static class KeybindManager
{
    #region Fields
    private static List<InputActionAsset> inputAssets = new List<InputActionAsset>();

    private static InputActionAsset editorKeybinds;
    private static GlobalKeybinds globalKeybinds;

    private static Dictionary<InputActionAsset, KeybindOverrides> activeAssets = new Dictionary<InputActionAsset, KeybindOverrides>();
    #endregion

    #region Initialization
    static KeybindManager()
    {        
        globalKeybinds = new GlobalKeybinds();
        RegisterCallbacks();
        globalKeybinds.Enable();
    }

    private static void RegisterCallbacks()
    {
        globalKeybinds.Global.Control.performed += _ => Global.IsCtrlDown = true;
        globalKeybinds.Global.Alt.performed += _ => Global.IsAltDown = true;
        globalKeybinds.Global.Shift.performed += _ => Global.IsShiftDown = true;

        globalKeybinds.Global.Control.canceled += _ => Global.IsCtrlDown = false;
        globalKeybinds.Global.Alt.canceled += _ => Global.IsAltDown = false;
        globalKeybinds.Global.Shift.canceled += _ => Global.IsShiftDown = false;
    }
    /// <summary>
    /// Set the Standard Editor-Keybind asset.
    /// </summary>
    /// <param name="standard">The standard keybind asset.</param>
    public static void SetStandardKeybinds(InputActionAsset standard)
    {
        editorKeybinds = standard;
    }
    /// <summary>
    /// Register an InputActionAsset so it can be handled for keybind remapping.
    /// </summary>
    /// <param name="asset">The asset to register.</param>
    public static void RegisterAsset(InputActionAsset asset)
    {
        if (!inputAssets.Contains(asset))
        {
            inputAssets.Add(asset);
        }
    }
    #endregion

    #region Enable/Disable Assets
    /// <summary>
    /// Enables the asset and applies it's overrides while disabling all other keybinds.
    /// </summary>
    /// <param name="asset">The asset to enable.</param>
    /// <param name="overrides">The keybind overrides to apply.</param>
    public static void EnableAsset(InputActionAsset asset, KeybindOverrides overrides)
    {
        if (overrides.maps == null) overrides.maps = new List<Map>();
        if (overrides.keybinds == null) overrides.keybinds = new List<string>();
        if (activeAssets.Count > 0) DisableKeybinds(activeAssets.Last().Value.keybinds);
        ApplyOverrides(overrides);
        if(asset != null)
        {
            asset.Enable();
            if (!activeAssets.ContainsKey(asset))
            {
                activeAssets.Add(asset, overrides);
            }
        }
    }
    /// <summary>
    /// Disables the asset and enables the previously active asset.
    /// </summary>
    /// <param name="asset">The asset to disable.</param>
    public static void DisableAsset(InputActionAsset asset)
    {
        if(asset != null)
        {
            asset.Disable();

            if (activeAssets.ContainsKey(asset))
            {
                DisableKeybinds(activeAssets[asset].keybinds);
                activeAssets.Remove(asset);
            }
        }

        if(activeAssets.Count > 0)
        {
            ApplyOverrides(activeAssets.Last().Value);
        }
        else
        {
            EnableEditorKeybinds();
        }
    }
    /// <summary>
    /// Applies keybind overrides to standard keybinds.
    /// </summary>
    private static void ApplyOverrides(KeybindOverrides overrides)
    {
        if (editorKeybinds == null) return;
        if (overrides.maps == null || overrides.maps.Count == 0)
        {
            editorKeybinds.Disable();
        }
        else
        {
            var names = Enum.GetNames(typeof(Map));
            foreach (var name in names)
            {
                var m = (Map)Enum.Parse(typeof(Map), name);
                if (overrides.maps.Any(map => map == m))
                {
                    editorKeybinds.FindActionMap(m.ToString())?.Enable();
                }
                else
                {
                    editorKeybinds.FindActionMap(m.ToString())?.Disable();
                }
            }
        }

        if (overrides.keybinds != null && overrides.keybinds.Count > 0)
        {
            foreach (string keybind in overrides.keybinds)
            {
                editorKeybinds.FindAction(keybind)?.Enable();
            }
        }

        /*
        List<Map> maps = new List<Map>();
        List<string> keybinds = new List<string>();
        foreach (var entry in activeAssets)
        {
            foreach (var map in entry.Value.maps)
            {
                if (!maps.Contains(map))
                {
                    maps.Add(map);
                }
            }
            foreach (var keybind in entry.Value.keybinds)
            {
                if (!keybinds.Contains(keybind))
                {
                    keybinds.Add(keybind);
                }
            }
        }
        EnableMaps(maps);
        EnableKeybinds(keybinds);
        */
    }

    private static List<InputAction> GetInputSnapshot()
    {
        List<InputAction> enabledKeybinds = new List<InputAction>();
        foreach(var map in editorKeybinds.actionMaps)
        {
            foreach(var keybind in map.actions)
            {
                if (keybind.enabled) enabledKeybinds.Add(keybind);
            }
        }
        return enabledKeybinds;
    }
    #endregion

    #region Enable/Disable Editor Keybinds
    /// <summary>
    /// Enables standard keybinds.
    /// </summary>
    public static void EnableEditorKeybinds()
    {
        if (editorKeybinds != null)
        {
            editorKeybinds.Enable();
            foreach (var map in editorKeybinds.actionMaps) map.Enable();
        }
        //EnableAsset(editorKeybinds);
    }
    /// <summary>
    /// Disables standard keybinds.
    /// </summary>
    public static void DisableEditorKeybinds()
    {
        if(editorKeybinds != null)
        {
            editorKeybinds.Disable();
        }
    }
    #endregion

    #region Enable/Disable Specific Maps/Keybinds
    /// <summary>
    /// Enables a specific map.
    /// </summary>
    /// <param name="map">The map to enable.</param>
    public static void EnableMap(Map map)
    {
        editorKeybinds.FindActionMap(map.ToString())?.Enable();
    }
    /// <summary>
    /// Disables a specific map.
    /// </summary>
    /// <param name="map">The map to disable.</param>
    public static void DisableMap(Map map)
    {
        editorKeybinds.FindActionMap(map.ToString())?.Disable();
    }
    /// <summary>
    /// Enables the given list of maps and disables all others.
    /// </summary>
    /// <param name="maps">The maps to enable.</param>
    private static void EnableMaps(List<Map> maps)
    {
        var names = Enum.GetNames(typeof(Map));
        foreach (var name in names)
        {
            var m = (Map)Enum.Parse(typeof(Map), name);
            if (maps.Any(map => map == m))
            {
                editorKeybinds.FindActionMap(m.ToString())?.Enable();
            }
            else
            {
                editorKeybinds.FindActionMap(m.ToString())?.Disable();
            }
        }
    }
    /// <summary>
    /// Enables the given list of keybinds.
    /// </summary>
    /// <param name="keybinds">The keybinds to enable.</param>
    private static void EnableKeybinds(List<string> keybinds)
    {
        foreach (string keybind in keybinds)
        {
            editorKeybinds.FindAction(keybind)?.Enable();
        }
    }
    /// <summary>
    /// Disables the given list of keybinds.
    /// </summary>
    /// <param name="keybinds">The keybinds to disable.</param>
    private static void DisableKeybinds(List<string> keybinds)
    {
        foreach(string keybind in keybinds)
        {
            editorKeybinds.FindAction(keybind)?.Disable();
        }
    }
    #endregion

    #region Classes and Enums
    /// <summary>
    /// The list of available InputActionMaps in EditorKeybinds.
    /// </summary>
    /// <remarks>Has to be updated manually. CAREFUL WHEN ADDING NEW MAPS - Append them to the end of this list. 
    /// If you add them somewhere in the middle, or delete an existing one, all scripts defining keybind overrides will have to re-set appropriate maps.</remarks>
    public enum Map
    {
        Mapping,
        Utility,
        Menus,
        Timeline,
        DragSelect,
        Grid,
        BPM,
        SpacingSnap,
        Pathbuilder,
        Modifiers,
        HitsoundSelect,
        HitsoundConvert,
        BehaviorSelect,
        BehaviorConvert
    }
    /// <summary>
    /// Describes keybinds that should stay enabled when a new asset gets enabled.
    /// </summary>
    public class KeybindOverrides
    {
        public List<Map> maps;
        public List<string> keybinds;

        public KeybindOverrides()
        {
            maps = new List<Map>();
            keybinds = new List<string>();
        }

        public KeybindOverrides(List<Map> maps, List<string> keybinds)
        {
            this.maps = maps;
            this.keybinds = keybinds;
        }
    }

    /// <summary>
    /// Describes common, global keybinds that are always active and accessible.
    /// </summary>
    public class Global
    {
        public static bool IsCtrlDown;
        public static bool IsShiftDown;
        public static bool IsAltDown;
        public static InputAction MousePosition
        {
            get { return globalKeybinds.Global.MousePosition; }
        }

        public static void RegisterEscCallback(Action<InputAction.CallbackContext> callback)
        {
            globalKeybinds.Global.Close.performed += callback;
        }
        public static void UnregisterEscCallback(Action<InputAction.CallbackContext> callback)
        {
            globalKeybinds.Global.Close.performed -= callback;
        }
    }
    #endregion

    #region Commented out stuff
    /*
    public static void EnableAsset(InputActionAsset asset)
    {
        if (asset is null) return;
        asset.Enable();
        foreach (var map in asset.actionMaps) map.Enable();
    }
    */
    /*
    private static void EnableSpecificEditorKeybinds(List<Map> maps, List<string> keybinds)
    {
        if (editorKeybinds is null) return;
        if(maps is null || maps.Count == 0)
        {
            editorKeybinds.Disable();
        }
        if(maps != null && maps.Count > 0)
        {
            var names = Enum.GetNames(typeof(Map));
            foreach (var name in names)
            {
                var m = (Map)Enum.Parse(typeof(Map), name);
                if (maps.Any(map => map == m))
                {
                    editorKeybinds.FindActionMap(m.ToString())?.Enable();
                }
                else
                {
                    editorKeybinds.FindActionMap(m.ToString())?.Disable();
                }
            }
        }      
        if(keybinds != null && keybinds.Count > 0)
        {
            foreach (string keybind in keybinds)
            {
                editorKeybinds.FindAction(keybind)?.Enable();
            }
        }
    }
    */
    #endregion
}
