using NotReaper.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.UI.Components
{
    public abstract class NRThemeable : MonoBehaviour
    {
        protected virtual void Start()
        {
            if (!Application.isPlaying) return;
            ThemeManager.Instance.RegisterThemeable(this);
        }

        public abstract void Initialize();
        public abstract void UpdateVisuals();
        public abstract void ApplyLightTheme(ThemeData theme);
        public abstract void ApplyDarkTheme(ThemeData theme);
        protected abstract void OnValidate();

        protected virtual void OnDestroy()
        {
            if (!Application.isPlaying) return;

            ThemeManager.Instance.UnregisterThemeable(this);
        }
    }
}
