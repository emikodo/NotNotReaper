using NotReaper;
using NotReaper.Targets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper
{
    public class TimelineTargetCatcher : MonoBehaviour
    {
        [SerializeField] private Transform timelineNotesParent;
        /*
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "TimelineTarget")
            {
                collision.gameObject.GetComponent<TargetIcon>().ShowTimelineTarget();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "TimelineTarget")
            {
                collision.gameObject.GetComponent<TargetIcon>().HideTimelineTarget();
            }
        }
        */
    }
}
