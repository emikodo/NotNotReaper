using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.UI
{
    public class SettingsView : View
    {
        [SerializeField] private GameObject keybinds;

        public override void Hide() { }

        public override void Show() { }

        public void OpenKeybinds()
        {
            keybinds.SetActive(true);
        }

        public void CloseKeybinds()
        {
            keybinds.SetActive(false);
        }
    }
}
