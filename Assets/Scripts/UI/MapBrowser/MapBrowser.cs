using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using NotReaper.RecentDownloads;
using System.IO;

namespace NotReaper.MapBrowser
{
    public class MapBrowser : MonoBehaviour
    {
        public static MapBrowser Instance = null;
        public static bool CancelDownload = false;
        public static State CurationState { get; set; }

        private APIHandler apiHandler = null;
        private MapBrowserCache cache = null;

        private string lastSearchText = "";
        private int page = 1;
        private bool hasMore = false;
        private int numMapsDownloading = 0;
        private int downloadedCount = 0;
        private APISongList songList = null;
        private List<MapData> failedMaps = new List<MapData>();
        private List<string> localMaps = new List<string>();
        private string downloadsFolder;
        private void Start()
        {
            if (Instance != null)
            {
                Debug.Log("MapBrowser instance already exists.");
                return;
            }
            Instance = this;
            apiHandler = new APIHandler();
            cache = new MapBrowserCache();
            HandleLocalMaps();
            //foreach (var file in files) localMaps.Add(new FileInfo(file).Name);
        }
        private const int DeleteAfterDays = 7;
        private void HandleLocalMaps()
        {
            List<string> files = new List<string>();
            files = Directory.GetFiles(Path.Combine(Application.dataPath, @"../", "downloads")).ToList();
            if (files.Count == 0) return;

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.CreationTime < DateTime.Now.AddDays(DeleteAfterDays * -1)) fi.Delete();
                else localMaps.Add(fi.Name);
            }
            
        }

        public void Search(string searchText, bool[] difficulties)
        {
            StartCoroutine(DoSearch(searchText, difficulties));
        }
        private IEnumerator DoSearch(string searchText, bool[] difficulties)
        {
            if (apiHandler is null) apiHandler = new APIHandler();
            MapEntrySpawnManager.Instance.ClearEntries();
            string requestUrl = apiHandler.GetRequestUrl(searchText, CurationState, page, difficulties);
            int count;
            songList = null;
            List<MapData> maps = new List<MapData>();

            if(cache.CheckCache(requestUrl, out MapBrowserCache.CacheEntry entry))
            {
                count = entry.count;
                hasMore = entry.hasMore;
                maps = entry.maps;
            }
            else
            {
                //songList = apiHandler.APISearch(requestUrl);
                yield return StartCoroutine(apiHandler.APISearch(requestUrl, OnSearchDone));
                count = songList.count;
                hasMore = songList.has_more;
            }
            if (count == 0)
            {
                lastSearchText = "";
                MapBrowserWindow.Instance.EnableNoResults();
                yield break;
            }
            if(songList != null)
            {
                for (int i = 0; i < songList.maps.Length; i++)
                {
                    var song = songList.maps[i];
                    var data = new MapData(song.id, song.title, song.artist, song.author, song.curated, song.filename, requestUrl, IsDownloaded(song.filename), song.difficulties);
                    maps.Add(data);
                    MapEntrySpawnManager.Instance.SpawnEntry(data);
                }
                cache.CacheQuery(requestUrl, maps, hasMore, count);
            }
            else
            {
                foreach(var data in maps) MapEntrySpawnManager.Instance.SpawnEntry(data);
            }
            lastSearchText = searchText;  
            MapBrowserWindow.Instance.UpdateNavigation(hasMore, page != 1, page, count);
        }

        private bool IsDownloaded(string filename)
        {
            return localMaps.Any(m => m == filename);
        }

        public int ChangePage(int direction, bool[] difficulties)
        {
            if ((direction == 1 && !hasMore) || (direction == -1 && page == 1)) return page;
            page += direction;
            Search(lastSearchText, difficulties);
            return page;
        }

        public void DeselectCachedEntry(string requestUrl, int mapId)
        {
            cache.DeselectCachedEntry(requestUrl, mapId);

        }

        public void Download(bool retryFailed = false)
        {
            StartCoroutine(DoDownload(retryFailed));
        }

        public void StopDownloads()
        {
            CancelDownload = true;
            //StopAllCoroutines();
        }

        private void OnDownloadStopped()
        {
            CancelDownload = false;
            MapBrowserWindow.Instance.EnableDownloadOverlay(false);
        }

        public void RetryDownload()
        {
            MapEntrySpawnManager.Instance.RemoveDownloadedEntriesFromSelection();
            Download(true);
        }
        private IEnumerator DoDownload(bool retryFailed = false)
        {
            List<MapData> maps = retryFailed ? failedMaps.ToList() : MapEntrySpawnManager.Instance.GetSelectedMapData();
            failedMaps.Clear();
            downloadedCount = 0;
            numMapsDownloading = maps.Count;
            //bool success;
            foreach(var map in maps)
            {
                if (CancelDownload)
                {
                    OnDownloadStopped();
                    yield break;
                }               
                else
                {
                    yield return StartCoroutine(apiHandler.DownloadSong(map, OnDownloadComplete));
                }
                /*try
                {
                    MapData data = await apiHandler.DownloadSelectedMap(map);
                    success = data != null;
                }
                catch
                {
                    success = false;
                }
                if (!success) failedMaps.Add(map);
                OnTaskComplete(map, success);*/
            }
            MapBrowserWindow.Instance.SetFailedMaps(failedMaps.Count);
        }

        public void OnDownloadComplete(MapData data, bool success)
        {
            if (!success) failedMaps.Add(data);
            data.SetDownloaded(success);
            if (data.SelectedEntry)
            {
                data.SelectedEntry.OnDownloaded(success);
            }
            downloadedCount++;
            float percentage = ((float)downloadedCount / (float)numMapsDownloading) * 100f;
            if(success) RecentsManager.AddRecent(data.Filename);
            MapBrowserWindow.Instance.UpdateDownloadProgress(percentage, data.SelectedEntry.GetComponent<RectTransform>());
        }

        private void OnSearchDone(APISongList songList)
        {
            this.songList = songList;
        }

        public void AddPageToSelection()
        {
            var page = MapEntrySpawnManager.Instance.GetActiveEntries();
            MapEntrySpawnManager.Instance.ClearSelectedEntries();
            foreach(var map in page)
            {
                if(!map.Data.Downloaded) map.SetSelected(true);
            }
            //MapBrowserWindow.Instance.EnableDownloadOverlay(true);
            //StartCoroutine(DownloadSelectedMaps());
        }
    }
}

