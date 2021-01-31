using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace NotReaper.Modifier
{
    [Serializable]
    public class ModifierDTO
    {
        public string type;
        public float startTick;
        public float endTick;
        public float amount;
        public float startPosX;
        public float endPosX;
        public float miniStartX;
        public float miniEndX;
        public string value1;
        public string value2;
        public string xoffset;
        public string yoffset;
        public string zoffset;
        public bool option1;
        public bool option2;

        public bool independantBool;
        public float[] leftHandColor;
        public float[] rightHandColor;
    }
}

