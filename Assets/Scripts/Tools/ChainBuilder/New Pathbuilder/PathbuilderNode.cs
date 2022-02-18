using NotReaper.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.Tools.PathBuilder
{
    public class PathbuilderNode : MonoBehaviour
    {
		[Space, Header("Icons")]
		[SerializeField] private Sprite standard;
		[SerializeField] private Sprite sustain;
		[SerializeField] private Sprite horizontal;
		[SerializeField] private Sprite vertical;
		[SerializeField] private Sprite chainNode;

		private SpriteRenderer rend;

        private void Awake()
        {
            rend = GetComponentInChildren<SpriteRenderer>();
        }

        public void SetIcon(TargetBehavior behavior, TargetHandType hand)
        {
            Sprite sprite;
            switch (behavior)
            {
                case TargetBehavior.Standard:
                    sprite = standard;
                    break;
                case TargetBehavior.Vertical:
                    sprite = vertical;
                    break;
                case TargetBehavior.Horizontal:
                    sprite = horizontal;
                    break;
                case TargetBehavior.Sustain:
                    sprite = sustain;
                    break;
                default:
                    sprite = chainNode;
                    break;
            }
            rend.sprite = sprite;
            rend.color = hand == TargetHandType.Left ? NRSettings.config.leftColor : NRSettings.config.rightColor;
        }
	}
}

