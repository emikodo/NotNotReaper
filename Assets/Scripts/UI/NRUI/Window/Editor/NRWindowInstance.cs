using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace NotReaper.UI.Components
{
    public class NRWindowInstance : Editor
    {
        private static GameObject clickedObject;
        [MenuItem("GameObject/NotReaper UI/NRWindow", priority = 0)]
        public static void AddButton()
        {
            Create("NRWindow");
        }

        private static GameObject Create(string objectName)
        {
            var go = Instantiate(Resources.Load<GameObject>(objectName));
            go.name = "NRWindow";
            var instance = go.GetComponentInChildren<NRWindow>();
            clickedObject = Selection.activeObject as GameObject;
            if (clickedObject != null)
            {
                go.transform.SetParent(clickedObject.transform);
            }
            instance.transform.localScale = Vector3.one;
            instance.Initialize();

            return instance.gameObject;
        }
    }
}

