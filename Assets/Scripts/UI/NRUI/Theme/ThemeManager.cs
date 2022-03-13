using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NotReaper.UI.Components
{
    [ExecuteAlways]
    public class ThemeManager : MonoBehaviour
    {
        [SerializeField]
        public static ThemeManager Instance { get; private set; } = null;

        private List<NRThemeable> themeables = new();
        [SerializeField] private List<ThemeData> themes = new();

        private ThemeData selectedTheme;
        private ThemeMode selectedMode = ThemeMode.Dark;
        private void Awake()
        {
            if (Instance != null)
            {
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            NRSettings.OnLoad(() =>
            {
                selectedTheme = themes.First(t => t.skinName == NRSettings.config.selectedTheme);
                selectedMode = (ThemeMode)NRSettings.config.themeMode;
                ApplyTheme();
            });
        }

        public List<ThemeData> GetThemes()
        {
            return themes;
        }

        public void SelectTheme(string themeName)
        {
            if(themes.Any(t => t.skinName == themeName))
            {
                selectedTheme = themes.First(t => t.skinName == themeName);
            }
            NRSettings.config.selectedTheme = selectedTheme.skinName;
            NRSettings.SaveSettingsJson();
            ApplyTheme();
        }

        public void ApplyTheme()
        {
            if(selectedMode == ThemeMode.Light)
            {
                ApplyLightTheme();
            }
            else
            {
                ApplyDarkTheme();
            }
        }

        public void SelectThemeMode(ThemeMode mode)
        {
            selectedMode = mode;
            NRSettings.config.themeMode = (int)selectedMode;
            NRSettings.SaveSettingsJson();
        }

        private void ApplyLightTheme()
        {
            foreach(var themeable in themeables)
            {
                themeable.ApplyLightTheme(selectedTheme);
                themeable.UpdateVisuals();
            }
        }

        private void ApplyDarkTheme()
        {
            foreach (var themeable in themeables)
            {
                themeable.ApplyDarkTheme(selectedTheme);
                themeable.UpdateVisuals();
            }
        }

        public void RegisterThemeable(NRThemeable themeable)
        {
            if (!themeables.Contains(themeable))
            {
                themeables.Add(themeable);
            }
        }

        public void UnregisterThemeable(NRThemeable themeable)
        {
            if (themeables.Contains(themeable))
            {
                themeables.Remove(themeable);
            }
        }

        public enum ThemeMode
        {
            Light,
            Dark
        }
    }

}
