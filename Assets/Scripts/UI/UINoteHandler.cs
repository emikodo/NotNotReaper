using NotReaper.Grid;
using NotReaper.Models;
using UnityEngine;
using UnityEngine.UI;
using NotReaper.Targets;
using NotReaper.UserInput;

namespace NotReaper.UI 
{
    public class UINoteHandler : MonoBehaviour 
    {
        public Timeline timeline;

        [SerializeField] private Dropdown soundDropdown;

        public TargetIcon hover;

        public NoteGridSnap noteGrid;

        public UIInput uiInput;

        public void SelectLeftHand() 
        {
            EditorState.SelectHand(TargetHandType.Left);
        }

        public void SelectRightHand() 
        {
            EditorState.SelectHand(TargetHandType.Right);
        }

        public void SelectEitherHand() 
        {
            EditorState.SelectHand(TargetHandType.Either);
        }

        public void SelectNoHand() 
        {
            EditorState.SelectHand(TargetHandType.None);
        }

        public void SelectStandard() 
        {
            EditorState.SelectBehavior(TargetBehavior.Standard);
        }

        public void SelectHold() {
            EditorState.SelectBehavior(TargetBehavior.Sustain);
        }

        public void SelectChainNode() {
            EditorState.SelectBehavior(TargetBehavior.ChainNode);
        }

        public void SelectChainStart() {
            EditorState.SelectBehavior(TargetBehavior.ChainStart);
        }

        public void SelectHorizontal() {
            EditorState.SelectBehavior(TargetBehavior.Horizontal);
        }

        public void SelectVertical() {
            EditorState.SelectBehavior(TargetBehavior.Vertical);
        }

        public void SelectMelee() {
            EditorState.SelectBehavior(TargetBehavior.Melee);
        }

        public void SelectDragSelect() {
            EditorState.SelectTool(EditorTool.DragSelect);
        }

        public void SelectChainBuilder() {
            EditorState.SelectTool(EditorTool.Pathbuilder);
        }
    }
}