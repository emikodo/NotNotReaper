using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

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
                    var data = new MapData(song.id, song.title, song.artist, song.author, song.curated, song.filename, requestUrl, song.difficulties);
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
            var entry = MapEntrySpawnManager.Instance.GetSelectedMapEntry(data);
            if (entry != null) entry.OnDownloaded(success);
            downloadedCount++;
            float percentage = ((float)downloadedCount / (float)numMapsDownloading) * 100f;
            MapBrowserWindow.Instance.UpdateDownloadProgress(percentage, entry.GetComponent<RectTransform>());
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
                map.SetSelected(true);
            }
            //MapBrowserWindow.Instance.EnableDownloadOverlay(true);
            //StartCoroutine(DownloadSelectedMaps());
        }
    }
}

