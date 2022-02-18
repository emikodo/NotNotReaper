using System.Collections;
using System.Collections.Generic;
using NotReaper.Models;
using NotReaper.UserInput;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace NotReaper.UI {


    public class SoundSelect : MonoBehaviour {
        // Start is called before the first frame update

        public Image ddBG;
        public Image arrow;

        public UIInput uiInput;

        public void LoadUIColors() 
        {
            Color rColor = NRSettings.config.rightColor;
            ddBG.color = new Color(rColor.r, rColor.g, rColor.b, 0.9f);

            arrow.color = rColor;
        }

        public void ValueChanged(int value) 
        {
            EditorState.SelectHitsound((TargetHitsound)value);
            //uiInput.SelectHitsound((TargetHitsound)value);
        }
    }

}