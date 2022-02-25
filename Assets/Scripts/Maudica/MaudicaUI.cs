using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotReaper.Maudica;
using UnityEngine.UI;
using DG.Tweening;
using NotReaper.Models;
using System;
using TMPro;
using NotReaper.MapBrowser;

namespace NotReaper.Maudica
{
    public class MaudicaUI : MonoBehaviour
    {
        [Header("Curation")]
        [SerializeField] private GameObject curationPanel;
        [SerializeField] private TextMeshProUGUI curationStatus;
        [Space, Header("Voting")]
        [SerializeField] private TextMeshProUGUI voteCount;

        private bool isOpen = false;

        private void Start()
        {
            curationPanel.SetActive(false);
            Timeline.onAudicaLoaded += OnAudicaLoaded;
        }

        private void OnAudicaLoaded(AudicaFile file)
        {
            if (!MaudicaHandler.HasToken) return;
            StartCoroutine(MaudicaHandler.GetMap(file.filepath, new Action<Song>((song) => 
            {
                bool exists = song.id > 0;
                curationPanel.SetActive(exists);               
                UpdateCurationStatus(song.curated);
                UpdateVoteCount(song.score);
            })));
        }

        private void UpdateCurationStatus(float percentage)
        {
            curationStatus.text = $"{percentage * 100f}%";
        }

        private void UpdateVoteCount(int count)
        {
            voteCount.text = count.ToString();
        }

        public void OnApproveClicked()
        {
            StartCoroutine(MaudicaHandler.ApproveMap(new Action(() => 
            {
                StartCoroutine(MaudicaHandler.GetMap(Timeline.audicaFile.filepath, new Action<Song>( (song) => UpdateCurationStatus(song.curated))));
            })));
        }

        public void OnUnapproveClicked()
        {
            StartCoroutine(MaudicaHandler.UnapproveMap(new Action(() =>
            {
                StartCoroutine(MaudicaHandler.GetMap(Timeline.audicaFile.filepath, new Action<Song>((song) => UpdateCurationStatus(song.curated))));
            })));
        }

        public void OnVoteUpClicked()
        {
            StartCoroutine(MaudicaHandler.VoteMapUp(new Action(() =>
            {
                StartCoroutine(MaudicaHandler.GetMap(Timeline.audicaFile.filepath, new Action<Song>((song) => UpdateVoteCount(song.score))));
            })));
        }
        public void OnVoteDownClicked()
        {
            StartCoroutine(MaudicaHandler.VoteMapDown(new Action(() =>
            {
                StartCoroutine(MaudicaHandler.GetMap(Timeline.audicaFile.filepath, new Action<Song>((song) => UpdateVoteCount(song.score))));
            })));
        }
    }
}

