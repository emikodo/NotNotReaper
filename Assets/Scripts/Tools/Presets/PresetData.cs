using Newtonsoft.Json;
using NotReaper.Models;
using NotReaper.Targets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.Tools.Presets
{
    [Serializable]
    public class PresetData
    {
        public string presetName = "";
        public List<PresetTarget> targets = new();

        [NonSerialized, JsonIgnore] public Sprite thumbnail;
        public PresetData() { }

        public PresetData(string presetName, List<Target> targets)
        {
            this.presetName = presetName;
            foreach(var target in targets)
            {
                this.targets.Add(new(target));
            }
        }

        [JsonConstructor]
        public PresetData(string presetName, List<PresetTarget> targets)
        {
            this.presetName = presetName;
            this.targets = targets;
        }
    }

    [Serializable]
    public class PresetTarget
    {
        public Cue cue;
        public PathbuilderData pathbuilderData;
        public LegacyPathbuilderData legacyPathbuilderData;
        public bool isPathbuilderTarget;

        [JsonConstructor]
        public PresetTarget(Cue cue, PathbuilderData pathbuilderData, LegacyPathbuilderData legacyPathbuilderData, bool isPathbuilderData)
        {
            this.cue = cue;
            this.pathbuilderData = pathbuilderData;
            this.legacyPathbuilderData = legacyPathbuilderData;
            this.isPathbuilderTarget = isPathbuilderData;
        }

        public PresetTarget(Target target)
        {
            cue = target.ToCue();
            pathbuilderData = target.data.pathbuilderData;
            legacyPathbuilderData = target.data.legacyPathbuilderData;
            isPathbuilderTarget = target.data.isPathbuilderTarget;
        }
    }
}
