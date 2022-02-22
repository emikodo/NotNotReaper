using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using NotReaper.Keybinds;

namespace NotReaper.UI
{
    public class ToolTips : MonoBehaviour
    {
        public static ToolTips I;
        public TextMeshProUGUI label;
        public SpriteRenderer keybindImage;
        public SpriteRenderer modifier1;
        public SpriteRenderer modifier2;
        [NRInject] InputIcons icons;
        void Awake()
        {
            if (I == null) I = this;
            label.text = "";
        }

        public void SetText(InputActionReference keybind)
        {
            //label.text = text.Replace("[", "<color=#FDA50F>").Replace("]", "</color>");
            var data = RebindManager.GetKeybindDisplayData(keybind.action);
            label.text = data.displayName.ToLower();
            
            
            keybindImage.sprite = icons.GetIcon(data.keybind, out _);
            if (!string.IsNullOrEmpty(data.modifier1)) modifier1.sprite = icons.GetIcon(data.modifier1, out _);
            if (!string.IsNullOrEmpty(data.modifier2)) modifier2.sprite = icons.GetIcon(data.modifier2, out _);
        }

        public void SetText(string text)
        {
            label.text = text.Replace("[", "<color=#FDA50F>").Replace("]", "</color>").ToLower();
            keybindImage.sprite = null;
            modifier1.sprite = null;
            modifier2.sprite = null;
        }

    }
}

