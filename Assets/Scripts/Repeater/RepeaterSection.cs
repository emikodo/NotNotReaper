using NotReaper.Models;
using NotReaper.Targets;
using NotReaper.Timing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NotReaper.Repeaters
{
    [Serializable]
    public class RepeaterSection
    {
        public string ID;
        [NonSerialized]
        public bool isParent;
        public bool flipTargetColors;
        public bool mirrorHorizontally;
        public bool mirrorVertically;
        public QNT_Timestamp startTime;
        public QNT_Timestamp endTime;

        public QNT_Timestamp activeStartTime;
        public QNT_Timestamp activeEndTime;
        public List<TargetData> targets;
        public List<ulong> targetTimes = new List<ulong>();
        [NonSerialized] public RepeaterIndicator indicator;
        [NonSerialized] private Timeline timeline;

        private ulong targetIndexID = 0;

        public RepeaterSection(string ID, bool isParent, QNT_Timestamp startTime, QNT_Timestamp endTime, QNT_Timestamp activeEndTime, RepeaterIndicator indicator, List<TargetData> targets, Timeline timeline)
        {
            this.ID = ID;
            this.startTime = activeStartTime = startTime;
            this.endTime = endTime;
            this.activeEndTime = activeEndTime;
            this.timeline = timeline;
            this.indicator = indicator;
            this.targets = targets;
            this.isParent = isParent;

            foreach(var target in targets)
            {
                target.repeaterData.Section = this;
                target.repeaterData.targetID = targetIndexID;
                targetIndexID++;
            }
        }

        public RepeaterSection(string ID, bool isParent, bool flipTargetColors, bool mirrorHorizontally, bool mirrorVertically, QNT_Timestamp startTime, QNT_Timestamp activeStartTime, QNT_Timestamp endTime, QNT_Timestamp activeEndTime, RepeaterIndicator indicator, List<TargetData> targets, Timeline timeline)
        {
            this.ID = ID;
            this.startTime = startTime;
            this.activeStartTime = activeStartTime;
            this.endTime = endTime;
            this.activeEndTime = activeEndTime;
            this.timeline = timeline;
            this.indicator = indicator;
            this.targets = targets;
            this.isParent = isParent;
            this.flipTargetColors = flipTargetColors;
            this.mirrorHorizontally = mirrorHorizontally;
            this.mirrorVertically = mirrorVertically;

            foreach (var target in targets)
            {
                target.repeaterData.Section = this;
                target.repeaterData.targetID = targetIndexID;
                targetIndexID++;
            }
        }

        public void Copy(RepeaterSection section)
        {
            ID = section.ID;
            startTime = section.startTime;
            endTime = section.endTime;
            activeStartTime = section.activeStartTime;
            activeEndTime = section.activeEndTime;
        }

        public RepeaterSection() { }

        public bool Contains(QNT_Timestamp time)
        {
            return time >= activeStartTime && time <= activeEndTime;
        }

        public void SetActiveStartTime(QNT_Timestamp time)
        {
            activeStartTime = time;
            UpdateActiveNotes();
        }

        public void SetActiveEndTime(QNT_Timestamp time)
        {
            activeEndTime = time;
            UpdateActiveNotes();
        }

        public void SetIsParent(bool isParent)
        {
            this.isParent = isParent;
            indicator.SetIsParent(isParent);
        }

        public void CreateRepeaterTarget(TargetData data)
        {
            TargetData repeaterTarget = new TargetData();
            repeaterTarget.Copy(data);
            repeaterTarget.repeaterData = new RepeaterData();
            repeaterTarget.repeaterData.Copy(data.repeaterData);
            repeaterTarget.SetTimeFromAction(new QNT_Timestamp(startTime.tick + repeaterTarget.repeaterData.RelativeTime.tick));
            repeaterTarget.repeaterData.Section = this;
            repeaterTarget.repeaterData.targetID = targetIndexID;
            targetIndexID++;
            targets.Add(repeaterTarget);
            if(repeaterTarget.time >= activeStartTime && repeaterTarget.time <= activeEndTime)
            {
                timeline.AddTargetFromAction(repeaterTarget);
            }
        }

        public void RemoveRepeaterTargetAtRelativeTime(TargetData data)
        {
            /*
            TargetData matchingTarget = data;

            if (flipTargetColors)
            {
                foreach (var target in targets)
                {
                    if (target.repeaterData.RelativeTime == data.repeaterData.RelativeTime)
                    {
                        if (target.behavior == TargetBehavior.Melee && data.behavior == TargetBehavior.Melee)
                        {
                            matchingTarget = target;
                        }
                        else if (target.behavior == data.behavior &&
                        ((target.handType == TargetHandType.Left && data.handType == TargetHandType.Right) ||
                        (target.handType == TargetHandType.Right && data.handType == TargetHandType.Left)))
                        {
                            matchingTarget = target;
                        }
                    }

                }
            }
            */

            //var target = targets.First(t => t.repeaterData.RelativeTime == data.repeaterData.RelativeTime && t.behavior == data.behavior && t.handType == data.handType);
            var target = targets.First(t => t.repeaterData.targetID == data.repeaterData.targetID);
            targets.Remove(target);
            timeline.DeleteTargetFromAction(target);
        }

        public void UpdateActiveNotes()
        {
            foreach(var target in targets)
            {
                if(target.time >= activeStartTime && target.time <= activeEndTime)
                {
                    if(timeline.FindNote(target) == null)
                    {
                        timeline.AddTargetFromAction(target);
                    }
                    if (target.isPathbuilderTarget)
                    {
                        foreach(var segment in target.pathbuilderData.Segments)
                        {
                            foreach(var node in segment.generatedNodes)
                            {
                                if(node.time > activeEndTime)
                                {
                                    timeline.DeleteTargetFromAction(node);
                                }
                                else if(timeline.FindNote(node) == null)
                                {
                                    timeline.AddTargetFromAction(node);
                                }
                            }
                        }
                    }
                }
                else
                {
                    timeline.DeleteTargetFromAction(target);
                }
            }
        }

        public void FixScaling()
        {
            indicator.FixScaling();
        }

        public void RenameID(string newID)
        {
            ID = newID;
            if(indicator != null)
            {
                indicator.SetText(newID);
            }
        }

        public void SaveTargetTimes()
        {
            targetTimes.Clear();
            foreach(var target in targets)
            {
                targetTimes.Add(target.time.tick);
            }
        }
    }
}
