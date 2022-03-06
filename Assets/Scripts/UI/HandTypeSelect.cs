﻿using System.Collections;
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
                    lrText.SetText("Left hand");
                    lrText.DOColor(NRSettings.config.leftColor, (float)NRSettings.config.UIFadeDuration);
                    break;
                case TargetHandType.Right:
                    lrText.SetText("Right hand");
                    lrText.DOColor(NRSettings.config.rightColor, (float)NRSettings.config.UIFadeDuration);
                    break;
                case TargetHandType.Either:
                    lrText.SetText("Either hand");
                    lrText.DOColor(Color.gray, (float)NRSettings.config.UIFadeDuration);
                    break;
                
            }
        }

    }

}