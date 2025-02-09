﻿using NotReaper;
using NotReaper.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class RecentPanel : View
{
    [SerializeField] Button[] buttons;
    [SerializeField] Timeline timeline;
    [SerializeField] NewPauseMenu pauseMenu;

    private void Start()
    {
        if (RecentAudicaFiles.audicaPaths == null) RecentAudicaFiles.LoadRecents();
        FillRecentButtons();
    }

    public override void Show()
    {
        if(RecentAudicaFiles.audicaPaths == null) RecentAudicaFiles.LoadRecents();
        if (RecentAudicaFiles.audicaPaths != null)
        {
            if (RecentAudicaFiles.audicaPaths.Count >= 1)
            {
                gameObject.SetActive(true);
                FillRecentButtons();
            }
        }

    }

    public override void Hide() { }

    public void FillRecentButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i >= (RecentAudicaFiles.audicaPaths.Count - 1)) return;
            string path = RecentAudicaFiles.audicaPaths[i];
            /*buttons[i].Click = new UnityEvent();
            buttons[i].NROnClick.AddListener(new UnityAction(() =>
            {
                if (!timeline.LoadAudicaFile(false, path)) return;
                pauseMenu.Hide();
            }));*/
            buttons[i].onClick = new Button.ButtonClickedEvent();
            buttons[i].onClick.AddListener(new UnityAction(() =>
            {
                timeline.LoadAudicaFile(false, path);
                if (!timeline.LoadAudicaFile(false, path)) return;
                pauseMenu.Hide();
            }));
           
            string filename = path.Split(Path.DirectorySeparatorChar).Last();
            filename = filename.Substring(0, filename.Length - 7);
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = filename;
            buttons[i].gameObject.SetActive(true);
        }
    }

    public void Clear()
    {
        RecentAudicaFiles.ClearRecents();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
