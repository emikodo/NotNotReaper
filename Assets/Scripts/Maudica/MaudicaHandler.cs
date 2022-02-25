using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using NotReaper.MapBrowser;
using AudicaTools;
namespace NotReaper.Maudica
{
    public class MaudicaHandler : MonoBehaviour
    {
        private const string MAUDICA_URL = @"https://maudica.com/api/";
        private const string ACCOUNT_ENDPOINT = @"account/me/";
        private const string MAPS_ENDPOINT = @"maps/";
        private const string APPROVE_ENDPOINT = @"approve/";
        private const string UNAPPROVE_ENDPOINT = @"unapprove/";

        public static bool IsCurator;
        private Account userAccount;
        private static Audica audica;
        private void Start()
        {
            NRSettings.OnLoad(() => 
            {
                StartCoroutine(CheckPermissions());
            });
        }

        private IEnumerator CheckPermissions()
        {
            if (NRSettings.config.maudicaToken.Length == 0) yield break;

            string requestUrl = MAUDICA_URL + ACCOUNT_ENDPOINT + @"?api_token=" + NRSettings.config.maudicaToken;
            using (UnityWebRequest www = UnityWebRequest.Get(requestUrl))
            {
                www.timeout = 20;
                yield return www.SendWebRequest();
                Debug.Log(www.downloadHandler.text);
                userAccount = JsonConvert.DeserializeObject<Account>(www.downloadHandler.text);
                if (userAccount.roles != null && userAccount.roles.Any(role => role == "curator"))
                {
                    IsCurator = true;
                }
            }
        }

        public static IEnumerator MapExists(string filepath, Action<bool> response)
        {
            if (!IsCurator) yield break;
            string requestUrl = MAUDICA_URL + MAPS_ENDPOINT;
            audica = new Audica(filepath);
            Debug.Log(audica.GetHashedSongID());
            requestUrl += "?filename=" + audica.fileName + ".audica";
            Debug.Log(requestUrl);
            using (UnityWebRequest www = UnityWebRequest.Get(requestUrl))
            {
                www.timeout = 20;
                yield return www.SendWebRequest();
                bool exists = JsonConvert.DeserializeObject<APISongList>(www.downloadHandler.text).maps.Length > 0;
                if (!exists) audica = null;
                response?.Invoke(exists);
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                audica = new Audica(Timeline.audicaFile.filepath);
                StartCoroutine(MapExists(Timeline.audicaFile.filepath, (b) => StartCoroutine(UnapproveMap())));
            }
        }

        public static IEnumerator ApproveMap()
        {
            if (!IsCurator) yield break;

            string requestUrl = MAUDICA_URL + MAPS_ENDPOINT + APPROVE_ENDPOINT;
            requestUrl += "?audica_id=" + audica.GetHashedSongID();
            requestUrl += "&api_token=" + NRSettings.config.maudicaToken;
            Debug.Log(requestUrl);
            using (UnityWebRequest www = UnityWebRequest.Get(requestUrl))
            {
                www.method = "PATCH";
                www.timeout = 20;
                yield return www.SendWebRequest();
                Debug.Log("Response: " + www.responseCode);
            }
        }

        public static IEnumerator UnapproveMap()
        {
            if (!IsCurator) yield break;
            string requestUrl = MAUDICA_URL + MAPS_ENDPOINT + UNAPPROVE_ENDPOINT;
            requestUrl += "?audica_id=" + audica.GetHashedSongID();
            requestUrl += "&api_token=" + NRSettings.config.maudicaToken;

            using (UnityWebRequest www = UnityWebRequest.Get(requestUrl))
            {
                www.method = "PATCH";
                www.timeout = 20;
                yield return www.SendWebRequest();
                Debug.Log("Response: " + www.responseCode);
            }
        }

        private class Account
        {
            public string discord_username = "";
            public string[] roles;

            public Account(string discord_username, string[] roles)
            {
                this.discord_username = discord_username;
                this.roles = roles;
            }
        }
    }
}

