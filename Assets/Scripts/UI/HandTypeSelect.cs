using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NotReaper.UserInput;
using NotReaper.Models;
using TMPro;
using DG.Tweening;

namespace NotReaper.UI {

    


    public class HandTypeSelect : MonoBehaviour {


        public TextMeshPro lrText;

        [NRListener]
        private void UpdateUI(TargetHandType type) {
            switch (type) {
                case TargetHandType.Left:
                    lrText.SetText("Left Hand");
                    lrText.DOColor(NRSettings.config.leftColor, (float)NRSettings.config.UIFadeDuration);
                    break;
                case TargetHandType.Right:
                    lrText.SetText("Right Hand");
                    lrText.DOColor(NRSettings.config.rightColor, (float)NRSettings.config.UIFadeDuration);
                    break;
                case TargetHandType.Either:
                    if (EditorState.Behavior.Current == TargetBehavior.Mine)
                    {
                        lrText.SetText("Mines Dodge");
                        lrText.DOColor(Color.red, (float)NRSettings.config.UIFadeDuration);
                    }
                    else
                    {
                        lrText.SetText("Either Hand");
                        lrText.DOColor(Color.gray, (float)NRSettings.config.UIFadeDuration);
                    }
                    break;
                
            }
        }

    }

}