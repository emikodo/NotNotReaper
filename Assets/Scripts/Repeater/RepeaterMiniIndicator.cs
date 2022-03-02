using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NotReaper.Repeaters
{
    public class RepeaterMiniIndicator : MonoBehaviour
    {
        [SerializeField] private RectTransform rect;
        [SerializeField] private RectTransform topBar;
        [SerializeField] private RectTransform bottomBar;
        [SerializeField] private Image background;
        [SerializeField] private Image topBackground;
        [SerializeField] private Image bottomBackground;

        public void SetIsParent(bool isParent)
        {
            topBar.gameObject.SetActive(isParent);
            bottomBar.gameObject.SetActive(isParent);
        }

        public void SetWidth(float width)
        {
            rect.sizeDelta = new Vector2(width, 25.1782f);
            var size = topBar.sizeDelta;
            size.x = width;
            topBar.sizeDelta = size;
            size.y = bottomBar.sizeDelta.y;
            bottomBar.sizeDelta = size;
        }

        public void SetColor(Color color, Color barColor)
        {
            background.color = color;
            topBackground.color = bottomBackground.color = barColor;
        }
    }
}

