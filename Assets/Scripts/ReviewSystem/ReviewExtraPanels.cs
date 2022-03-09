using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.ReviewSystem
{
    public class ReviewExtraPanels : MonoBehaviour
    {
        public GameObject selectCuesPanel;
        public GameObject makeSuggestionPanel;
        public GameObject viewSuggestionPanel;

        [NRInject] private ReviewManager manager;
        public void OnSelectCuesDoneClicked()
        {
            manager.SelectCues(false);
        }

        public void OnEditDone()
        {
            manager.EditSuggestion();
        }

        public void OnRestoreClicked()
        {
            manager.ShowSuggestion(false);
        }

        public void OnApplyClicked()
        {
            manager.ShowSuggestion(true);
        }
    }
}
