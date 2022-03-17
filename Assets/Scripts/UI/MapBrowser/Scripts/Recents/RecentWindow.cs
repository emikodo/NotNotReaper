using AudicaTools;
using NotReaper.MapBrowser.API;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace NotReaper.MapBrowser.Recents
{
    /// <summary>
    /// Responsible for the Recents Window.
    /// </summary>
    public class RecentWindow : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private RecentDownload[] recents;
        [SerializeField] private GameObject clearButton;
        [Space, Header("Settings")]
        [SerializeField] private RecentType type = RecentType.Download;
        [NRInject] private RecentsManager manager;

        private void Start()
        {
            //manager = GetComponent<RecentsManager>();
            foreach (var recent in recents) recent.Initialize(manager, type);
            if(type == RecentType.Release)
            {
                NRDependencyInjector.Get<SearchManager>().ImmediateSearch("", CurationState.None, FilterState.All, new bool[] { false, false, false, false }, UpdateRecentReleases);
            }
        }

        /// <summary>
        /// Updates the recent buttons on the UI.
        /// </summary>
        /// <param name="fileNames">The list of recent files.</param>
        public void UpdateRecentDownloads(string downloadsFolder, List<string> fileNames)
        {
            if (type == RecentType.Release) return;

            if (fileNames is null || fileNames.Count == 0)
            {
                foreach (var recent in recents) recent.gameObject.SetActive(false);
                if(clearButton != null) clearButton.SetActive(false);
                return;
            }
            if(clearButton != null) clearButton.SetActive(true);
            for(int i = 0; i < recents.Length; i++)
            {
                if (i >= recents.Length || i >= fileNames.Count) break;
                recents[i].gameObject.SetActive(true);
                var path = Path.Combine(downloadsFolder, fileNames[i]);
                if (File.Exists(path))
                {
                    Audica audica = new(Path.Combine(downloadsFolder, fileNames[i]));
                    recents[i].SetFilename(audica);
                }
                else
                {
                    recents[i].gameObject.SetActive(false);
                }
            }
        }
        /// <summary>
        /// Updates the list of recently released maps in the PauseMenu.
        /// </summary>
        /// <param name="maps"></param>
        private void UpdateRecentReleases(List<MapData> maps)
        {
            if(maps is null || maps.Count == 0)
            {
                foreach (var recent in recents) recent.gameObject.SetActive(false);
                return;
            }
            for(int i = 0; i < recents.Length; i++)
            {
                if (i > maps.Count - 1) break;
                recents[i].gameObject.SetActive(true);
                recents[i].SetMapData(maps[i]);
            }
        }
        /// <summary>
        /// Called through UI when the Clear button is clicked. Clears recents.
        /// </summary>
        public void OnClearClicked()
        {
            UpdateRecentDownloads("", null);
            manager.ClearRecents();
        }
    }
    public enum RecentType
    {
        Download,
        Release
    }
}

