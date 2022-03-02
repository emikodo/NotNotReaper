using NotReaper.UI.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.Repeaters
{
    [RequireComponent(typeof(NRButton))]
    public class RepeaterListEntry : MonoBehaviour
    {
        [SerializeField] private NRButton button;
        private RepeaterMenu overlay;
        private string myID = "";
        private void Start()
        {
            button = GetComponent<NRButton>();
            overlay = NRDependencyInjector.Get<RepeaterMenu>();
        }

        internal void SetID(string id)
        {
            myID = id;
            button.SetText(id);
        }

        internal string GetID()
        {
            return myID;
        }

        public void OnClick()
        {
            overlay.SelectRepeater(myID);
        }
    }
}

