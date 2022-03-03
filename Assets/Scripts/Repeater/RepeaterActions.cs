using NotReaper.Models;
using NotReaper.Targets;
using NotReaper.Timing;
using NotReaper.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.Repeaters
{   
    public class AddRepeaterAction : NRAction
    {
        private RepeaterManager manager;
        private string id;
        private QNT_Timestamp startTime;
        private QNT_Timestamp endTime;
        private QNT_Timestamp activeStartTime;
        private QNT_Timestamp activeEndTime;
        private bool flipColors;
        private bool mirrorHorizontally;
        private bool mirrorVertically;
        public bool success;
        public AddRepeaterAction(RepeaterManager manager, string id, QNT_Timestamp startTime, QNT_Timestamp endTime, QNT_Timestamp activeStartTime, QNT_Timestamp activeEndTime, bool flipColors, bool mirrorHorizontally, bool mirrorVertically)
        {
            this.manager = manager;
            this.id = id;
            if(startTime > endTime)
            {
                var temp = startTime;
                startTime = endTime;
                endTime = temp;
            }
            this.startTime = startTime;
            this.endTime = endTime;
            this.activeStartTime = activeStartTime;
            this.activeEndTime = activeEndTime;
            this.flipColors = flipColors;
            this.mirrorHorizontally = mirrorHorizontally;
            this.mirrorVertically = mirrorVertically;
        }

        public override void DoAction(Timeline timeline)
        {
            success = manager.AddRepeaterFromAction(id, startTime, endTime, activeStartTime, activeEndTime, flipColors, mirrorHorizontally, mirrorVertically);
        }

        public override void UndoAction(Timeline timeline)
        {
            manager.RemoveRepeaterFromAction(id, startTime);
        }
    }

    public class RemoveRepeaterAction : NRAction
    {
        private RepeaterManager manager;
        private RepeaterSection section;

        public RemoveRepeaterAction(RepeaterManager manager, RepeaterSection section)
        {
            this.manager = manager;
            this.section = section;
        }

        public override void DoAction(Timeline timeline)
        {
            manager.RemoveRepeaterFromAction(section.ID, section.startTime);
        }

        public override void UndoAction(Timeline timeline)
        {
            manager.AddRepeaterFromAction(section);
        }
    }

    public class MultiRemoveRepeaterAction : NRAction
    {
        private RepeaterManager manager;
        private List<RepeaterSection> sections;
        private RepeaterSection parentSection;
        private string id;

        public MultiRemoveRepeaterAction(RepeaterManager manager, List<RepeaterSection> sections, string id, RepeaterSection parentSection = null)
        {
            this.manager = manager;
            this.sections = sections;
            this.parentSection = parentSection;
            this.id = id;
        }

        public override void DoAction(Timeline timeline)
        {

            for (int i = sections.Count - 1; i >= 0; i--)
            {
                manager.RemoveRepeaterFromAction(id, sections[i].startTime);
            }

            if(parentSection != null)
            {
                manager.RemoveRepeaterFromAction(id, parentSection.startTime);
            }
        }

        public override void UndoAction(Timeline timeline)
        {
            if(parentSection != null)
            {
                manager.CreateParentRepeater(parentSection);
            }
            foreach(var section in sections)
            {
                manager.AddRepeaterFromAction(section);
            }
        }
    }

    public class RenameRepeaterAction : NRAction
    {
        private RepeaterManager manager;
        private string oldID;
        private string newID;

        public RenameRepeaterAction(RepeaterManager manager, string oldID, string newID)
        {
            this.manager = manager;
            this.oldID = oldID;
            this.newID = newID;
        }

        public override void DoAction(Timeline timeline)
        {
            manager.RenameRepeaterFromAction(oldID, newID);
        }

        public override void UndoAction(Timeline timeline)
        {
            manager.RenameRepeaterFromAction(newID, oldID);
        }
    }

    public class BakeRepeaterAction : NRAction
    {
        private RepeaterManager manager;
        private RepeaterSection section;
        public BakeRepeaterAction(RepeaterManager manager, RepeaterSection section)
        {
            this.manager = manager;
            this.section = section;
        }

        public override void DoAction(Timeline timeline)
        {

            manager.BakeRepeaterSectionFromAction(section);
        }

        public override void UndoAction(Timeline timeline)
        {
            manager.CreateChildRepeater(section);
        }
    }

    public class MakeUniqueAction : NRAction
    {
        private RepeaterManager manager;
        private RepeaterSection section;
        private string oldID;

        public string newID;
        public bool success;

        public MakeUniqueAction(RepeaterManager manager, RepeaterSection section, string oldID)
        {
            this.manager = manager;
            this.section = section;
            this.oldID = oldID;
            this.newID = oldID;
        }

        public override void DoAction(Timeline timeline)
        {
            success = manager.MakeSectionUniqueFromAction(section, out newID);
        }

        public override void UndoAction(Timeline timeline)
        {
            manager.UndoMakeSectionUniqueFromAction(section, oldID);
        }
    }
}

