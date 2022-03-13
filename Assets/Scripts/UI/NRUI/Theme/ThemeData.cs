using NotReaper.UI.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.UI
{
    [CreateAssetMenu(menuName = "NotReaper UI/Data/Theme Data")]
    public class ThemeData : ScriptableObject
    {
        public string skinName = "";
        public SkinData<NRButtonSkin> button;
        public SkinData<NRSliderSkin> slider;
        public SkinData<NRWindowSkin> window;
        public SkinData<NRInputFieldSkin> inputField;

        [Serializable]
        public class SkinData<T>
        {
            public T light;
            public T dark;
        }
    }
}
