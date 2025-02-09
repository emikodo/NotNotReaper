using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DG.Tweening;
using NotReaper.Managers;
using TMPro;
using SFB;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace NotReaper.UI {

    public class UIMetadata : MonoBehaviour {

        public static UIMetadata Instance = null;
        public DifficultyManager difficultyManager;

        public Image BG;
        public CanvasGroup window;

        public List<Image> inputBoxLines = new List<Image>();
        public List<Image> inputBoxLinesCover = new List<Image>();


        public TMP_InputField titleField;
        public TMP_InputField artistField;
        public TMP_InputField mapperField;

        public Slider moggSongVolume;


        public GameObject selectDiffWindow;

        public Button generateDiff;
        public Button loadThisDiff;
        public Button deleteDiff;

        private int selectedDiff;
        private int diffPotentiallyGoingDelete = -1;

        public GameObject warningDeleteWindow;

        public TMP_Dropdown pitchDropdown;

        public Image AlbumArtImg;
        public TextMeshProUGUI artText;
        public TMP_InputField DifficultyName;
        [Space]
        [Header("Icons")]
        public Image beginnerDiffDisplay;
        public Image standardDiffDisplay;
        public Image advancedDiffDisplay;
        public Image expertDiffDisplay;
        public Sprite beginnerDiffSprite;
        public Sprite standardDiffSprite;
        public Sprite advancedDiffSprite;
        public Sprite expertDiffSprite;
        public Sprite noBeginnerDiffSprite;
        public Sprite noStandardDiffSprite;
        public Sprite noAdvancedDiffSprite;
        public Sprite noExpertDiffSprite;
        public GameObject beginnerDiffGlow;
        public GameObject standardDiffGlow;
        public GameObject advancedDiffGlow;
        public GameObject expertDiffGlow;


        public void Start() {
            if (Instance is null) Instance = this;
            else
            {
                UnityEngine.Debug.Log("Trying to create second UIMetadata instance.");
                return;
            }
            var t = transform;
            var position = t.localPosition;
            t.localPosition = new Vector3(0, position.y, position.z);
        }
        
        public void UpdateUIValues() {

            if (!Timeline.audicaLoaded) return;

            if (Timeline.desc.title != null) titleField.text = Timeline.desc.title;
            if (Timeline.desc.artist != null) artistField.text = Timeline.desc.artist;
            if (Timeline.desc.mapper != null) mapperField.text = Timeline.desc.mapper;
            if (Timeline.desc.audioFile != null) moggSongVolume.value = Timeline.audicaFile.mainMoggSong.volume.l;


            ChangeSelectedDifficulty(difficultyManager.loadedIndex);
            LoadCurrentDifficultyName(difficultyManager.loadedIndex);
            SetDifficultyIcons(difficultyManager.loadedIndex);
            StartCoroutine(
                    GetAlbumArt($"file://" + Path.Combine(Application.dataPath, ".cache", "song.png")));

        }

        public void ApplyValues() {
            if (Timeline.desc == null) return;
            if (Timeline.audicaFile == null) return;
            if (String.IsNullOrEmpty(titleField.text)) return;

            Timeline.desc.title = titleField.text;
            Timeline.desc.artist = artistField.text;
            Timeline.desc.mapper = mapperField.text;
            if (String.IsNullOrEmpty(artText.text))
            {
                Timeline.desc.albumArt = "song.png";
            }
            Timeline.audicaFile.mainMoggSong.SetVolume(moggSongVolume.value, false);
        }

        public void TryCopyCuesToOther() {
            selectDiffWindow.SetActive(true);

            switch (difficultyManager.loadedIndex) {
                case 0:
                    selectDiffWindow.GetComponent<UIDifficulty>().DifficultyComingFrom("expert");
                    break;

                case 1:
                    selectDiffWindow.GetComponent<UIDifficulty>().DifficultyComingFrom("advanced");
                    break;

                case 2:
                    selectDiffWindow.GetComponent<UIDifficulty>().DifficultyComingFrom("standard");
                    break;

                case 3:
                    selectDiffWindow.GetComponent<UIDifficulty>().DifficultyComingFrom("beginner");
                    break;
            }
        }
        //Called when a user selects a new difficulty on the song info panel
        public void ChangeSelectedDifficulty(int index) {
            if (index == -1) return;

            selectedDiff = index;

            if (difficultyManager.loadedIndex == index) {
                loadThisDiff.interactable = false;
            } else {
                loadThisDiff.interactable = true;
            }

            if (difficultyManager.DifficultyExists(index)) {
                generateDiff.interactable = false;
                deleteDiff.interactable = true;
                deleteDiff.GetComponent<Image>().color = new Color(0.8039216f, 0.8039216f, 0.8039216f);
            } else {
                generateDiff.interactable = true;
                loadThisDiff.interactable = false;
                deleteDiff.interactable = false;
                deleteDiff.GetComponent<Image>().color = new Color(0.8301887f, 0.8301887f, 0.8301887f, 0.2f);

            }
        }

        public void LoadCurrentDifficultyName(int difficultyIndex)
        {
            if (Timeline.desc == null) return;
            
            if (difficultyIndex == -1) return;
            
            // TODO evaluate applicability
            /*
            switch(difficultyIndex)
            {
                //expert
                case 0:
                    DifficultyName.text = Timeline.desc.customExpert; 
                    break;

                //Advanced
                case 1:
                    DifficultyName.text = Timeline.desc.customAdvanced; 
                    break;

                //Moderate
                case 2:
                    DifficultyName.text = Timeline.desc.customModerate; 
                    break;

                //Beginner
                case 3:
                    DifficultyName.text = Timeline.desc.customBeginner; 
                    break;

            }
            */
        }

        public void SetDifficultyIcons(int difficultyIndex)
        {
            expertDiffDisplay.sprite = difficultyManager.DifficultyExists(0) ? expertDiffSprite : noExpertDiffSprite;
            advancedDiffDisplay.sprite = difficultyManager.DifficultyExists(1) ? advancedDiffSprite : noAdvancedDiffSprite;
            standardDiffDisplay.sprite = difficultyManager.DifficultyExists(2) ? standardDiffSprite : noStandardDiffSprite;
            beginnerDiffDisplay.sprite = difficultyManager.DifficultyExists(3) ? beginnerDiffSprite : noBeginnerDiffSprite;

            switch (difficultyIndex)
            {
                //expert
                case 0:
                    expertDiffGlow.SetActive(true);
                    advancedDiffGlow.SetActive(false);
                    standardDiffGlow.SetActive(false);
                    beginnerDiffGlow.SetActive(false);
                    break;

                //Advanced
                case 1:
                    expertDiffGlow.SetActive(false);
                    advancedDiffGlow.SetActive(true);
                    standardDiffGlow.SetActive(false);
                    beginnerDiffGlow.SetActive(false);
                    break;

                //Standard
                case 2:
                    expertDiffGlow.SetActive(false);
                    advancedDiffGlow.SetActive(false);
                    standardDiffGlow.SetActive(true);
                    beginnerDiffGlow.SetActive(false);
                    break;

                //Beginner
                case 3:
                    expertDiffGlow.SetActive(false);
                    advancedDiffGlow.SetActive(false);
                    standardDiffGlow.SetActive(false);
                    beginnerDiffGlow.SetActive(true);
                    break;

            }

        }

        public void TryDeleteDifficulty() {
            string diffName = "";
            if (selectedDiff == 0) diffName = "expert";
            if (selectedDiff == 1) diffName = "advanced";
            if (selectedDiff == 2) diffName = "standard";
            if (selectedDiff == 3) diffName = "beginner";
            diffPotentiallyGoingDelete = selectedDiff;
            warningDeleteWindow.GetComponentInChildren<TextMeshProUGUI>().text = String.Format("WARNING: This will remove ALL cues in {0}. Are you SURE you want to do this?", diffName);
            warningDeleteWindow.SetActive(true);
        }

        //After the confirmation message
        public void ActuallyDeleteDifficulty() {
            warningDeleteWindow.SetActive(false);
            difficultyManager.RemoveDifficulty(diffPotentiallyGoingDelete);
            UpdateUIValues();
        }

        public void GenerateDifficulty() {
            difficultyManager.GenerateDifficulty(selectedDiff);
            difficultyManager.LoadDifficulty(selectedDiff, true);
            UpdateUIValues();
        }

        public void LoadThisDiff() {
            difficultyManager.LoadDifficulty(selectedDiff, true);
            UpdateUIValues();
        }

        public void SelectAlbumArtFile() // Album art
        {

            var compatible = new[] { new ExtensionFilter("Compatible Image Types", "png", "jpeg", "jpg") };
            string[] paths = StandaloneFileBrowser.OpenFilePanel("Select album art", Path.Combine(Application.persistentDataPath), compatible, false);
            var filePath = paths[0];

            if (filePath != null)
            {
                Process ffmpeg = new Process();
                string ffmpegPath = Path.Combine(Application.streamingAssetsPath, "FFMPEG", "ffmpeg.exe");

                if ((Application.platform == RuntimePlatform.LinuxEditor) || (Application.platform == RuntimePlatform.LinuxPlayer))
                    ffmpegPath = Path.Combine(Application.streamingAssetsPath, "FFMPEG", "ffmpeg");

                if ((Application.platform == RuntimePlatform.OSXEditor) || (Application.platform == RuntimePlatform.OSXPlayer))
                    ffmpegPath = Path.Combine(Application.streamingAssetsPath, "FFMPEG", "ffmpegOSX");

                ffmpeg.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                ffmpeg.StartInfo.FileName = ffmpegPath;

                ffmpeg.StartInfo.CreateNoWindow = true;
                ffmpeg.StartInfo.UseShellExecute = false;
                ffmpeg.StartInfo.RedirectStandardOutput = true;
                ffmpeg.StartInfo.WorkingDirectory = Path.Combine(Application.streamingAssetsPath, "FFMPEG");
                UnityEngine.Debug.Log(String.Format("-y -i \"{0}\" -vf scale=256:256 \"{1}\"", paths[0], "song.png"));
                ffmpeg.StartInfo.Arguments =
                    String.Format("-y -i \"{0}\" -vf scale=256:256 \"{1}\"", paths[0], "song.png");
                ffmpeg.Start();
                ffmpeg.WaitForExit();
                filePath = "song.png";


                StartCoroutine(
                   GetAlbumArt($"file://" + Path.Combine(Application.streamingAssetsPath, "FFMPEG", "song.png")));

                artText.text = "";

                string cachedArt = Path.Combine(Application.dataPath, ".cache", "song.png");

                File.Delete(cachedArt);
                File.Copy(Path.Combine(Application.streamingAssetsPath, "FFMPEG", filePath), cachedArt);

            }
        }

        public IEnumerator GetAlbumArt(string filepath)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(filepath);
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                AlbumArtImg.GetComponent<Image>().overrideSprite = null;
                AlbumArtImg.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                artText.text = "No Image loaded";
                UnityEngine.Debug.Log(request.error);
            }
            else
            {
                Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
                Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
                AlbumArtImg.GetComponent<Image>().overrideSprite = sprite;
                AlbumArtImg.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                artText.text = "";
            }
            yield break;
        }


        public IEnumerator FadeIn() {

            if (!Timeline.audicaLoaded) yield break;


            //Set colors
            foreach (Image img in inputBoxLines) {
                img.color = NRSettings.config.leftColor;
            }

            foreach (Image img in inputBoxLinesCover) {
                img.color = NRSettings.config.rightColor;
            }

            UpdateUIValues();

            BG.gameObject.SetActive(true);
            window.gameObject.SetActive(true);
        }

        public IEnumerator FadeOut() {
            BG.gameObject.SetActive(false);
            window.gameObject.SetActive(false);
            
            ApplyValues();
            
            yield break;
        }


    }

}