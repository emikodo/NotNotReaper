using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace NotReaper.UI.Components
{
    public class NRBlurInstance : Editor
    {
        private static GameObject clickedObject;
        [MenuItem("GameObject/NotReaper UI/NRBlur", priority = 0)]
        public static void AddButton()
        {
            Create("NRBlur");
        }

        private static GameObject Create(string objectName)
        {
            var instance = Instantiate(Resources.Load<NRBlur>(objectName));
            instance.name = objectName;

            clickedObject = Selection.activeObject as GameObject;
            if (clickedObject != null)
            {
                instance.transform.SetParent(clickedObject.transform);
            }
            instance.transform.localScale = Vector3.one;
            instance.Initialize();
            instance.transform.SetAsFirstSibling();
            var rect = instance.GetComponent<RectTransform>();
            rect.sizeDelta = Vector2.zero;
            rect.anchoredPosition = Vector3.zero;
            
            return instance.gameObject;
        }
    }
}

