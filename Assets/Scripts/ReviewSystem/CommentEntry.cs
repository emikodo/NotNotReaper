using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NotReaper.ReviewSystem;
using System.Linq;
using UnityEngine.UI;

namespace NotReaper.ReviewSystem
{
    public class CommentEntry : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI indexDisplay;
        [SerializeField] private TextMeshProUGUI tickDisplay;
        [SerializeField] private Image typeDisplay;
        [SerializeField] private Outline outline;
        [Space]
        [Header("Icons")]
        [SerializeField] private Sprite pog;
        [SerializeField] private Sprite notLikeThis;
        [SerializeField] private Sprite thonk;

        public int StartTick;
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                SetIndex(value);
            }
        }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                SetSelected(value);
            }
        }
        private int _index = 0;
        private bool _isSelected = false;

        private void SetIndex(int value)
        {
            _index = value;
            indexDisplay.text = _index.ToString();
            transform.SetSiblingIndex(value);
        }

        public void SetComment(ReviewComment comment)
        {
            StartTick = comment.selectedCues.First().tick;
            tickDisplay.text = StartTick.ToString();
            switch (comment.type)
            {
                case CommentType.Negative:
                    typeDisplay.sprite = notLikeThis;
                    break;
                case CommentType.Positive:
                    typeDisplay.sprite = pog;
                    break;
                case CommentType.Suggestion:
                    typeDisplay.sprite = thonk;
                    break;
            }
            
        }

        public void SelectComment()
        {
            ReviewWindow.Instance.SelectComment(Index);

            SetSelected(true);          
        }

        public void SetSelected(bool selected)
        {
            _isSelected = selected;
            outline.effectColor = _isSelected ? Color.green : Color.white;
        }
    }
}

