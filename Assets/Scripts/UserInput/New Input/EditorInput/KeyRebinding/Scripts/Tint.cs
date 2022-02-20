using NotReaper.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NotReaper.Keybinds
{
    [RequireComponent(typeof(Image))]
    public class Tint : MonoBehaviour
    {
        private Image image;

        public void SetTint(TargetHandType hand)
        {
            image = GetComponent<Image>();
            float alpha = image.color.a;
            Color color = hand == TargetHandType.Left ? NRSettings.config.leftColor : NRSettings.config.rightColor;
            color.a = alpha;
            image.color = color;
        }
    }
}

