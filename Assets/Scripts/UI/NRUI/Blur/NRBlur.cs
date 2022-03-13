using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace NotReaper.UI.Components
{
    public class NRBlur : MonoBehaviour
    {
        [SerializeField] private NRWindow parentWindow;

        private Image blur;
        private Image background;

        private bool initialized;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            if (initialized) return;
            parentWindow = transform.GetComponentInParent<NRWindow>();
            initialized = true;
            blur = GetComponent<Image>();
            background = transform.GetChild(0).GetComponent<Image>();
        }

        private void OnValidate()
        {
            if(parentWindow != null)
            {
                parentWindow.RegisterBlur(this);
            }
        }

#if UNITY_EDITOR
        private void OnDestroy()
        {
            if(parentWindow != null)
            {
                parentWindow.UnregisterBlur(this);
            }
        }
#endif

        public void SetBlurOpactiy(float opacity)
        {
            Initialize();
            blur.material.SetFloat("_Opacity", opacity);
        }

        public void FadeBlur(float targetOpacity, float duration)
        {
            Initialize();
            blur.material.DOFloat(targetOpacity, "_Opacity", duration);
        }

        public Image GetBlur()
        {
            Initialize();
            return blur;
        }

        public void SetBackgroundColor(Color color)
        {
            Initialize();
            background.color = color;
        }

        public void SetBlurEnabled(bool enabled)
        {
            Initialize();
            blur.enabled = enabled;
        }
    }
}

