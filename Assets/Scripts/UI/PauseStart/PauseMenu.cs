﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NotReaper.Models;
using NotReaper.UserInput;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
namespace NotReaper.UI {


    public class PauseMenu : NRInputWithoutKeybinds {

        public static PauseMenu Instance = null;

        private UIInput uiInput;
        public Timeline timeline;
        public Button saveButton;
        public Button newAudicaButton;
        [SerializeField] RecentPanel recentPanel;
        public Button selectSongButton;
        public Button generateButton;

        public CanvasGroup window;
        public Image BG;

        public bool isOpened = false;
        private BoxCollider2D[] colliders;

        public void Start() {
            if(Instance != null)
            {
                Debug.Log("PauseMenu already exists.");
                return;
            }
            Instance = this;
            var t = transform;
            var position = t.localPosition;
            colliders = GetComponents<BoxCollider2D>();
            t.localPosition = new Vector3(0, position.y, position.z);
            //recentPanel.Show();
            gameObject.SetActive(false);
        }

        public void NewAudica() {
            ClosePauseMenu();
            if (Timeline.audicaLoaded)
            {
                timeline.Export();
                System.Diagnostics.Process.Start(Application.dataPath + "/../NotReaper.exe");
                Application.Quit();
            }
            EditorState.SelectMode(EditorMode.Timing);
            Timeline.inTimingMode = true;
            //newAudicaButton.interactable = false;
            
        }

        public void Open() {
            //bool loaded = timeline.LoadAudicaFile(false);
            //if (loaded) ClosePauseMenu();
            //editorInput.FigureOutIsInUI();
            
        }

        public void OpenRecent() {
            //bool loaded = timeline.LoadAudicaFile(true);
            //if (loaded) ClosePauseMenu();
            //editorInput.FigureOutIsInUI();
        }

        public void OpenPauseMenu() {
            return;
            gameObject.SetActive(true);
            OnActivated();
            isOpened = true;
            EnableColliders(true);
            if (Timeline.audicaLoaded) {
                saveButton.interactable = true;
            } else {
                saveButton.interactable = false;
            }

            //newAudicaButton.interactable = !Timeline.audicaLoaded;
            BG.gameObject.SetActive(true);
            window.gameObject.SetActive(true);
            //recentPanel.Show();

        }

        public void ClosePauseMenu() {
            isOpened = false;
            OnDeactivated();
            EnableColliders(false);
            BG.gameObject.SetActive(false);
            window.gameObject.SetActive(false);
            gameObject.SetActive(false);

        }

        private void EnableColliders(bool enable)
        {
            foreach (var collider in colliders) collider.enabled = enable;
        }

        protected override void OnEscPressed(InputAction.CallbackContext context)
        {
            if (Timeline.audicaLoaded) ClosePauseMenu();
        }
    }

}