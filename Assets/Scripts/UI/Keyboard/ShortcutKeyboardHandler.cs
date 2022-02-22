﻿using NotReaper.Keybinds;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using NotReaper.UI;
namespace NotReaper.Keyboard
{
    public class ShortcutKeyboardHandler : MonoBehaviour
    {
        public static ShortcutKeyboardHandler Instance = null;
        public ShortcutInfo shortcutMenu;
        private ShortcutKey[] keys;
        private bool showCtrl = false;
        private bool showShift = false;
        private bool showAlt = false;
        private Camera main;
        private KeybindManager.Global.Modifiers state;

        private void Awake()
        {
            if (Instance is null) Instance = this;
            else
            {
                Debug.LogWarning("Trying to create second ShortcutKeyboardHandler instance.");
                return;
            }
            main = Camera.main;
            keys = GetComponentsInChildren<ShortcutKey>();
        }

        public void OnOpen()
        {
            KeybindManager.onShiftDown += SelectShiftKey;
            KeybindManager.onCtrlDown += SelectCtrlKey;
            KeybindManager.onAltDown += SelectAltKey;
            state = KeybindManager.Global.Modifiers.None;
            EnableKeys();
        }
        public void OnClose()
        {
            KeybindManager.onShiftDown -= SelectShiftKey;
            KeybindManager.onCtrlDown -= SelectCtrlKey;
            KeybindManager.onAltDown -= SelectAltKey;
        }

        private void SetFlag(KeybindManager.Global.Modifiers flag)
        {
            state |= flag;
        }
        private void RemoveFlag(KeybindManager.Global.Modifiers flag)
        {
            state &= ~flag;
        }

        public void UpdateKey(string displayName, string mapName, string bindingPath, string modifier1Path, string modifier2Path, KeybindManager.Global.Modifiers modifier1, KeybindManager.Global.Modifiers modifier2)
        {
            if (bindingPath.ToLower().Contains("mouse")) return;
            ShortcutKey key = GetKeyFromPath(bindingPath);
            if (key == null) return;
            var combined = modifier1 |= modifier2;
            if (combined.IsCtrlDown()) key.SetCtrlText(displayName, mapName);
            else if (combined.IsShiftDown()) key.SetShiftText(displayName, mapName);
            else if (combined.IsAltDown()) key.SetAltText(displayName, mapName);
            else if (combined.IsCtrlAltDown()) key.SetCtrlAltText(displayName, mapName);
            else if (combined.IsCtrlShiftDown()) key.SetCtrlShiftText(displayName, mapName);
            else if (combined.IsShiftAltDown()) key.SetShiftAltText(displayName, mapName);
            else key.SetNormalText(displayName, mapName);

        }

        public void SelectCtrlKey()
        {
            showCtrl = !showCtrl;
            if (showCtrl) SetFlag(KeybindManager.Global.Modifiers.Ctrl);
            else RemoveFlag(KeybindManager.Global.Modifiers.Ctrl);
            EnableKeys();
        }

        public void SelectShiftKey()
        {
            showShift = !showShift;
            if (showShift) SetFlag(KeybindManager.Global.Modifiers.Shift);
            else RemoveFlag(KeybindManager.Global.Modifiers.Shift);
            EnableKeys();
        }

        public void SelectAltKey()
        {
            showAlt = !showAlt;
            if (showAlt) SetFlag(KeybindManager.Global.Modifiers.Alt);
            else RemoveFlag(KeybindManager.Global.Modifiers.Alt);
            EnableKeys();
        }

        private void EnableKeys()
        {
            DisableAllKeys();

            for(int i = 0; i < keys.Length; i++)
            {
                keys[i].Enable(true, state);
            }
            /*
            switch (state)
            {
                case OfType.Ctrl:
                    for (int i = 0; i < keys.Length; i++)
                    {
                        if (keys[i].selectableCtrl) keys[i].Enable(enable, type);
                    }
                    break;
                case OfType.Shift:
                    for (int i = 0; i < keys.Length; i++)
                    {
                        if (keys[i].selectableShift) keys[i].Enable(enable, type);
                    }
                case OfType.Alt:
                    for(int i = 0; )
                    break;
                default:
                    break;
            }
            if (!showShift && !showCtrl)
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys[i].selectableNormal) keys[i].Enable(true, OfType.Normal);
                }
            }
            */
        }

        private void DisableAllKeys()
        {
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i].Enable(false, KeybindManager.Global.Modifiers.None);
            }
        }

        private ShortcutKey GetKeyFromPath(string path)
        {
            path = path.Substring(path.IndexOf('/') + 1).ToLower();
            return keys.Where(key => key.keyName.ToLower() == path).FirstOrDefault();
        }
       
    }
}

