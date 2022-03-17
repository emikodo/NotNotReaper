using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NotReaper.UI
{
    public class TimelineTextContainer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textPrefab;
        [SerializeField] private Transform content;
        private Dictionary<int, TextMeshProUGUI> textObjects = new();

        public void AddText(int id, string text)
        {
            var instance = Instantiate(textPrefab, content);
            instance.text = text;
            textObjects.Add(id, instance);
        }

        public void RemoveText(int id)
        {
            if (textObjects.ContainsKey(id))
            {
                var instance = textObjects[id];
                textObjects.Remove(id);
                Destroy(instance.gameObject);
            }
        }

        public void UpdateText(int id, string text)
        {
            if (textObjects.ContainsKey(id))
            {
                textObjects[id].text = text;
            }
        }

        public bool HasID(int id)
        {
            return textObjects.ContainsKey(id);
        }

        public void ClearTexts()
        {
            foreach(var text in textObjects)
            {
                Destroy(text.Value.gameObject);
            }

            textObjects.Clear();
        }

        public bool HasAnyTextObjects() => textObjects.Count > 0;
    }

}
