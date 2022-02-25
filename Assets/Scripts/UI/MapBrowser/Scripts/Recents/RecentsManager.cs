using Newtonsoft.Json;
using NotReaper.MapBrowser.API;
using NotReaper.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace NotReaper.MapBrowser.Recents
{
    /// <summary>
    /// Handles recent downloads.
    /// </summary>
    public class RecentsManager : MonoBehaviour
    {
        #region Fields
        private string downloadsFolder;
        private static string recentDownloadsPath;
        private static List<string> recentDownloads = null;
        private static RecentWindow window = null;
        private Action callback;
        [NRInject] NewPauseMenu pauseMenu;
        #endregion

        #region Initialization
        private void Awake()
        {
            downloadsFolder = Path.Combine(Application.dataPath, @"../", "downloads");
            recentDownloadsPath = Path.Combine(Application.persistentDataPath, "recentDownloads.json");
            window = GetComponent<RecentWindow>();
        }

        private void Start()
        {
            LoadRecents();
            
            window.UpdateRecentDownloads(recentDownloads);
        }
        #endregion

        #region Recents Handling
        /// <summary>
        /// Adds a file to the recents panel.
        /// </summary>
        /// <param name="fileName">The file to add.</param>
        public static void AddRecent(string fileName)
        {
            if (recentDownloads.Contains(fileName)) recentDownloads.Remove(fileName);
            recentDownloads.Insert(0, fileName);
            if (recentDownloads.Count > 5) recentDownloads = recentDownloads.GetRange(0, 5);
            SaveRecents();
            window.UpdateRecentDownloads(recentDownloads);
        }
        /// <summary>
        /// Loads a map in the editor.
        /// </summary>
        /// <param name="filename">The file to load.</param>
        public void LoadMap(string filename)
        {
            string path = Path.Combine(downloadsFolder, filename);
            if (Timeline.instance.LoadAudicaFile(false, path)) pauseMenu.Hide();
            //PauseMenu.Instance.ClosePauseMenu();
        }

        public void DownloadAndOpenMap(MapData map, Action callback)
        {
            this.callback = callback;
            StartCoroutine(APIHandler.DownloadMap(map, OnDownloadComplete));
        }

        private void OnDownloadComplete(MapData map, bool success)
        {
            callback?.Invoke();
            if (success)
            {
                LoadMap(map.Filename);
            }
        }
        /// <summary>
        /// Clears the recents panel.
        /// </summary>
        public void ClearRecents()
        {
            recentDownloads = new List<string>();
            SaveRecents();
        }
        #endregion

        #region IO Handling
        /// <summary>
        /// Saves recent files to a file.
        /// </summary>
        private static void SaveRecents()
        {
            string text = JsonConvert.SerializeObject(recentDownloads);
            File.WriteAllText(recentDownloadsPath, text);
        }
        /// <summary>
        /// Loads recent files from our file, or creates a new empty List if the file isn't present.
        /// </summary>
        private void LoadRecents()
        {
            if (recentDownloads != null) return;
            if (File.Exists(recentDownloadsPath))
            {
                try
                {
                    string text = File.ReadAllText(recentDownloadsPath);
                    recentDownloads = JsonConvert.DeserializeObject<List<string>>(text);
                }
                catch (Exception e)
                {
                    Debug.Log("Error: " + e);
                    throw;
                }
            }
            else
            {
                recentDownloads = new List<string>();
            }
        }
        #endregion
    }
}

