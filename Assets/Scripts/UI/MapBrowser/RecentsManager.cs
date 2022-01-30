using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecentsManager : MonoBehaviour
{
    [SerializeField] public RecentDownload[] recents;

    private Tuple<bool, RecentDownload>[] entries = new Tuple<bool, RecentDownload>[6];

    private void Start()
    {
        for(int i = 0; i < recents.Length; i++)
        {
            entries[i] = new Tuple<bool, RecentDownload>(false, recents[i]);
        }
        
    }

    public void AddRecent(string fileName)
    {
        entries.Where(e => !e.Item1).FirstOrDefault();
    }
}
