using NotReaper.UI.Components;
using NotReaper.UserInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using TMPro;
using NotReaper.Models;
using NotReaper.Notifications;
using System.Linq;

namespace NotReaper.Tools.Presets
{
    public class PresetUI : NRMenu
    {
        [SerializeField] private PresetEntry entryPrefab;
        [SerializeField] private Transform presetParent;
        [SerializeField] private GameObject hintText;
        [SerializeField] private CanvasGroup confirmationPrompt;
        [SerializeField] private TextMeshProUGUI presetNameText;
        [SerializeField] private NRInputField inputName;
        
        private CanvasGroup canvas;
        private PresetEntry entryToDelete;
        [NRInject] private PresetManager manager;
        [NRInject] private Timeline timeline;

        private List<PresetEntry> entries = new();

        protected override void Awake()
        {
            base.Awake();
            canvas = GetComponent<CanvasGroup>();
            canvas.alpha = 0f;
            confirmationPrompt.alpha = 0f;
            confirmationPrompt.gameObject.SetActive(false);
            hintText.SetActive(true);
            gameObject.SetActive(false);
        }

        private void Start()
        {
            Timeline.instance.OnSelectedNoteCountChanged.AddListener(OnSelectedNoteCountChanged);
        }

        private void OnSelectedNoteCountChanged(int count)
        {
            ShowHint(count == 0);
        }

        internal void AddPreset(PresetData data)
        {
            canvas.alpha = 1f;

            if (!UpdateEntry(data))
            {
                var entry = Instantiate(entryPrefab, presetParent);
                entry.preset = data;
                entries.Add(entry);
            }
            
        }

        public void OnCreatePresetClicked()
        {
            if (string.IsNullOrEmpty(inputName.text))
            {
                NotificationCenter.SendNotification("Come on, give your preset a pretty name. May I suggest SugarBalls?", NotificationType.Error);
                return;
            }
            canvas.alpha = 0f;
            manager.SavePreset(inputName.text, timeline.selectedNotes, AddPreset);
        }

        internal void OnDelete(PresetEntry entry)
        {
            entryToDelete = entry;
            presetNameText.text = entry.preset.presetName;
            presetNameText.color = EditorState.Hand.Current == TargetHandType.Left ? NRSettings.config.leftColor : NRSettings.config.rightColor;
            confirmationPrompt.gameObject.SetActive(true);
            confirmationPrompt.DOFade(1f, .3f);
        }

        internal bool UpdateEntry(PresetData data)
        {
            var entry = entries.FirstOrDefault(e => e.preset.presetName == data.presetName);
            if(entry != null)
            {
                entry.preset = data;
                return true;
            }
            return false;
        }

        public void OnDeleteConfirmed()
        {
            manager.DeletePreset(entryToDelete.preset);
            if(entryToDelete != null)
            {
                entries.Remove(entryToDelete);
                Destroy(entryToDelete.gameObject);
            }
            entryToDelete = null;
            FadeoutConfirmationPrompt();
        }

        public void OnDeleteCanceled()
        {
            FadeoutConfirmationPrompt();
        }

        private void FadeoutConfirmationPrompt()
        {
            confirmationPrompt.DOFade(0f, .3f).OnComplete(() =>
            {
                confirmationPrompt.gameObject.SetActive(false);
            });
        }

        private void ShowHint(bool show)
        {
            hintText.SetActive(show);
        }

        public override void Hide()
        {
            canvas.DOFade(0f, .3f).OnComplete(() =>
            {
                OnDeactivated();
            });
        }

        public override void Show()
        {
            OnActivated();
            canvas.DOFade(1f, .3f);
        }

        protected override void OnEscPressed(InputAction.CallbackContext context)
        {
            Hide();
        }
    }

}
