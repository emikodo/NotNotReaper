using NotReaper.Timing;
using NotReaper.Tools;
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

        public AddRepeaterAction(RepeaterManager manager, string id, QNT_Timestamp startTime, QNT_Timestamp endTime)
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
        }

        public override void DoAction(Timeline timeline)
        {
            manager.AddRepeater(id, startTime, endTime);
        }

        public override void UndoAction(Timeline timeline)
        {
            manager.RemoveRepeater(id, startTime);
        }
    }
}

