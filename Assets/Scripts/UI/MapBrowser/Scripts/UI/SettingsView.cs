using NotReaper.UI.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.UI
{
    public class SettingsView : View
    {
        [SerializeField] private NRIconInputGroup inputGroup;

        private void Awake()
        {
            inputGroup.enabled = false;
        }

        public override void Hide() 
        {
            inputGroup.enabled = false;
        }

        public override void Show() 
        {
            inputGroup.enabled = true;
        }
    }
}
