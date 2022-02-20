using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NotReaper.Models;
using System;
using UnityEngine.InputSystem;

namespace NotReaper.Keybinds
{
    public class KeybindMap : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI keybindMap;
        [SerializeField] private Tint tint;

        private Action<InputActionMap> onResetCallback;
        private InputActionMap map;
        private List<KeybindEntry> keys;
        public void Initialize(string mapName, TargetHandType hand, InputActionMap map, Action<InputActionMap> onResetCallback)
        {
            keybindMap.text = mapName;
            tint.SetTint(hand);
            this.map = map;
            this.onResetCallback = onResetCallback;
        }

        public void SetKeys(List<KeybindEntry> keys)
        {
            this.keys = keys;
        }

        public void OnReset()
        {
            onResetCallback.Invoke(map);
            foreach(var key in keys)
            {
                key.UpdateUI();
            }
        }
    }
}
