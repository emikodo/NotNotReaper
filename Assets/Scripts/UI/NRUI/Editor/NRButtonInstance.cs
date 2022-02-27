using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace NotReaper.UI.Components
{
    public class NRButtonInstance : Editor
    {
        private static GameObject clickedObject;
        [MenuItem("GameObject/NotReaper UI/NRButton", priority = 0)]
        public static void AddButton()
        {
            Create("NRButton");
        }

        private static GameObject Create(string objectName)
        {
            var instance = Instantiate(Resources.Load<NRButton>(objectName));
            instance.name = objectName;

            clickedObject = Selection.activeObject as GameObject;
            if(clickedObject != null)
            {
                instance.transform.parent = clickedObject.transform;
            }
            instance.transform.localScale = Vector3.one;
            instance.Initialize();
            return instance.gameObject;
        }
    }
}

