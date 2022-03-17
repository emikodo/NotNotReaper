using NotReaper.Models;
using NotReaper.Overlays;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NotReaper.Tools.ErrorChecker
{
    public class ErrorCheckerUI : NROverlay, IPointerEnterHandler, IPointerExitHandler
    {
        [Space, Header("Error Checker UI")]
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private TextMeshProUGUI errorBody;
        [NRInject] private ErrorChecker checker;

        public override void Hide()
        {
            OnDeactivated();
        }

        public override void Show()
        {
            OnActivated();
        }

        public void OnFixedClicked()
        {
            checker.MarkCurrentFixed();
        }

        public void OnExitClicked()
        {
            EditorState.SetIsInUI(false);
            Hide();
        }

        public void OnNextClicked()
        {
            checker.NextError();
        }

        public void OnPreviousClicked()
        {
            checker.PrevError();
        }

        internal void SetErrorCount(int count)
        {
            countText.text = count.ToString();
        }

        internal void SetErrorBody(string text)
        {
            errorBody.text = $"errors: {text.ToLower()}";
        }

        protected override void OnEditorModeChanged(EditorMode mode)
        {

        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (drag.isMouseDown) return;
            EditorState.SetIsInUI(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (drag.isMouseDown) return;
            EditorState.SetIsInUI(true);
        }
    }
}

