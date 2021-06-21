using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NotReaper;
using NotReaper.Models;
using System.IO;
using System;
using NotReaper.IO;

public class UISustainHandler : MonoBehaviour
{
    public static UISustainHandler Instance = null;
    public static bool PendingDelete = false;
    public DisplaySliderCombo volumeSlider;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI loadSustainButtonText;
    public GameObject deleteSustainButton;
    public MoggSong sustainSongLeft { get; set; }
    public MoggSong sustainSongRight { get; set; }

    private void Start()
    {
        if(Instance is null)
        {
            Instance = this;
            volumeSlider.OnValueChanged += UpdateVolume;
        }
        else
        {
            Debug.LogWarning("Trying to create second UISustianHandler instance.");
            return;
        }
    }

    public void UpdateVolume(float value)
    {
        sustainSongLeft.SetVolume(value, true);
        sustainSongRight.SetVolume(value, true);
    }

    public void LoadSustainTrack()
    {
        FillSustainDescData();
        if (!Timeline.instance.ReplaceAudio(Timeline.LoadType.Sustain))
        {
            Debug.Log("No valid path selected");
            FillSustainDescData(true);
            return;
        }
        sustainSongLeft.SetVolume(0f, true);
        Timeline.instance.Export();
        volumeSlider.gameObject.SetActive(true);
        deleteSustainButton.SetActive(true);
        loadSustainButtonText.text = "Replace";
        volumeSlider.value = 4f;
        statusText.text = "Sustains loaded";
    }

    public void DeleteSustainTrack()
    {
        PendingDelete = true;
        FillSustainDescData(true);
        Timeline.instance.Export();
        statusText.text = "No Sustains loaded";
        Timeline.audicaFile.usesLeftSustain = false;
        Timeline.audicaFile.usesRightSustain = false;
        deleteSustainButton.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
        loadSustainButtonText.text = "Load";
        PendingDelete = false;
    }

    private void FillSustainDescData(bool clear = false)
    {
        if (clear)
        {
            Timeline.audicaFile.desc.sustainSongLeft = "";
            Timeline.audicaFile.desc.sustainSongRight = "";
            Timeline.audicaFile.desc.moggSustainSongLeft = "";
            Timeline.audicaFile.desc.moggSustainSongRight = "";
        }
        else
        {
            Timeline.audicaFile.desc.sustainSongLeft = "song_sustain_l.moggsong";
            Timeline.audicaFile.desc.sustainSongRight = "song_sustain_r.moggsong";
            Timeline.audicaFile.desc.moggSustainSongLeft = "song_sustain_l.mogg";
            Timeline.audicaFile.desc.moggSustainSongRight = "song_sustain_r.mogg";
        }
        
    }

    public void LoadVolume(bool hasSustains)
    {
        if (!hasSustains)
        {
            loadSustainButtonText.text = "Load";
            statusText.text = "No Sustains loaded";
            volumeSlider.gameObject.SetActive(false);
            deleteSustainButton.SetActive(false);
            return;
        }
        loadSustainButtonText.text = "Replace";
        statusText.text = "Sustains loaded";
        volumeSlider.gameObject.SetActive(true);
        deleteSustainButton.SetActive(true);
        volumeSlider.value = sustainSongLeft.volume.l;
    }

}
