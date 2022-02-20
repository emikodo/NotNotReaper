using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NotReaper.UI;
using NotReaper.Models;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

namespace NotReaper.Keybinds
{
    public class KeybindTitle : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI keybindTitle;
        [SerializeField] private NRThemeable themeable;
        [SerializeField] private Button resetButton;

        private List<KeybindEntry> keys;
        private InputActionAsset asset;
        private Action<InputActionAsset> onResetCallback;

        public void Initialize(string assetName, TargetHandType hand, InputActionAsset asset)
        {
            keybindTitle.text = assetName;
            this.asset = asset;

            NRThemeableType type = hand == TargetHandType.Left ? NRThemeableType.Left : NRThemeableType.Right;
            themeable.SetType(type);

            resetButton.gameObject.SetActive(false);
        }

        public void SetKeys(List<KeybindEntry> keys, Action<InputActionAsset> onResetCallback)
        {
            this.keys = keys;
            resetButton.gameObject.SetActive(true);
            this.onResetCallback = onResetCallback;
        }

        public void ResetKeybinds()
        {
            onResetCallback.Invoke(asset);

            foreach(var key in keys)
            {
                key.UpdateUI();
            }
        }
    }
}
