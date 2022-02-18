using NotReaper;
using NotReaper.Grid;
using NotReaper.Managers;
using NotReaper.Models;
using NotReaper.Tools;
using NotReaper.UI;
using NotReaper.UserInput;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class EditorKeybindController
{
    [Header("References")]
    [SerializeField] private MappingInput mapping;
    [SerializeField] private UIInput ui;

    public void DoRedo(InputAction.CallbackContext obj)
    {
        mapping.Redo();
    }

    public void DoUndo(InputAction.CallbackContext obj)
    {
        mapping.Undo();
    }

    public void Save(InputAction.CallbackContext obj)
    {
        mapping.Save();
    }

    public void DeleteSelectedTargets(InputAction.CallbackContext obj)
    {
        mapping.DeleteSelectedTargets();
    }

    public void Cut(InputAction.CallbackContext obj)
    {
        mapping.CutSelectedTargets();
    }

    public void Paste(InputAction.CallbackContext obj)
    {
        mapping.PasteSelectedTargets();
    }

    public void Copy(InputAction.CallbackContext obj)
    {
        mapping.CopySelectedTargets();
    }

    public void DeselectAllTargets(InputAction.CallbackContext obj)
    {
        mapping.DeselectAllTargets();
    }

    public void SelectAll(InputAction.CallbackContext obj)
    {
        mapping.SelectAllTargets();
    }

    public void ShowReviewMenu(InputAction.CallbackContext obj)
    {
        ui.ShowReviewWindow();
    }

    public void ShowModifierHelp(InputAction.CallbackContext obj)
    {
        ui.ShowModifierHelpWindow();
    }

    public void ShowTimingPoints(InputAction.CallbackContext obj)
    {
        ui.ShowTimingPointsWindow();
    }

    public void ShowModifyAudio(InputAction.CallbackContext obj)
    {
        ui.ShowModifyAudioWindow();
    }

    public void ShowCountin(InputAction.CallbackContext obj)
    {
        ui.ShowCountinWindow();
    }

    public void ToggleWaveform(InputAction.CallbackContext obj)
    {
        ui.ToggleWaveform();
    }

    public void ShowHelp(InputAction.CallbackContext obj)
    {
        ui.ShowHelpWindow();
    }

    public void ShowPause(InputAction.CallbackContext obj)
    {
        ui.ShowPauseWindow();
    }

    public void SetPreviewPoint(InputAction.CallbackContext obj)
    {
        ui.SetPreviewPoint();
    }
    public void MoveTargetsQuarterModifierPressed(InputAction.CallbackContext obj)
    {
        mapping.SetQuarterModifierPressed(obj.performed);
    }

    public void MoveTargetsHalfModifierPressed(InputAction.CallbackContext obj)
    {
        mapping.SetHalfModifierPressed(obj.performed);
    }

    public void MoveTargets(InputAction.CallbackContext obj)
    {
        mapping.MoveTargetsAction(obj.ReadValue<Vector2>());
    }

    public void MoveGrid(InputAction.CallbackContext obj)
    {
        ui.MoveGrid(obj.ReadValue<Vector2>());
    }

    public void OpenBookmarks(InputAction.CallbackContext obj)
    {
        ui.SetBookmark();
    }

    public void ShiftBpmMarker(InputAction.CallbackContext obj)
    {
        ui.ShiftBpmMarker();
    }

    public void DetectBpm(InputAction.CallbackContext obj)
    {
        ui.DetectBpm();
    }

    public void PlaceBpmMarker(InputAction.CallbackContext obj)
    {
        ui.ShowBpmWindow();
    }

    public void ConvertHitsoundSnare(InputAction.CallbackContext obj)
    {
        mapping.SetTargetHitsoundAction(InternalTargetVelocity.Snare);
    }

    public void ConvertHitsoundSilent(InputAction.CallbackContext obj)
    {
        mapping.SetTargetHitsoundAction(InternalTargetVelocity.Silent);
    }

    public void ConvertHitsoundPercussion(InputAction.CallbackContext obj)
    {
        mapping.SetTargetHitsoundAction(InternalTargetVelocity.Percussion);
    }

    public void ConvertHitsoundMelee(InputAction.CallbackContext obj)
    {
        mapping.SetTargetHitsoundAction(InternalTargetVelocity.Melee);
    }

    public void ConvertHitsoundKick(InputAction.CallbackContext obj)
    {
        mapping.SetTargetHitsoundAction(InternalTargetVelocity.Kick);
    }

    public void ConvertHitsoundChainStart(InputAction.CallbackContext obj)
    {
        mapping.SetTargetHitsoundAction(InternalTargetVelocity.ChainStart);
    }

    public void ConvertHitsoundChain(InputAction.CallbackContext obj)
    {
        mapping.SetTargetHitsoundAction(InternalTargetVelocity.Chain);
    }

    public void SelectHitsoundSnare(InputAction.CallbackContext obj)
    {
        EditorState.SelectHitsound(TargetHitsound.Snare);
    }

    public void SelectHitsoundSilent(InputAction.CallbackContext obj)
    {
        EditorState.SelectHitsound(TargetHitsound.Silent);
    }

    public void SelectHitsoundPercussion(InputAction.CallbackContext obj)
    {
        EditorState.SelectHitsound(TargetHitsound.Percussion);
    }

    public void SelectHitsoundMelee(InputAction.CallbackContext obj)
    {
        EditorState.SelectHitsound(TargetHitsound.Melee);
    }

    public void SelectHitsoundKick(InputAction.CallbackContext obj)
    {
        EditorState.SelectHitsound(TargetHitsound.Standard);
    }

    public void SelectHitsoundChainStart(InputAction.CallbackContext obj)
    {
        EditorState.SelectHitsound(TargetHitsound.ChainStart);
    }

    public void SelectHitsoundChain(InputAction.CallbackContext obj)
    {
        EditorState.SelectHitsound(TargetHitsound.ChainNode);
    }
    public void QuickSwitchNoGrid(InputAction.CallbackContext obj)
    {
        if (obj.performed) EditorState.SelectSnappingMode(EditorState.Snapping.Current == SnappingMode.None ? EditorState.Behavior.Current == TargetBehavior.Melee ? SnappingMode.Melee : SnappingMode.Grid : SnappingMode.None);
        else if (obj.canceled) EditorState.SelectSnappingMode(EditorState.Snapping.Previous);
    }

    public void SelectSnapNone(InputAction.CallbackContext obj)
    {
        //ui.SelectSnappingMode(SnappingMode.None);
        EditorState.SelectSnappingMode(SnappingMode.None);
    }

    public void SelectSnapMelee(InputAction.CallbackContext obj)
    {
        //ui.SelectSnappingMode(SnappingMode.Melee);
        EditorState.SelectSnappingMode(SnappingMode.Melee);
    }

    public void SelectSnapGrid(InputAction.CallbackContext obj)
    {
        EditorState.SelectSnappingMode(SnappingMode.Grid);
        //ui.SelectSnappingMode(SnappingMode.Grid);
    }

    public void ConvertToVertical(InputAction.CallbackContext obj)
    {
        mapping.SetTargetBehaviorAction(TargetBehavior.Vertical);
    }

    public void ConvertToSustain(InputAction.CallbackContext obj)
    {
        mapping.SetTargetBehaviorAction(TargetBehavior.Sustain);
    }

    public void ConvertToStandard(InputAction.CallbackContext obj)
    {
        mapping.SetTargetBehaviorAction(TargetBehavior.Standard);
    }

    public void ConvertToMine(InputAction.CallbackContext obj)
    {
        mapping.SetTargetBehaviorAction(TargetBehavior.Mine);
    }

    public void ConvertToMelee(InputAction.CallbackContext obj)
    {
        mapping.SetTargetBehaviorAction(TargetBehavior.Melee);
    }

    public void ConvertToHorizontal(InputAction.CallbackContext obj)
    {
        mapping.SetTargetBehaviorAction(TargetBehavior.Horizontal);
    }

    public void ConvertToChainstart(InputAction.CallbackContext obj)
    {
        mapping.SetTargetBehaviorAction(TargetBehavior.ChainStart);
    }

    public void ConvertToChain(InputAction.CallbackContext obj)
    {
        mapping.SetTargetBehaviorAction(TargetBehavior.ChainNode);
    }

    public void SelectDrag(InputAction.CallbackContext obj)
    {
        EditorState.SelectTool(EditorTool.DragSelect);
        //mapping.DragSelectTool(obj.performed);
    }

    public void SelectModifiers(InputAction.CallbackContext obj)
    {
        mapping.ToggleModifiers();
        //ui.SelectTool(EditorTool.ModifierCreator);
    }

    private bool useLegacy = false;
    public void SelectPathbuilder(InputAction.CallbackContext obj)
    {
        if (KeybindManager.Global.IsCtrlDown)
        {
            useLegacy = !useLegacy;
        }

        if(useLegacy)
        {
            EditorState.SelectTool(EditorTool.ChainBuilder);
            //mapping.ToggleChainbuilder();
        }
        else
        {
            EditorState.SelectTool(EditorTool.Pathbuilder);
            //mapping.TogglePathbuilder();
        }
    }

    public void ActivateModifierPreview(InputAction.CallbackContext obj)
    {
        mapping.ToggleModifierPreview();
    }

    public void SelectVertical(InputAction.CallbackContext obj)
    {
        //ui.SelectBehavior(EditorTool.Vertical);
        EditorState.SelectBehavior(TargetBehavior.Vertical);
    }

    public void SelectSustain(InputAction.CallbackContext obj)
    {
        //ui.SelectBehavior(TargetBehavior.Hold);
        EditorState.SelectBehavior(TargetBehavior.Sustain);
    }

    public void SelectStandard(InputAction.CallbackContext obj)
    {
        //EditorState.SetSelectedBehavior(TargetBehavior.Standard);
        EditorState.SelectBehavior(TargetBehavior.Standard);
        //ui.SelectBehavior(TargetBehavior.Standard);
    }

    public void SelectMine(InputAction.CallbackContext obj)
    {
        //ui.SelectBehavior(TargetBehavior.Mine);
        EditorState.SelectBehavior(TargetBehavior.Mine);
    }

    public void SelectMelee(InputAction.CallbackContext obj)
    {
        //ui.SelectBehavior(TargetBehavior.Melee);
        EditorState.SelectBehavior(TargetBehavior.Melee);
    }

    public void SelectHorizontal(InputAction.CallbackContext obj)
    {
        //ui.SelectBehavior(TargetBehavior.Horizontal);
        EditorState.SelectBehavior(TargetBehavior.Horizontal);
    }

    public void SelectChainStart(InputAction.CallbackContext obj)
    {
        //ui.SelectBehavior(TargetBehavior.ChainStart);
        EditorState.SelectBehavior(TargetBehavior.ChainStart);
    }

    public void SelectChain(InputAction.CallbackContext obj)
    {
        //ui.SelectBehavior(TargetBehavior.ChainNode);
        EditorState.SelectBehavior(TargetBehavior.ChainNode);
    }
    public void RotateSelectedTargetsRight(InputAction.CallbackContext obj)
    {
        mapping.RotateSelectedTargetsRight();
    }

    public void RotateSelectedTargetsLeft(InputAction.CallbackContext obj)
    {
        mapping.RotateSelectedTargetsLeft();
    }

    public void ReverseSelectedTargets(InputAction.CallbackContext obj)
    {
        mapping.ReverseSelectedTargets();
    }

    public void DecreaseScaleVertical(InputAction.CallbackContext obj)
    {
        mapping.ScaleSelectedTargets(new Vector2(0f, -.1f));
    }

    public void DecreaseScaleHorizontal(InputAction.CallbackContext obj)
    {
        mapping.ScaleSelectedTargets(new Vector2(-.1f, 0f));
    }

    public void IncreaseScaleVertical(InputAction.CallbackContext obj)
    {
        mapping.ScaleSelectedTargets(new Vector2(0f, .1f));
    }

    public void IncreaseScaleHorizontal(InputAction.CallbackContext obj)
    {
        mapping.ScaleSelectedTargets(new Vector2(.1f, 0f));
    }

    public void FlipTargetsVertical(InputAction.CallbackContext obj)
    {
        mapping.FlipTargetsVertical();
    }

    public void FlipTargetsHorizontal(InputAction.CallbackContext obj)
    {
        mapping.FlipTargetsHorizontal();
    }

    public void FlipTargetColors(InputAction.CallbackContext obj)
    {
        mapping.FlipTargetColors();
    }

    public void ToggleHandColor(InputAction.CallbackContext obj)
    {
        EditorState.SelectHand(EditorState.Hand.Current == TargetHandType.Left ? TargetHandType.Right : TargetHandType.Left);
    }
    public void ScrubByTick(InputAction.CallbackContext obj)
    {
        mapping.ScrubTimeline(obj.ReadValue<float>(), true);
    }

    public void ChangeBeatSnap(InputAction.CallbackContext obj)
    {
        mapping.ChangeBeatSnap(obj.ReadValue<float>());
    }

    public void ScrubTimeline(InputAction.CallbackContext obj)
    {
        mapping.ScrubTimeline(obj.ReadValue<float>(), false);
    }

    public void ZoomTimeline(InputAction.CallbackContext obj)
    {
        mapping.ZoomTimeline(obj.ReadValue<float>());
    }

    public void StartMetronome(InputAction.CallbackContext obj)
    {
        mapping.TogglePlayPause(true);
    }

    public void TogglePlay(InputAction.CallbackContext obj)
    {
        mapping.TogglePlayPause(false);
    }

    public void EnableSpacingSnap(InputAction.CallbackContext obj)
    {
        mapping.ActivateSnapper(obj.performed);
    }

    public void RemoveNote(InputAction.CallbackContext obj)
    {
        mapping.RemoveNote();
    }

    public void PlaceNote(InputAction.CallbackContext obj)
    {
        mapping.PlaceNote();
    }

    public void OnShift(InputAction.CallbackContext obj)
    {

    }

    public void OnAlt(InputAction.CallbackContext obj)
    {

    }

    public void OnControl(InputAction.CallbackContext obj)
    {

    }
}
