using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class View : MonoBehaviour
    {
        internal CanvasGroup canvas;
        public void Initialize()
        {
            canvas = GetComponent<CanvasGroup>();
        }
        public abstract void Show();
        public abstract void Hide();
        
    }

}
