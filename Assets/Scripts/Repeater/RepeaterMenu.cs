using DG.Tweening;
using NotReaper.Models;
using NotReaper.Notifications;
using NotReaper.Overlays;
using NotReaper.UI.Components;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
        [SerializeField] private NRButton buttonDeleteChildren;
        [SerializeField] private NRButton buttonClose;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private Toggle toggleFlipTargetColors;
        [SerializeField] private Toggle toggleMirrorHorizontally;
        [SerializeField] private Toggle toggleMirrorVertically;
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
        private CanvasGroup canvas;
        public bool isActive;

        private void Start()
        {
            manager = NRDependencyInjector.Get<RepeaterManager>();
            timeline = NRDependencyInjector.Get<Timeline>();
            repeaterListEntries = new();
            GetComponent<Canvas>().worldCamera = Camera.main;
            canvas = GetComponent<CanvasGroup>();
            canvas.alpha = 0f;
            transform.position = Vector3.zero;
            Reset();
            gameObject.SetActive(false);
        }

        private void Reset()
        {
            buttonMakeUnique.gameObject.SetActive(false);
            buttonDelete.SetText("delete");
            buttonDelete.gameObject.SetActive(false);
            buttonDeleteChildren.gameObject.SetActive(false);
            hint.gameObject.SetActive(false);
            inputID.text = "";
            state = State.Disabled;
            isRenaming = false;
            buttonRenameRepeater.SetText("rename");
            inputRename.text = "";
            inputRename.gameObject.SetActive(false);
            settingsPanel.gameObject.SetActive(false);
            toggleMirrorHorizontally.SetIsOnWithoutNotify(false);
            toggleFlipTargetColors.SetIsOnWithoutNotify(false);
            toggleMirrorVertically.SetIsOnWithoutNotify(false);
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

        public override void Show()
        {
            isActive = true;
            manager.SetRepeatersInteractable(true);
            UpdateState();
            OnActivated();
            canvas.DOFade(1f, .3f);
        }

        public override void Hide()
        {
            isActive = false;
            canvas.DOFade(0f, .3f).OnComplete(() =>
            {
                manager.SetRepeatersInteractable(false);
                Reset();
                OnDeactivated();
            });
            
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
                inputID.text = inputRename.text;
                inputRename.text = "";
                inputRename.gameObject.SetActive(false);
                buttonRenameRepeater.SetText("rename");
            }
            isRenaming = !isRenaming;
        }

        public void UpdateRepeaterID(string oldID, string newID)
        {
            repeaterListEntries.First(e => e.GetID() == oldID).SetID(newID);
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
            string id = activeSection.GetSection().ID;
            if (activeSection.GetSection().isParent)
            {
                manager.RemoveAllRepeatersWithID(id);
                inputID.text = "";
            }
            else
            {
                manager.RemoveRepeater(activeSection.GetSection());
            }
            activeSection = null;
            UpdateState();
        }

        public void OnDeleteChildrenClicked()
        {
            manager.RemoveAllChildRepeaters(activeSection.GetSection().ID);
            UpdateState();
        }

        public void OnFlipTargetColorsToggled()
        {
            manager.FlipRepeaterTargetColors(activeSection.GetSection().ID, activeSection.GetSection().startTime, toggleFlipTargetColors.isOn);
        }

        public void OnMirrorHorizontallyToggled()
        {
            manager.MirrorRepeaterHorizontally(activeSection.GetSection().ID, activeSection.GetSection().startTime, toggleMirrorHorizontally.isOn);
        }

        public void OnMirrorVerticallyToggled()
        {
            manager.MirrorRepeaterVertically(activeSection.GetSection().ID, activeSection.GetSection().startTime, toggleMirrorVertically.isOn);
        }

        public void OnBakeClicked()
        {
            manager.BakeRepeaterSection(activeSection.GetSection());
            activeSection = null;
            UpdateState();
        }

        private void UpdateState()
        {
            string currentID = inputID.text;
            hint.SetActive(false);
            buttonInsertCreateRepeater.gameObject.SetActive(true);
            buttonMakeUnique.gameObject.SetActive(false);
            buttonDelete.gameObject.SetActive(false);
            buttonDeleteChildren.gameObject.SetActive(false);
            buttonRenameRepeater.gameObject.SetActive(false);
            settingsPanel.SetActive(false);
            if (manager.RepeaterExists(inputID.text))
            {
                buttonRenameRepeater.gameObject.SetActive(true);
            }

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
            
            if(activeSection != null)
            {
                buttonDelete.gameObject.SetActive(true);
                
                if (activeSection.GetSection().isParent)
                {
                    buttonDelete.SetText("delete all");
                    buttonDeleteChildren.gameObject.SetActive(true);
                }
                else
                {
                    buttonDelete.SetText("delete");
                    buttonMakeUnique.gameObject.SetActive(true);
                    settingsPanel.SetActive(true);
                }
            }
        }

        public void SetActiveSection(RepeaterIndicator section)
        {
            if (activeSection != null) activeSection.SetSectionActive(false);
            section.SetSectionActive(true);
            activeSection = section;
            inputID.SetTextWithoutNotify(activeSection.GetSection().ID);
            toggleFlipTargetColors.SetIsOnWithoutNotify(activeSection.GetSection().flipTargetColors);
            toggleMirrorVertically.SetIsOnWithoutNotify(activeSection.GetSection().mirrorVertically);
            toggleMirrorHorizontally.SetIsOnWithoutNotify(activeSection.GetSection().mirrorHorizontally);
            UpdateState();
        }

        public void RemoveEntry(string id)
        {
            var entry = repeaterListEntries.Where(e => e.GetID() == id).First();
            repeaterListEntries.Remove(entry);
            Destroy(entry.gameObject);

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
