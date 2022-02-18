﻿using NotReaper.Grid;
using NotReaper.Models;
using NotReaper.Targets;
using NotReaper.Timing;
using NotReaper.Tools.ChainBuilder;
using NotReaper.UserInput;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NotReaper.Tools.PathBuilder
{
	[RequireComponent(typeof(SegmentPool))]
	public class Pathbuilder : NRInput<PathbuilderKeybinds>
	{
        #region Inspector References
        [Space, Header("References")]
		[SerializeField] private Transform canvas;
		[SerializeField] private Transform pathbuilderParent;
		[SerializeField] private PathbuilderNode nodePrefab;
		[Space, Header("Active Segment Indicator")]
		[SerializeField] private LineRenderer activeSegmentIndicator;
        #endregion

        #region Fields
        #region Dependencies
        [NRInject] private Timeline timeline;
		[NRInject] private PathbuilderUI ui;
        #endregion

        #region Classes
        private SegmentPool segmentPool;
		private PathbuilderCalculator calculator;
        #endregion

        #region Data
        private Target activeTarget;
		private Segment activeSegment;
		private Segment tempSegment;
		private Point activePoint;
		private List<Segment> segments = new List<Segment>();
		private bool alternateHands;
		private bool isSegmentScope = true;
		private PathbuilderData.Interval intervalOverride = new PathbuilderData.Interval(1, 16);
		private QNT_Duration beatLengthOverride = new QNT_Duration(480);
        #endregion

        #region State
        private bool snapToGrid = false;
		private bool dragNote = false;
		private bool isMouseDown = false;
		private Vector2 dragStartPos;
		public bool isActive;
        #endregion

        #region Utility
        private TargetIcon[] _iconsUnderMouse = new TargetIcon[0];
		/** Fetch all icons currently under the mouse
     *  Will only ever happen once per frame */
		public TargetIcon[] iconsUnderMouse
		{
			get
			{
				return _iconsUnderMouse = _iconsUnderMouse == null
					? MouseUtil.IconsUnderMouse(timeline)
					: _iconsUnderMouse;
			}
			set { _iconsUnderMouse = value; }
		}

		// Fetch the highest priority target (closest to current time)
		public TargetIcon iconUnderMouse
		{
			get
			{
				return iconsUnderMouse != null && iconsUnderMouse.Length > 0
					? iconsUnderMouse[0]
					: null;
			}
		}
		#endregion
		#endregion

		protected override void Awake()
        {
			base.Awake();
			calculator = new PathbuilderCalculator();
			segmentPool = GetComponent<SegmentPool>();
		}

		[NRListener]
		private void OnToolChanged(EditorTool tool)
        {
			if(tool == EditorTool.Pathbuilder && !isActive)
            {
				isActive = true;
				Activate(true);
            }
			else if(tool == EditorTool.None && isActive)
            {
				isActive = false;
				Activate(false);
            }
        }

		[NRListener]
		private void OnBehaviorChanged(TargetBehavior behavior)
        {
			if (isActive)
            {
				EditorState.SelectTool(EditorTool.Pathbuilder);
            }
        }

        public void Activate(bool activate)
        {
			isActive = activate;
			if (activate)
            {
				ShowUI();
				OnActivated();
				EditorState.SelectSnappingMode(SnappingMode.None);
				if(timeline.selectedNotes.Count == 1)
                {
                    if (timeline.selectedNotes[0].data.isPathbuilderTarget)
                    {
						LoadTargetData(timeline.selectedNotes[0]);
                    }
                }
            }
			else
            {
				EditorState.SelectSnappingMode(EditorState.Snapping.Previous);
				HideUI();
				ClearData();
				OnDeactivated();
            }
        }

		private void RemoveAllSegments()
        {
			for (int i = segments.Count - 1; i >= 0; i--)
			{
				segmentPool.Return(segments[i]);
			}
			activeSegment = null;
			segments.Clear();

			if(tempSegment != null)
            {
				segmentPool.Return(tempSegment);
				tempSegment = null;
            }
		}

        internal void OnDenominatorChanged(int denominator)
        {
            if (isSegmentScope)
            {
				activeSegment.SetDenominator(denominator);
			}
            else
            {
				intervalOverride.denominator = denominator;
            }
			UpdateActivePathbuilderTarget(activeTarget);
		}

        internal void ChangeAlternateHands()
        {
			alternateHands = !alternateHands;
			activeTarget.data.pathbuilderData.AlternateHands = alternateHands;
			UpdateActivePathbuilderTarget(activeTarget);
		}

		public void BakeActiveTarget()
        {
			if (activeTarget == null) return;
			NRActionBakePathbuilderTarget action = new NRActionBakePathbuilderTarget(activeTarget.data, this);
			timeline.Tools.undoRedoManager.AddAction(action);
        }

        internal void BakeTarget(TargetData data)
        {

			data.isPathbuilderTarget = false;
			foreach(var segment in data.pathbuilderData.Segments)
            {
				foreach(var foundTarget in timeline.FindNotes(segment.generatedNodes))
                {
					foundTarget.transient = false;
                }
            }
			OnPathbuilderTargetChanged(activeTarget);
        }

        internal void ChangeScope()
        {
			isSegmentScope = !isSegmentScope;
			activeTarget.data.pathbuilderData.IsSegmentScope = isSegmentScope;
			UpdateActivePathbuilderTarget(activeTarget);
		}

        internal void RemovePathbuilderTarget(TargetData targetData)
        {
			RemoveAllNodes(targetData.pathbuilderData);
			if(activeTarget != null && activeTarget.data == targetData)
            {
				ClearData();
				UpdateUI();
            }
			
        }

		private void Update()
        {
			if (!isMouseDown || !dragNote || activeTarget == null || activeSegment == null) return;
			var pos = NoteGridSnap.SnapToGrid(GetMousePosition(), snapToGrid ? SnappingMode.Grid : SnappingMode.None);
			activeSegment.OnHandleDragStart();
			activeTarget.data.position = pos;
        }

        private void OnMouseClickEnd()
        {
			isMouseDown = false;
			if (!dragNote) return;
			dragNote = false;
			if (activeSegment != null) activeSegment.OnHandleDragStop();
			TargetGridMoveIntent intent = new TargetGridMoveIntent();
			intent.target = activeTarget.data;
			intent.startingPosition = dragStartPos;
			intent.intendedPosition = activeTarget.data.position;
			timeline.MoveGridTargets(new List<TargetGridMoveIntent>() { intent });
        }

       

        private Vector3 GetMousePosition()
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint(actions.Pathbuilder.MousePosition.ReadValue<Vector2>());
			pos.z = 0;
			return pos;
		}

		private void LoadTargetData(Target target)
        {
            if (!target.data.isPathbuilderTarget)
            {
				MakeNewPathbuilderTarget(target);
				return;
            }
			activeTarget = target;
			timeline.DeselectAllTargets();
			timeline.SelectTarget(target);
			var data = target.data.pathbuilderData;
			var segmentData = data.Segments;
			Transform startPoint = target.gridTargetIcon.transform;
			isSegmentScope = data.IsSegmentScope;
			alternateHands = data.AlternateHands;
			for(int i = 0; i < segmentData.Count; i++)
            {
				var segment = segmentPool.Spawn(pathbuilderParent);
				segment.Initialize(this, actions);
				if(i != 0)
                {
					var lastSegment = segments.Last();
					lastSegment.childSegment = segment;
					segment.parentSegment = lastSegment;
				}
				segment.LoadSegment(this, actions, startPoint, target, segmentData[i], segments.Count);
				segments.Add(segment);
				startPoint = segment.GetSegmentEndPoint();
            }
			SetActiveSegment(segments[data.ActiveSegment]);
		}

        public void HandleRootNoteDelete(TargetData targetData)
        {
			foreach (var segment in targetData.pathbuilderData.Segments)
			{
				foreach (var node in segment.generatedNodes)
				{
					timeline.DeleteTargetFromAction(node);
				}
			}
		}

		private void SwitchData(Target target)
        {
			ClearData();
			LoadTargetData(target);
			UpdateUI();
        }

		private void UpdateUI()
        {
			if (!ui.isOpen) return;

			if(activeSegment == null)
            {
				ui.ResetPanel();
            }
            else
            {
				ui.LoadData(isSegmentScope ? activeSegment.interval : intervalOverride, isSegmentScope ? activeSegment.beatLength : beatLengthOverride, isSegmentScope, alternateHands);
			}
			
        }

		private void ShowUI()
        {
			ui.Show();
			UpdateUI();
        }

		private void HideUI()
        {
			ui.Hide();
        }


        internal void OnNominatorChanged(int nominator)
        {
            if (isSegmentScope)
            {
				activeSegment.SetNominator(nominator);
            }
            else
            {
				intervalOverride.nominator = nominator;
            }
			UpdateActivePathbuilderTarget(activeTarget);
		}

		internal void OnBeatlengthChanged(bool increase)
        {
			QNT_Duration increment = Constants.DurationFromBeatSnap((uint)timeline.beatSnap);
			QNT_Duration targetLength = isSegmentScope ? activeSegment.beatLength : beatLengthOverride;
			if (increase)
			{
				if (targetLength < increment)
				{
					targetLength = new QNT_Duration(0);
				}
				targetLength += increment;
			}
			else
			{
				if(targetLength.tick - increment.tick > 0)
                {
					targetLength -= increment;
                }
			}
			if (isSegmentScope) activeSegment.SetBeatlength(targetLength); 
			else beatLengthOverride = targetLength;			
			UpdateActivePathbuilderTarget(activeTarget);
		}

		private void MakeNewPathbuilderTarget(Target target)
        {
			activeTarget = target;
			activeTarget.data.pathbuilderData = new PathbuilderData();
			beatLengthOverride = Constants.QuarterNoteDuration;
			timeline.DeselectAllTargets();
			timeline.SelectTarget(activeTarget);
			var segment = segmentPool.Spawn(pathbuilderParent);
			segment.Initialize(this, actions);
			segment.StartNewSegment(actions, activeTarget.gridTargetIcon.transform, activeTarget, this, segments.Count);
			//segments.Add(segment);
			tempSegment = segment;
			segment.SetInterval(new PathbuilderData.Interval());
			segment.SetBeatlength(new QNT_Duration(480));
		}

        private void AppendSegment()
        {
			var segment = segmentPool.Spawn(pathbuilderParent);
			var lastSegment = segments.Last();
			lastSegment.childSegment = segment;
			segment.parentSegment = lastSegment;
			segment.StartNewSegment(actions, lastSegment.GetSegmentEndPoint(), activeTarget, this, segments.Count);
			segments.Add(segment);
			segment.SetInterval(new PathbuilderData.Interval(lastSegment.interval.nominator, lastSegment.interval.denominator));
			segment.SetBeatlength(lastSegment.beatLength);
			segment.SetSegmentEndPoint();
			SaveTargetState();
		}

		public void SaveTargetState()
        {
			NRActionUpdatePathbuilderTarget segmentAction = new NRActionUpdatePathbuilderTarget(activeTarget.data, this, GetPathbuilderData());
			Timeline.instance.Tools.undoRedoManager.AddAction(segmentAction);
		}

		public void UpdatePathbuilderTargetFromAction(TargetData targetData, PathbuilderData data)
        {
			Target target = (activeTarget != null && activeTarget.data == targetData) ? activeTarget : timeline.FindNote(targetData);
			if (target == null) return;
			if (targetData.pathbuilderData == null) targetData.pathbuilderData = new PathbuilderData();
			else RemoveAllNodes(targetData.pathbuilderData);
			targetData.pathbuilderData = data;
			targetData.isPathbuilderTarget = data.Segments.Count > 0;
			calculator.CalculateNodes(targetData, true);
			OnPathbuilderTargetChanged(target);
            if (ui.isOpen && targetData.isPathbuilderTarget)
            {
				activeTarget = null;
				SwitchData(target);
            }
		}

		private void UpdateActivePathbuilderTarget(Target target)
        {
			if (activeTarget == null) return;
			Save();
			UpdatePathbuilderTargetFromAction(target.data, target.data.pathbuilderData);
        }

		public void UpdatePathbuilderTarget(TargetData data)
        {
			UpdatePathbuilderTargetFromAction(data, data.pathbuilderData);
        }

		public void OnPathbuilderTargetChanged(Target target)
        {
			target.timelineTargetIcon.SetBeatlengthLineActive(target.data.isPathbuilderTarget);
            if (!target.data.isPathbuilderTarget)
            {
				UpdateSegmentIndicator(target, false);
				activeTarget = null;
				target.data.pathbuilderData = null;
				ClearData();
				UpdateUI();
            }
		}

		private PathbuilderData GetPathbuilderData()
        {
			if (segments.Count == 0) return null;
			PathbuilderData data = new PathbuilderData();

			List<PathbuilderData.Segment> segmentData = new List<PathbuilderData.Segment>();
			QNT_Duration length = new QNT_Duration(0);
			foreach (var segment in segments)
            {
				segmentData.Add(segment.GetSegmentData());
				length += segment.beatLength;
            }
			data.BeatLengthOverride = beatLengthOverride;
			data.ActiveSegment = activeSegment.Index;
			data.AlternateHands = alternateHands;
			data.IsSegmentScope = isSegmentScope;
			data.Segments = segmentData;
			data.IntervalOverride = intervalOverride;
			return data;
        }
		
		/// <summary>
		/// Calculates nodes on NR load without generating them.
		/// </summary>
		/// <param name="data">The pathbuilder target's TargetData.</param>
		public void CalculateNodesOnLoad(TargetData data)
        {
			calculator.CalculateNodes(data, false);
        }
		/// <summary>
		/// Generates nodes on NR load.
		/// </summary>
		/// <param name="data">The pathbuilder target's TargetData.</param>
		public void GenerateNodesOnLoad(TargetData data)
        {
			calculator.GenerateNodes(data.pathbuilderData);
			var found = timeline.FindNote(data);
			if (found != null) found.timelineTargetIcon.SetBeatlengthLineActive(true);
        }
		/// <summary>
		/// Sets a new segment to active.
		/// </summary>
		/// <param name="segment">The segment to mark active.</param>
		internal void SetActiveSegment(Segment segment)
        {
			if (activeSegment == segment) return;
			foreach (var s in segments) s.SetSelected(false);
			segment.SetSelected(true);
			activeSegment = segment;
			UpdateSegmentIndicator(activeTarget, true);
			UpdateUI();
        }
		/// <summary>
		/// Updates the position of the active segment indicator and enables/disables it.
		/// </summary>
		/// <param name="target">The currently selected pathbuilder target.</param>
		/// <param name="enable">True if you want to enable the indicator.</param>
		private void UpdateSegmentIndicator(Target target, bool enable)
        {
            if (enable)
            {
				float height = target.timelineTargetIcon.sustainDirection;
				QNT_Duration startTime = new QNT_Duration(0);
				QNT_Duration endTime = startTime;
                if (isSegmentScope)
                {
					foreach (var segment in segments)
					{
						if (segment == activeSegment)
						{
							endTime = startTime + segment.beatLength;
							break;
						}
						startTime += segment.beatLength;

					}
                }
                else
                {
					endTime = beatLengthOverride;
                }

				float scale = 20.0f / Timeline.scale;
				activeSegmentIndicator.enabled = true;
				activeSegmentIndicator.transform.localPosition = target.timelineTargetIcon.transform.localPosition;
				activeSegmentIndicator.SetPosition(0, new Vector3((startTime.ToBeatTime() / 0.7f) * scale * 1.75f, height, 0f));
				activeSegmentIndicator.SetPosition(1, new Vector3((endTime.ToBeatTime() / 0.7f) * scale * 1.75f, height, 0f));
				Color color = target.data.handType == TargetHandType.Left ? NRSettings.config.leftColor : NRSettings.config.rightColor;
				activeSegmentIndicator.startColor = color;
				activeSegmentIndicator.endColor = color;
				target.timelineTargetIcon.MakeSustainIndicatorTransparent(true);
			}
            else
            {
				activeSegmentIndicator.enabled = false;
				target.timelineTargetIcon.MakeSustainIndicatorTransparent(false);
            }		
        }
		/// <summary>
		/// Removes the last segment from the current path.
		/// </summary>
		public void RemoveLastSegment()
        {
			if (segments.Count == 0)
            {
				return;
            }
			var segment = segments.Last();
			segments.Remove(segment);

			if(segments.Count == 0)
            {
				activeSegment = null;
            }
			else if(activeSegment == segment)
			{
				SetActiveSegment(segments.Last());
            }

			segmentPool.Return(segment);
			SaveTargetState();
		}
		/// <summary>
		/// Removes all nodes of a path.
		/// </summary>
		/// <param name="data">The pathbuilder data you want to remove nodes for.</param>
		internal void RemoveAllNodes(PathbuilderData data)
		{
			foreach (var segment in data.Segments)
			{
				foreach (var node in segment.generatedNodes)
				{
					timeline.DeleteTargetFromAction(node);
				}
			}
		}
		/// <summary>
		/// Resets all data and UI.
		/// </summary>
		private void ClearData()
        {
			
			Save();
			RemoveAllSegments();
			//timeline.DeselectAllTargets();
			if(activeTarget != null)
            {
				UpdateSegmentIndicator(activeTarget, false);
			}
			activeTarget = null;
			activePoint = null;
			activeSegment = null;
			alternateHands = false;
			intervalOverride = new PathbuilderData.Interval();
			beatLengthOverride = Constants.QuarterNoteDuration;
			isSegmentScope = true;
        }
		/// <summary>
		/// Saves current pathbuilder data to active target.
		/// </summary>
		private void Save()
        {
			if (activeTarget != null)
			{
				var data = GetPathbuilderData();
				if (data != null) activeTarget.data.pathbuilderData = data;
			}
		}

        /// <summary>
        /// Checks if a target is a valid Pathbuilder target.
        /// </summary>
        /// <param name="target">The target to check</param>
        /// <returns>True if target is not chain, melee, mine or a NR tool or already a pathbuilder target and not a transient</returns>
        private bool IsValidPathbuilderCandidate(Target target)
        {
			if (target == null) return false;

			int index = (int)target.data.behavior;
			return index < 5 && !target.transient && !target.data.isPathbuilderTarget;
        }

		#region Input Callbacks
		protected override void RegisterCallbacks()
		{
			actions.Pathbuilder.SelectTarget.performed += _ => OnMouseClick();
			actions.Pathbuilder.SelectTarget.canceled += _ => OnMouseClickEnd();
			actions.Pathbuilder.AppendSegment.performed += _ => OnAppendSegment();
			actions.Pathbuilder.DeleteSegment.performed += _ => RemoveLastSegment();
			actions.Pathbuilder.SnapToGrid.performed += _ => OnShiftDown(true);
			actions.Pathbuilder.SnapToGrid.canceled += _ => OnShiftDown(false);

			actions.Pathbuilder.AlternateHands.performed += _ => OnAlternateHandsPressed();
			actions.Pathbuilder.ChangeScope.performed += _ => OnChangeScopePressed();
			actions.Pathbuilder.ChangeToNextSegment.performed += _ => OnChangeActiveSegment(true);
			actions.Pathbuilder.ChangeToPreviousSegment.performed += _ => OnChangeActiveSegment(false);
			actions.Pathbuilder.IncreaseInterval.performed += _ => OnChangeInterval(true);
			actions.Pathbuilder.DecreaseInterval.performed += _ => OnChangeInterval(false);
			actions.Pathbuilder.IncreaseLength.performed += _ => OnChangeLength(true);
			actions.Pathbuilder.DecreaseLength.performed += _ => OnChangeLength(false);		
		}

		private void OnMouseClick()
		{
			iconsUnderMouse = null;
			isMouseDown = true;
			if (iconUnderMouse != null)
			{
				var target = iconUnderMouse.target;

				if (target == activeTarget)
				{
					if (segments.Count > 0)
					{
						SetActiveSegment(segments[0]);
					}
					dragStartPos = GetMousePosition();
					dragNote = true;
					return;
				}
				else if (target.data.isPathbuilderTarget)
				{
					if (activeTarget != target)
					{
						SwitchData(target);
						return;
					}
				}
				else if (IsValidPathbuilderCandidate(target))
				{
					SwitchData(target);
					return;
				}
			}

			if (tempSegment != null)
			{
				tempSegment.SetSegmentEndPoint();
				segments.Add(tempSegment);
				tempSegment = null;
				SaveTargetState();
			}
		}

		/// <summary>
		/// Callback for when a point in a segment is clicked.
		/// </summary>
		/// <param name="segment">The segment the point belongs to.</param>
		/// <param name="point">The point registering a click.</param>
		public void OnPointClicked(Segment segment, Point point)
		{
			activePoint = point;
			point.ShouldSnap(snapToGrid);
			if (!KeybindManager.Global.IsCtrlDown)
			{
				SetActiveSegment(segment);
			}
		}

		private void OnShiftDown(bool down)
        {
			snapToGrid = down;
			if (activePoint != null)
			{
				activePoint.ShouldSnap(down);
			}
        }
		private void OnAppendSegment()
        {
			if (activeTarget == null || activeSegment == null) return;			
			AppendSegment();
		}

		private void OnAlternateHandsPressed()
        {
			if (activeTarget == null || activeSegment == null) return;			
			ChangeAlternateHands();        
        }

		private void OnChangeScopePressed()
        {
			if (activeTarget == null || activeSegment == null) return;		
			ChangeScope();
        }

		private void OnChangeActiveSegment(bool next)
        {
			if (activeTarget == null || activeSegment == null) return;
			int index = activeSegment.Index + (next ? 1 : -1);
			if(index >= 0 && index < segments.Count)
            {
				SetActiveSegment(segments[index]);
            }
        }

		private void OnChangeInterval(bool increase)
        {
			if (activeTarget == null || activeSegment == null) return;
			ui.OnIntervalChanged(increase);
        }

		private void OnChangeLength(bool increase)
        {
			if (activeTarget == null || activeSegment == null) return;
			OnBeatlengthChanged(increase);
        }

		protected override void OnEscPressed(InputAction.CallbackContext context)
		{
			Activate(false);
		}
		#endregion
	}
}

