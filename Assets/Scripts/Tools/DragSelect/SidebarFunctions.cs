﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotReaper.Grid;
using NotReaper.Targets;
using NotReaper.UI;
using NotReaper.UserInput;
using NotReaper.Managers;
using NotReaper.Models;
using Sirenix.OdinInspector;
using UnityEngine.UI;

namespace NotReaper.Tools {
    public class SidebarFunctions : MonoBehaviour
    {
        public Timeline timeline;
        
        public UndoRedoManager undoRedoManager;

        [ChildGameObjectsOnly]
        [SerializeField] private List<Button> selectionTools;

        [SerializeField] private GameObject hiddenButtons;
        
        

        private bool notesSelectedState = true;
        
        private void Update() {

            if (notesSelectedState != timeline.areNotesSelected) {
                notesSelectedState = timeline.areNotesSelected;

                hiddenButtons.SetActive(notesSelectedState);
            }
            
        }

        

        public void FlipTargetsVertical() => timeline.FlipSelectedTargetsVertical();
        public void FlipTargetsHorizontal() => timeline.FlipSelectedTargetsHorizontal();
        public void SwapTargets() => timeline.SwapTargets(timeline.selectedNotes);
        public void ReverseTargets() => timeline.Reverse(timeline.selectedNotes);
        public void RotateLeft() => timeline.Rotate(timeline.selectedNotes, 15);
        public void RotateRight() => timeline.Rotate(timeline.selectedNotes, -15);
        //public void ScaleUp() => timeline.Scale(timeline.selectedNotes, 1.1f);
        //public void ScaleDown() => timeline.Scale(timeline.selectedNotes, 0.9f);
        public void undo() => undoRedoManager.Undo();
        public void redo() => undoRedoManager.Redo();
        public void DeselectBehavior(int behavior) => timeline.DeselectBehavior((TargetBehavior)behavior);
        public void DeselectHand(int handType) => timeline.DeselectHand((TargetHandType)handType);
        public void ScaleUpHorizontal() => timeline.ScaleSelectedTargets(new Vector2(1.1f, 1f));
        public void ScaleUpVertical() => timeline.ScaleSelectedTargets(new Vector2(1f, 1.1f));
        public void ScaleDownHorizontal() => timeline.ScaleSelectedTargets(new Vector2(.9f, 1f));
        public void ScaleDownVertical() => timeline.ScaleSelectedTargets(new Vector2(1f, .9f));

    }
}