using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace NotReaper.UI.Components
{
    public class NRInputSliderComboInstance : Editor
    {
        private static GameObject clickedObject;
        [MenuItem("GameObject/NotReaper UI/NRInputSliderCombo", priority = 0)]
        public static void AddButton()
        {
            Create("NRInputSliderCombo");
        }

        private static GameObject Create(string objectName)
        {
            var instance = Instantiate(Resources.Load<NRInputSliderCombo>(objectName));
            instance.name = objectName;

            clickedObject = Selection.activeObject as GameObject;
            if (clickedObject != null)
            {
                instance.transform.SetParent(clickedObject.transform);
            }
            instance.transform.localScale = Vector3.one;
            instance.transform.localPosition = Vector3.zero;
            instance.Initialize();
            return instance.gameObject;
        }
    }
}
