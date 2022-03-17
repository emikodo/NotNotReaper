﻿using NotReaper;
using NotReaper.Audio;
using NotReaper.UI;
using NotReaper.UI.Components;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NotReaper.Notifications;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField] NRToggle richPresence;
    [SerializeField] NRToggle clearCacheOnStartup;
    [SerializeField] NRToggle enableTraceLines;
    [SerializeField] NRToggle enableDualines;
    [SerializeField] NRToggle useAutoZOffsetWith360;
    [SerializeField] NRToggle useBouncyAnimations;
    [SerializeField] NRToggle playNoteSoundsWhileScrolling;
    [SerializeField] NRToggle autoSongVolume;
    [SerializeField] NRToggle playEndEvent;
    [SerializeField] NRToggle autoSave;

    [SerializeField] NRIconInputField savedMapperField;
    [SerializeField] NRIconInputField maudicaAccountToken;

    [SerializeField] ColorSlider LeftHand;
    [SerializeField] ColorSlider RightHand;

    [SerializeField] GameObject WarningText;

    [SerializeField] Slider slider;

    private void Start()
    {
        NRSettings.OnLoad(() => {
            UpdateUI();
        });
    }

    public void OnVolumeChanged()
    {
        float vol = slider.value;
        NRSettings.config.soundEffectsVol = vol;
        SoundEffects.Instance.PreviewVolume(vol);
    }

    public void UpdateUI()
    {
        slider.SetValueWithoutNotify(NRSettings.config.soundEffectsVol);
        richPresence.selected = NRSettings.config.useDiscordRichPresence;
        clearCacheOnStartup.selected = NRSettings.config.clearCacheOnStartup;
        enableTraceLines.selected = NRSettings.config.enableTraceLines;
        enableDualines.selected = NRSettings.config.enableDualines;
        useAutoZOffsetWith360.selected = NRSettings.config.useAutoZOffsetWith360;
        useBouncyAnimations.selected = NRSettings.config.useBouncyAnimations;
        playNoteSoundsWhileScrolling.selected = NRSettings.config.playNoteSoundsWhileScrolling;
        autoSave.selected = NRSettings.config.backups;
        autoSongVolume.selected = NRSettings.config.autoSongVolume;
        playEndEvent.selected = NRSettings.config.playEndEvent;
        LeftHand.SetColor(NRSettings.config.leftColor);
        RightHand.SetColor(NRSettings.config.rightColor);
        savedMapperField.text = NRSettings.config.savedMapperName;
        maudicaAccountToken.text = NRSettings.config.maudicaToken;
        
    }

    public void ApplyValues()
    {
        NRSettings.config.soundEffectsVol = slider.value;
        NRSettings.config.useDiscordRichPresence = richPresence.selected;
        NRSettings.config.clearCacheOnStartup = clearCacheOnStartup.selected;
        NRSettings.config.enableTraceLines = enableTraceLines.selected;
        NRSettings.config.enableDualines = enableDualines.selected;
        NRSettings.config.useAutoZOffsetWith360 = useAutoZOffsetWith360.selected;
        NRSettings.config.useBouncyAnimations = useBouncyAnimations.selected;
        NRSettings.config.playNoteSoundsWhileScrolling = playNoteSoundsWhileScrolling.selected;
        NRSettings.config.autoSongVolume = autoSongVolume.selected;
        NRSettings.config.playEndEvent = playEndEvent.selected;
        NRSettings.config.leftColor = LeftHand.color;
        NRSettings.config.rightColor = RightHand.color;
        NRSettings.config.savedMapperName = savedMapperField.text;
        NRSettings.config.maudicaToken = maudicaAccountToken.text;
        NRSettings.config.backups = autoSave.selected;
        NotificationCenter.SendNotification("Config saved. Restart NR to apply changes.", NotificationType.Success);
        NRSettings.SaveSettingsJson();
        ThemeableManager.UpdateColors();
    }

    public void ResetColors()
    {
        NRSettings.config.leftColor = new Color(0.44f, 0.78f, 1.0f, 1.0f);
        NRSettings.config.rightColor = new Color(1.0f, 0.63f, 0.45f, 1.0f);
        LeftHand.SetColor(NRSettings.config.leftColor);
        RightHand.SetColor(NRSettings.config.rightColor);
        WarningText.SetActive(true);
        NRSettings.SaveSettingsJson();
    }
}
