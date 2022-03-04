﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NotReaper.Grid;
using NotReaper.UserInput;
using NotReaper.Modifier;
namespace NotReaper.Managers
{

	
	public class OutsideGridBounds : MonoBehaviour
	{
		
		int gridX = 0;
		int gridY = 0;
		
		public Transform gridUI;
		public Transform timelineTransform;
		public GameObject gridOutline;



		public float fadeSpeed = 0.3f;
		private float xModifier = 8.8f;
		private float yModifier = 3.6f;

		private List<MeshRenderer> gridOutlineLines = new List<MeshRenderer>();

		
		private void Start()
		{
			foreach (MeshRenderer r in gridOutline.GetComponentsInChildren<MeshRenderer>()) {
				gridOutlineLines.Add(r);
				r.material.DOFade(.25f, .1f);
			}
		}
		
		/// <summary>
		/// Offsets the grid and camera so you can map outside the normal grid.
		/// </summary>
		/// <param name="x">-1 is left side, 1 is right side, 0 is default middle.</param>
		/// <param name="y"></param>
		public void SetGridPosition(int x = 0, int y = 0)
		{
			gridX += x;
			gridY += y;

			gridX = Mathf.Clamp(gridX, -1, 1);
			gridY = Mathf.Clamp(gridY, -1, 1);
			
			Camera.main.transform.DOMove(new Vector3(gridX * xModifier, (gridY * yModifier) + 0.5f, -5), fadeSpeed).SetEase(Ease.InOutCubic);
			gridUI.DOMove(Vector3.zero, fadeSpeed).SetEase(Ease.InOutCubic);
			//gridUI.DOMove(new Vector3(-gridX * xModifier, gridY * -yModifier, 0), fadeSpeed).SetEase(Ease.InOutCubic);
			//timelineTransform.DOMove(new Vector3(gridX * xModifier, (gridY * yModifier) + 4.7f), fadeSpeed).SetEase(Ease.InOutCubic);

			if (gridX == 0 && gridY == 0) {
				foreach (var line in gridOutlineLines) {
					line.material.DOFade(.25f, fadeSpeed);
				}
			}
			else {
				foreach (var line in gridOutlineLines) {
					line.material.DOFade(1f, fadeSpeed);
				}
			}


		}

		public void SetGridPosition(Vector2 direction)
        {
			SetGridPosition((int)direction.x, (int)direction.y);
        }
		
		
		
	}


}