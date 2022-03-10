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
        public GameObject keyPanel;
        public SpriteRenderer keybindImage;
        public SpriteRenderer modifier1;
        public SpriteRenderer modifier2;
        private Image background;
        [NRInject] InputIcons icons;

        private Color disabledColor;
        private Color enabledColor;
        void Awake()
        {
            if (I == null) I = this;
            label.text = "";
            modifier1.gameObject.SetActive(false);
            modifier2.gameObject.SetActive(false);
            keyPanel.SetActive(false);
            background = GetComponent<Image>();
            enabledColor = background.color;
            disabledColor = enabledColor;
            disabledColor.a = 0f;
            background.color = disabledColor;
        }

        public void SetText(InputActionReference keybind)
        {
            //label.text = text.Replace("[", "<color=#FDA50F>").Replace("]", "</color>");
            var data = RebindManager.GetKeybindDisplayData(keybind.action);
            label.text = data.displayName.ToLower();
            background.color = enabledColor;
            keyPanel.SetActive(true);
            keybindImage.sprite = icons.GetIcon(data.keybind, out _);
            if (!string.IsNullOrEmpty(data.modifier1))
            {
                modifier1.gameObject.SetActive(true);
                modifier1.sprite = icons.GetIcon(data.modifier1, out _);
            }
            else
            {
                modifier1.gameObject.SetActive(false);
            }
            if (!string.IsNullOrEmpty(data.modifier2))
            {
                modifier2.gameObject.SetActive(false);
                modifier2.sprite = icons.GetIcon(data.modifier2, out _);
            }
            else
            {
                modifier2.gameObject.SetActive(false);
            }
        }

        public void SetText(string text)
        {
            if (keybindImage == null) return;
            string txt = text;
            if (!string.IsNullOrEmpty(txt))
            {
                if (txt.Contains('['))
                {
                    txt = txt.Insert(txt.IndexOf('['), "\n");
                }
                txt = txt.Replace("[", "<color=#FDA50F>").Replace("]", "</color>").ToLower();
                background.color = enabledColor;
            }
            else
            {
                background.color = disabledColor;
            }
            //label.text = text.Replace("[", "<color=#FDA50F>").Replace("]", "</color>").ToLower();
            label.text = txt;
            keybindImage.sprite = null;
            modifier1.sprite = null;
            modifier2.sprite = null;
            keyPanel.SetActive(false);
        }

    }
}

