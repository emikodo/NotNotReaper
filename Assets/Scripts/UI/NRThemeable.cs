using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NotReaper.UI {
    

    public class NRThemeable : MonoBehaviour 
    {
        
        [SerializeField] private NRThemeableType type;

        [SerializeField]
        [Range(-0.1f, 0.1f)] private float hueModifier = 0f;

        [SerializeField]
        [Range(-0.1f, 0.1f)] private float saturationModifier = 0f;

        [SerializeField]
        [Range(-0.1f, 0.1f)] private float valueModifier = 0f;

        [SerializeField] [Range(0.1f, 1.0f)] private float alpha = 1.0f;
        
        


        private void Start() 
        {
            NRSettings.OnLoad(() => UpdateColors());
            ThemeableManager.AddThemeable(this);
        }

        public void SetType(NRThemeableType type)
        {
            this.type = type;
            UpdateColors();
        }

        private Color GenerateColorForType(NRThemeableType typeToGen) 
        {
            Color newColor;
                    
            if (typeToGen == NRThemeableType.Left) newColor = NRSettings.config.leftColor;
            else if (typeToGen == NRThemeableType.Right) newColor = NRSettings.config.rightColor;
            else newColor = NRSettings.config.selectedHighlightColor;
                    
                    
                    
            float h, s, v;
            Color.RGBToHSV(newColor, out h, out s, out v);

            h += hueModifier;
            s += saturationModifier;
            v += valueModifier;

            newColor = Color.HSVToRGB(h, s, v);

            return new Color(newColor.r, newColor.g, newColor.b, alpha);
        }

        public void UpdateColors()
        {
            var img = transform.GetComponent<Image>();
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();

            Color newColor = GenerateColorForType(type);

            if (img) img.color = newColor;

            else if (sr) sr.color = newColor;

            else if (text)
            {
                text.color = newColor;
            }
        }
    }
    
    
    
    






    public enum NRThemeableType {
        Left,
        Right,
        Selected
    }


}