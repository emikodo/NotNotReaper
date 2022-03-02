using NotReaper.Notifications;
using NotReaper.Overlays;
using NotReaper.UI.Components;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NotReaper.Repeaters
{
    public class RepeaterMenu : NRMenu
    {
        [Header("References")]
        [SerializeField] private TMP_InputField inputID;
        [SerializeField] private NRButton buttonInsertCreateRepeater;
        [SerializeField] private NRButton buttonRenameRepeater;
        [SerializeField] private NRButton buttonMakeUnique;
        [SerializeField] private NRButton buttonDelete;
        [SerializeField] private NRButton buttonClose;
        [SerializeField] private TMP_InputField inputRename;
        [SerializeField] private RepeaterListEntry repeaterListEntryPrefab;
        [SerializeField] private GameObject hint;
        [SerializeField] private Transform contentParent;

        private RepeaterManager manager;
        private List<RepeaterListEntry> repeaterListEntries;
        private bool isRenaming = false;
        private State state = State.Disabled;
        private RepeaterIndicator activeSection;
        private Timeline timeline;

        public bool isActive;

        private void Start()
        {
            manager = NRDependencyInjector.Get<RepeaterManager>();
            timeline = NRDependencyInjector.Get<Timeline>();
            repeaterListEntries = new();
            transform.position = Vector3.zero;
            Reset();
            gameObject.SetActive(false);
        }

        private void Reset()
        {
            buttonMakeUnique.gameObject.SetActive(false);
            buttonDelete.gameObject.SetActive(false);
            hint.gameObject.SetActive(false);
            inputID.text = "";
            state = State.Disabled;
            isRenaming = false;
            buttonRenameRepeater.SetText("rename");
            inputRename.text = "";
            inputRename.gameObject.SetActive(false);
            if(activeSection != null)
            {
                activeSection.SetSectionActive(false);
                activeSection = null;
            }
        }

        internal void SelectRepeater(string id)
        {
            inputID.SetTextWithoutNotify(id);
            UpdateState();
        }

        public void ValidateID()
        {
            UpdateState();
        }

        public void Show()
        {
            isActive = true;
            manager.SetRepeatersInteractable(true);
            UpdateState();
            OnActivated();
        }

        public void Hide()
        {
            isActive = false;
            manager.SetRepeatersInteractable(false);
            Reset();
            OnDeactivated();
        }

        public void OnRenameClicked()
        {
            if (!isRenaming)
            {
                inputRename.gameObject.SetActive(true);
                buttonRenameRepeater.SetText("apply");
            }
            else
            {
                if (string.IsNullOrEmpty(inputRename.text))
                {
                    NotificationCenter.SendNotification("Please enter a new ID into the rename input field.", NotificationType.Warning);
                    return;
                }
                if (manager.RepeaterExists(inputRename.text))
                {
                    NotificationCenter.SendNotification("ID already exists. Please choose a different one.", NotificationType.Warning);
                    return;
                }
                manager.RenameRepeater(inputID.text, inputRename.text);
                foreach (var entry in repeaterListEntries)
                {
                    entry.SetID(inputRename.text);
                }
                inputID.text = inputRename.text;
                inputRename.text = "";
                inputRename.gameObject.SetActive(false);
                buttonRenameRepeater.SetText("rename");
            }
            isRenaming = !isRenaming;
        }

        public void OnInsertCreateClicked()
        {
            if (string.IsNullOrEmpty(inputID.text))
            {
                NotificationCenter.SendNotification("Please enter an ID to create or insert a repeater.", NotificationType.Error);
                return;
            }
            UpdateState();
            if (state == State.Insert)
            {
                manager.AddRepeater(inputID.text, Timeline.time);
            }
            else
            {
                if(!manager.AddRepeater(inputID.text, timeline.selectedNotes.First().data.time, timeline.selectedNotes.Last().data.time))
                {
                    return;
                }
                SpawnRepeaterEntry(inputID.text);
                timeline.DeselectAllTargets();
            }
            if(activeSection != null)
            {
                activeSection.SetSectionActive(false);
                activeSection = null;
            }
            UpdateState();
        }

        public void SpawnRepeaterEntry(string ID)
        {
            var entry = Instantiate(repeaterListEntryPrefab, contentParent);
            entry.SetID(ID);
            repeaterListEntries.Add(entry);
        }

        public void OnMakeUniqueClicked()
        {
            if (manager.MakeSectionUnique(activeSection.GetSection(), out string newID))
            {
                activeSection.SetText(newID);
                SpawnRepeaterEntry(newID);
                UpdateState();
            }
        }

        public void OnDeleteClicked()
        {
            manager.RemoveRepeater(activeSection.GetSection().ID, activeSection.GetSection().startTime);
            activeSection = null;
            UpdateState();
        }

        private void UpdateState()
        {
            string currentID = inputID.text;
            hint.SetActive(false);
            buttonInsertCreateRepeater.gameObject.SetActive(true);
            if (manager.RepeaterExists(currentID))
            {
                buttonInsertCreateRepeater.SetText("insert");
                state = State.Insert;
            }
            else
            {
                if (timeline.selectedNotes.Count < 2)
                {
                    hint.SetActive(true);
                    buttonInsertCreateRepeater.gameObject.SetActive(false);
                    state = State.Disabled;
                    return;
                }
                buttonInsertCreateRepeater.SetText("create");
                state = State.Create;
            }
            buttonMakeUnique.gameObject.SetActive(activeSection != null);
            buttonDelete.gameObject.SetActive(activeSection != null);
        }

        public void SetActiveSection(RepeaterIndicator section)
        {
            if (activeSection != null) activeSection.SetSectionActive(false);
            section.SetSectionActive(true);
            activeSection = section;
            inputID.SetTextWithoutNotify(activeSection.GetSection().ID);
            UpdateState();
        }

        public void RemoveEntry(string id)
        {
            var entry = repeaterListEntries.Where(e => e.GetID() == id).First();
            repeaterListEntries.Remove(entry);
            Destroy(entry);

        }

        protected override void OnEscPressed(InputAction.CallbackContext context)
        {
            Hide();
        }

        private enum State
        {
            Create,
            Insert,
            Disabled
        }

    }

}
