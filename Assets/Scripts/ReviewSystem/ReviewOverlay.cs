using NotReaper.Overlays;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.ReviewSystem
{
    public class ReviewOverlay : NROverlay
    {
        public void Show()
        {
            OnActivated();
        }

        public void Hide()
        {
            OnDeactivated();
        }
    }
}

