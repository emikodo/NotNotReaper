using NotReaper.Tools;
using NotReaper.Tools.ChainBuilder;
using UnityEngine;
using NotReaper.Modifier;

namespace NotReaper.Managers {




	public class EditorToolkit : MonoBehaviour {

		

		[SerializeField] public PlaceNote placeNote;

		[SerializeField] public UndoRedoManager undoRedoManager;

		public ChainBuilder chainBuilder;

		public OLD_DragSelect dragSelect;

        [SerializeField] public ModifierHandler modifierCreator;


	}


}