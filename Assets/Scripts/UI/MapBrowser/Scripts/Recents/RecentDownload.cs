using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace NotReaper.MapBrowser.Recents
{
    /// <summary>
    /// Represents a recent download.
    /// </summary>
    public class RecentDownload : MonoBehaviour
    {
        private RecentType type = RecentType.Download;
        private TextMeshProUGUI label;
        private RecentsManager manager;
        private string fileName;
        private MapData data;

        private void Awake()
        {
            label = GetComponentInChildren<TextMeshProUGUI>();
        }

        /// <summary>
        /// Set the RecentsManager.
        /// </summary>
        /// <param name="manager">The RecentsManager.</param>
        public void Initialize(RecentsManager manager, RecentType type)
        {
            this.manager = manager;
            this.type = type;
        }
        /// <summary>
        /// Set the filename for this recent download.
        /// </summary>
        /// <param name="fileName">The filename of the recent download.</param>
        public void SetFilename(string fileName)
        {
            this.fileName = fileName;
            label.text = this.fileName.Substring(0, this.fileName.Length - 7).ToLower();
        }
        /// <summary>
        /// Set the MapData of this recent release.
        /// </summary>
        /// <param name="map">The MapData of the recent release.</param>
        public void SetMapData(MapData map)
        {
            data = map;
            SetFilename(map.Filename);
        }

        /// <summary>
        /// Called through UI when this RecentDownload is clicked.
        /// </summary>
        public void OnClick()
        {
            if (manager is null)
            {
                Debug.LogWarning("RecentDownload hasn't been initialized!");
                return;
            }
            if(type == RecentType.Download)
            {
                manager.LoadMap(fileName);
            }
            else
            {
                label.text = "downloading..";
                manager.DownloadAndOpenMap(data, OnDownloadDone);
            }
        }

        private void OnDownloadDone()
        {
            SetFilename(fileName);
        }
    }

}
