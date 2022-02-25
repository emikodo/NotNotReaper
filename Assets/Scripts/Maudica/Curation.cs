using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotReaper.Maudica;
using UnityEngine.UI;
using DG.Tweening;

namespace NotReaper.Curation
{
    public class Curation : MonoBehaviour
    {
        [SerializeField] private Image voteDown;
        [SerializeField] private Image voteUp;
        [SerializeField] private Transform curation;

        private void Start()
        {

            voteDown.DOFade(0f, .1f);
            voteUp.DOFade(0f, .1f);
            voteDown.transform.position = curation.position;
            voteUp.transform.position = curation.position;
            voteDown.gameObject.SetActive(false);
            voteUp.gameObject.SetActive(false);
        }

        public void OnCurationClicked()
        {
            voteDown.gameObject.SetActive(true);
            voteUp.gameObject.SetActive(true);
            var animation = DOTween.Sequence();
            animation.Append(curation.DOScale(Vector3.one * 1.1f, .15f));
            animation.Join(voteUp.DOFade(1f, .3f));
            animation.Join(voteDown.DOFade(1f, .3f));
            animation.Append(curation.DOScale(Vector3.one, .15f));
            animation.Play();
        }
    }
}

