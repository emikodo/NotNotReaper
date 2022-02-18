using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NotReaper.UserInput;
using NotReaper.Grid;
using NotReaper.UI;
using NotReaper.Tools;
using NotReaper;
using NotReaper.Managers;
using NotReaper.ReviewSystem;
using System;
using UnityEditor;

public partial class EditorKeybindController : NRInput<EditorKeybinds>
{

    protected override void RegisterCallbacks()
    {
        #region Mapping
        actions.Mapping.PlaceNote.performed += PlaceNote;
        actions.Mapping.RemoveNote.performed += RemoveNote;
        actions.Mapping.SwitchHand.performed += ToggleHandColor;
        actions.Mapping.FlipTargetColors.performed += FlipTargetColors;
        actions.Mapping.DeleteSelectedTargets.performed += DeleteSelectedTargets;
        #endregion

        #region Drag Select
        actions.DragSelect.SelectDragTool.performed += SelectDrag;
        actions.DragSelect.SelectDragTool.canceled += SelectDrag;

        actions.DragSelect.FlipTargetsHorizontally.performed += FlipTargetsHorizontal;
        actions.DragSelect.FlipTargetsVertically.performed += FlipTargetsVertical;

        actions.DragSelect.IncreaseScaleHorizontally.performed += IncreaseScaleHorizontal;
        actions.DragSelect.IncreaseScaleVertically.performed += IncreaseScaleVertical;

        actions.DragSelect.DecreaseScaleHorizontally.performed += DecreaseScaleHorizontal;
        actions.DragSelect.DecreaseScaleVertically.performed += DecreaseScaleVertical;

        actions.DragSelect.RotateSelectedTargetsLeft.performed += RotateSelectedTargetsLeft;
        actions.DragSelect.RotateSelectedTargetsRight.performed += RotateSelectedTargetsRight;

        actions.DragSelect.ReverseSelectedTargets.performed += ReverseSelectedTargets;

        actions.DragSelect.MoveTargets.performed += MoveTargets;
        #endregion

        #region Spacing Snap
        actions.SpacingSnap.EnableSpacingSnap.performed += EnableSpacingSnap;
        actions.SpacingSnap.EnableSpacingSnap.canceled += EnableSpacingSnap;
        #endregion

        #region Modifiers
        actions.Modifiers.OpenModifiers.performed += SelectModifiers;
        actions.Modifiers.ModifierPreview.performed += ActivateModifierPreview;
        #endregion

        #region Pathbuilder
        actions.Pathbuilder.EnablePathbuilder.performed += SelectPathbuilder;
        #endregion

        #region Behaviors
        actions.BehaviorSelect.SelectBehaviorChain.performed += SelectChain;
        actions.BehaviorSelect.SelectBehaviorChainstart.performed += SelectChainStart;
        actions.BehaviorSelect.SelectBehaviorHorizontal.performed += SelectHorizontal;
        actions.BehaviorSelect.SelectBehaviorMelee.performed += SelectMelee;
        actions.BehaviorSelect.SelectBehaviorMine.performed += SelectMine;
        actions.BehaviorSelect.SelectBehaviorStandard.performed += SelectStandard;
        actions.BehaviorSelect.SelectBehaviorSustain.performed += SelectSustain;
        actions.BehaviorSelect.SelectBehaviorVertical.performed += SelectVertical;

        actions.BehaviorConvert.ConvertBehaviorChain.performed += ConvertToChain;
        actions.BehaviorConvert.ConvertBehaviorChainstart.performed += ConvertToChainstart;
        actions.BehaviorConvert.ConvertBehaviorHorizontal.performed += ConvertToHorizontal;
        actions.BehaviorConvert.ConvertBehaviorMelee.performed += ConvertToMelee;
        actions.BehaviorConvert.ConvertBehaviorMine.performed += ConvertToMine;
        actions.BehaviorConvert.ConvertBehaviorStandard.performed += ConvertToStandard;
        actions.BehaviorConvert.ConvertBehaviorSustain.performed += ConvertToSustain;
        actions.BehaviorConvert.ConvertBehaviorVertical.performed += ConvertToVertical;
        #endregion

        #region Hitsounds
        actions.HitsoundSelect.SelectHitsoundChain.performed += SelectHitsoundChain;
        actions.HitsoundSelect.SelectHitsoundChainstart.performed += SelectHitsoundChainStart;
        actions.HitsoundSelect.SelectHitsoundKick.performed += SelectHitsoundKick;
        actions.HitsoundSelect.SelectHitsoundMelee.performed += SelectHitsoundMelee;
        actions.HitsoundSelect.SelectHitsoundPercussion.performed += SelectHitsoundPercussion;
        actions.HitsoundSelect.SelectHitsoundSilent.performed += SelectHitsoundSilent;
        actions.HitsoundSelect.SelectHitsoundSnare.performed += SelectHitsoundSnare;

        actions.HitsoundConvert.ConvertHitsoundChain.performed += ConvertHitsoundChain;
        actions.HitsoundConvert.ConvertHitsoundChainstart.performed += ConvertHitsoundChainStart;
        actions.HitsoundConvert.ConvertHitsoundKick.performed += ConvertHitsoundKick;
        actions.HitsoundConvert.ConvertHitsoundMelee.performed += ConvertHitsoundMelee;
        actions.HitsoundConvert.ConvertHitsoundPercussion.performed += ConvertHitsoundPercussion;
        actions.HitsoundConvert.ConvertHitsoundSilent.performed += ConvertHitsoundSilent;
        actions.HitsoundConvert.ConvertHitsoundSnare.performed += ConvertHitsoundSnare;
        #endregion

        #region Grid
        actions.Grid.GridView.performed += SelectSnapGrid;
        actions.Grid.MeleeView.performed += SelectSnapMelee;
        actions.Grid.NoGridView.performed += SelectSnapNone;
        actions.Grid.QuickSwitchGrid.performed += QuickSwitchNoGrid;
        actions.Grid.QuickSwitchGrid.canceled += QuickSwitchNoGrid;
        actions.Grid.MoveGrid.performed += MoveGrid;
        #endregion

        #region Timeline
        actions.Timeline.TogglePlay.performed += TogglePlay;
        actions.Timeline.StartMetronome.performed += StartMetronome;
        actions.Timeline.ToggleWaveform.performed += ToggleWaveform;
        actions.Timeline.Scrub.performed += ScrubTimeline;
        actions.Timeline.ScrubByTick.performed += ScrubByTick;
        actions.Timeline.ChangeBeatSnap.performed += ChangeBeatSnap;
        actions.Timeline.ZoomTimeline.performed += ZoomTimeline;
        #endregion

        #region BPM
        actions.BPM.BPMMarker.performed += PlaceBpmMarker;
        actions.BPM.DetectBPM.performed += DetectBpm;
        actions.BPM.ShiftBPMMarker.performed += ShiftBpmMarker;
        actions.BPM.PreviewPoint.performed += SetPreviewPoint;
        #endregion

        #region Menus
        actions.Menus.Pause.performed += ShowPause;
        actions.Menus.Help.performed += ShowHelp;
        actions.Menus.Countin.performed += ShowCountin;
        actions.Menus.Bookmark.performed += OpenBookmarks;
        actions.Menus.ModifyAudio.performed += ShowModifyAudio;
        actions.Menus.TimingPoints.performed += ShowTimingPoints;
        actions.Menus.ModifierHelp.performed += ShowModifierHelp;
        actions.Menus.ReviewMenu.performed += ShowReviewMenu;
        #endregion

        #region Utility
        actions.Utility.SelectAll.performed += SelectAll;
        actions.Utility.DeselectAll.performed += DeselectAllTargets;
        actions.Utility.Copy.performed += Copy;
        actions.Utility.Paste.performed += Paste;
        actions.Utility.Cut.performed += Cut;
        actions.Utility.Save.performed += Save;
        actions.Utility.Undo.performed += DoUndo;
        actions.Utility.Redo.performed += DoRedo;
        #endregion

        actions.Disable();
        KeybindManager.SetStandardKeybinds(actions.asset);
        
    }

    protected override void OnEscPressed(InputAction.CallbackContext context)
    {

    }
}
