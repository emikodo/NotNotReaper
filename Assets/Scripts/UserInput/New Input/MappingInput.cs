﻿using NotReaper;
using NotReaper.Grid;
using NotReaper.Models;
using NotReaper.Targets;
using NotReaper.Tools;
using NotReaper.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using NotReaper.Tools.SpacingSnap;
using NotReaper.Modifier;
using NotReaper.Tools.ChainBuilder;
using NotReaper.Tools.PathBuilder;
using NotReaper.Notifications;

namespace NotReaper.UserInput
{
	public class MappingInput : MonoBehaviour
	{

		[Header("Place Notes")]
		[SerializeField] private Transform ghost;
		[SerializeField] private ParallaxBG background;
		[Space, Header("Timeline")]
		[SerializeField] private Timeline timeline;
		[Space, Header("Tools")]
		[SerializeField] private UndoRedoManager undoRedo;
		[SerializeField] private SpacingSnapper snapper;
		[SerializeField] private DragSelect drag;
		[NRInject] private ModifierHandler modifiers;
		[NRInject] private Pathbuilder pathbuilder;
		[NRInject] private ChainBuilder chainbuilder;

		private bool halfModifierPressed, quarterModifierPressed;

		private List<TargetData> clipboard = new List<TargetData>();

		public void PlaceNote()
		{
			if (!EditorState.IsOverGrid || EditorState.IsInUI || (EditorState.Tool.Current != EditorTool.None && EditorState.Tool.Current != EditorTool.SpacingSnapper)) return;
			timeline.AddTarget(ghost.position.x, ghost.position.y);
			background.OnPlaceNote();
		}

		public void Redo()
		{
			undoRedo.Redo();
		}

		public void RemoveNote()
		{
			var iconsUnderMouse = MouseUtil.IconsUnderMouse(timeline);
			TargetIcon targetIcon = iconsUnderMouse.Length > 0 ? iconsUnderMouse[0] : null;
			if (targetIcon)
			{
				timeline.DeleteTarget(targetIcon.target);
				timeline.UpdateLoadedNotes();
			}

		}

		public void Undo()
		{
			undoRedo.Undo();
		}

		public void DeselectAllTargets()
		{
			timeline.DeselectAllTargets();
		}

		public void SelectAllTargets()
		{
			timeline.SelectAllTargets();
		}

		public void Save()
		{
			timeline.Export();
		}

		public void SetTargetHitsoundAction(InternalTargetVelocity velocity)
		{
			var intents = new List<TargetSetHitsoundIntent>();
			foreach (var target in timeline.selectedNotes)
			{
				var intent = new TargetSetHitsoundIntent();

				intent.target = target.data;
				intent.startingVelocity = target.data.velocity;
				intent.newVelocity = velocity;

				intents.Add(intent);
			}
			timeline.SetTargetHitsounds(intents);
			if(timeline.selectedNotes.Count > 0)
            {
				NotificationCenter.SendNotification($"Converted hitsound{(timeline.selectedNotes.Count > 1 ? "s" : "")} to {velocity}.", NotificationType.Success, false);
            }
		}

		public void SetTargetBehaviorAction(TargetBehavior behavior)
		{
			NRActionSetTargetBehavior action = new NRActionSetTargetBehavior();
			action.newBehavior = behavior;
			timeline.selectedNotes.ForEach(target => {
				action.affectedTargets.Add(target.data);
			});

			timeline.SetTargetBehaviors(action);
		}

		public void MoveTargetsAction(Vector2 direction)
		{
			drag.MoveTargets(direction);
		}

		public void ActivateSnapper(bool enable)
		{
			if (enable) snapper.EnableSpacingSnap();
			else snapper.DisableSpacingSnap();
		}

		public void CopySelectedTargets(bool copyTimestamp = true)
		{
			if (copyTimestamp) timeline.CopyTimestampToClipboard();
			clipboard = new List<TargetData>();
			bool displayWarning = false;
			foreach (var target in timeline.selectedNotes)
			{
				if (target.data.isRepeaterTarget)
                {
					displayWarning = true;
					continue;
                }
				clipboard.Add(target.data);
			}
            if (displayWarning)
            {
				NotificationCenter.SendNotification("Repeater targets can't be copied.", NotificationType.Warning);
            }
		}

		public void CopyTargets(List<TargetData> targets)
        {
			clipboard = targets;
        }

		public void CutSelectedTargets()
		{
			CopySelectedTargets(false);
			DeleteSelectedTargets();
		}

		public void PasteSelectedTargets()
		{
			timeline.DeselectAllTargets();
			timeline.PasteCues(clipboard, Timeline.time);
		}
		public void DeleteSelectedTargets()
		{
			if (timeline.selectedNotes.Count > 0)
			{
				timeline.DeleteTargets(timeline.selectedNotes);
			}

			timeline.selectedNotes = new List<Target>();
		}

		public void ScaleSelectedTargets(Vector2 scale)
		{
			timeline.ScaleSelectedTargets(scale);
		}

		public void FlipTargetsVertical()
		{
			timeline.FlipSelectedTargetsVertical();
		}

		public void FlipTargetsHorizontal()
		{
			timeline.FlipSelectedTargetsHorizontal();
		}

		public void FlipTargetColors()
		{
			timeline.SwapTargets(timeline.selectedNotes);
		}

		public void TogglePlayPause(bool metronome)
		{
			timeline.TogglePlayback(metronome);
		}

		public void RotateSelectedTargetsRight()
		{
			timeline.Rotate(timeline.selectedNotes, -15);
		}

		public void RotateSelectedTargetsLeft()
		{
			timeline.Rotate(timeline.selectedNotes, 15);
		}

		public void ReverseSelectedTargets()
		{
			timeline.Reverse(timeline.selectedNotes);
		}

		public void ScrubTimeline(float direction, bool byTick)
		{
			timeline.ScrubTimeline(direction < 0f, byTick);
		}

		public void ChangeBeatSnap(float direction)
		{
			timeline.ChangeBeatSnap(direction > 0f);
		}

		public void ZoomTimeline(float direction)
		{
			timeline.ZoomTimeline(direction < 0f);
		}

		public void DragSelectTool(bool enable)
		{
			if (enable) drag.EnableDragSelect();
			else drag.DisableDragSelect();

		}

		public void ToggleModifiers()
		{
			modifiers.ToggleModifiers();
		}

		private bool useLegacy = false;
		public void TogglePathbuilder()
        {
			if (KeybindManager.Global.Modifier == KeybindManager.Global.Modifiers.Ctrl)
			{
				useLegacy = !useLegacy;
				if (useLegacy && EditorState.IsToolActive(EditorTool.Pathbuilder)) EditorState.SelectTool(EditorTool.Pathbuilder);
				else if (!useLegacy && EditorState.IsToolActive(EditorTool.ChainBuilder))
				{
					ToggleChainbuilder();
				}
			}
			if (KeybindManager.Global.Modifier == KeybindManager.Global.Modifiers.None)
			{
				if (useLegacy)
				{
					ToggleChainbuilder();
				}
				else
				{
					EditorState.SelectTool(EditorTool.Pathbuilder);
				}
			}
		}

        /*public void TogglePathbuilder()
        {
			if(chainbuilder.activated)
            {
				chainbuilder.Activate(false);
				return;
            }
			pathbuilder.Activate(!pathbuilder.isActive);
        }*/

        internal void ToggleChainbuilder()
        {
            if (pathbuilder.isActive)
            {
				pathbuilder.Activate(false);
				return;
            }
			chainbuilder.Activate(!chainbuilder.activated);   
        }

        internal void ToggleModifierPreview()
        {
			ModifierPreviewer.Instance.UpdateModifierList(Timeline.time.tick);
		}
    }
}

