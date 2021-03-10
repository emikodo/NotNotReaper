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


        public DifficultyManager difficultyManager;

        public Image BG;
        public CanvasGroup window;

        public Image titleLine;
        public List<Image> inputBoxLines = new List<Image>();
        public List<Image> inputBoxLinesCover = new List<Image>();


        public TMP_InputField titleField;
        public TMP_InputField artistField;
        public TMP_InputField mapperField;

        public Slider moggSongVolume;


        public GameObject selectDiffWindow;

        public Button generateDiff;
        public Button loadThisDiff;

        private int selectedDiff;
        private int diffPotentiallyGoingDelete = -1;

        public GameObject warningDeleteWindow;

        public TMP_Dropdown diffDropdown;
        public TMP_Dropdown pitchDropdown;

        public Image AlbumArtImg;
        public TextMeshProUGUI artText;
        public TMP_InputField DifficultyName;


        public void Start() {
            var t = transform;
            var position = t.localPosition;
            t.localPosition = new Vector3(0, position.y, position.z);
        }
        
        public void UpdateUIValues() {

            if (!Timeline.audicaLoaded) return;

            if (Timeline.desc.title != null) titleField.text = Timeline.desc.title;
            if (Timeline.desc.artist != null) artistField.text = Timeline.desc.artist;
            if (Timeline.desc.author != null) mapperField.text = Timeline.desc.author;
            if (Timeline.desc.moggSong != null) moggSongVolume.value = Timeline.audicaFile.mainMoggSong.volume.l;


            diffDropdown.value = difficultyManager.loadedIndex;
            ChangeSelectedDifficulty(difficultyManager.loadedIndex);
            LoadCurrentDifficultyName(difficultyManager.loadedIndex);
            // Song end pitch event
            switch (Timeline.desc.songEndEvent)
            {
                case "event:/song_end/song_end_nopitch":
                    pitchDropdown.value = 0;
                    break;

                case "event:/song_end/song_end_A":
                    pitchDropdown.value = 1;
                    break;

                case "event:/song_end/song_end_A#":
                    pitchDropdown.value = 2;
                    break;

                case "event:/song_end/song_end_B":
                    pitchDropdown.value = 3;
                    break;

                case "event:/song_end/song_end_C":
                    pitchDropdown.value = 4;
                    break;

                case "event:/song_end/song_end_C#":
                    pitchDropdown.value = 5;
                    break;

                case "event:/song_end/song_end_D":
                    pitchDropdown.value = 6;
                    break;

                case "event:/song_end/song_end_D#":
                    pitchDropdown.value = 7;
                    break;

                case "event:/song_end/song_end_E":
                    pitchDropdown.value = 8;
                    break;

                case "event:/song_end/song_end_F":
                    pitchDropdown.value = 9;
                    break;

                case "event:/song_end/song_end_F#":
                    pitchDropdown.value = 10;
                    break;

                case "event:/song_end/song_end_G":
                    pitchDropdown.value = 11;
                    break;

                case "event:/song_end/song_end_G#":
                    pitchDropdown.value = 12;
                    break;
            }

            StartCoroutine(
                    GetAlbumArt($"file://" + Path.Combine(Application.dataPath, ".cache", "song.png")));

        }

        public void ApplyValues() {
            if (Timeline.desc == null) return;

            if (String.IsNullOrEmpty(titleField.text)) return;

            Timeline.desc.title = titleField.text;
            Timeline.desc.artist = artistField.text;
            Timeline.desc.author = mapperField.text;
            if (String.IsNullOrEmpty(artText.text))
            {
                Timeline.desc.albumArt = "song.png";
            }
            Timeline.audicaFile.mainMoggSong.SetVolume(moggSongVolume.value);
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
                    selectDiffWindow.GetComponent<UIDifficulty>().DifficultyComingFrom("easy");
                    break;
            }
        }
        //Called when the value is changed the dropdown box for the difficulties
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
            } else {
                generateDiff.interactable = true;
                loadThisDiff.interactable = false;
            }
        }

        public void SetDifficultyName()
        {
            if (Timeline.desc == null) return;

            int difficultyIndex = difficultyManager.loadedIndex;
            
            if (difficultyIndex == -1) return;
            
            switch(difficultyIndex)
            {
                //expert
                case 0:
                    Timeline.desc.customExpert = DifficultyName.text; 
                    break;

                //Advanced
                case 1:
                    Timeline.desc.customAdvanced = DifficultyName.text; 
                    break;

                //Moderate
                case 2:
                    Timeline.desc.customModerate = DifficultyName.text; 
                    break;

                //Beginner
                case 3:
                    Timeline.desc.customBeginner = DifficultyName.text; 
                    break;

            }
        }

        public void LoadCurrentDifficultyName(int difficultyIndex)
        {
            if (Timeline.desc == null) return;
            
            if (difficultyIndex == -1) return;
            
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
        }

        public void ChangeEndPitch()
        {
            switch (pitchDropdown.value)
            {
                case 0:
                    Timeline.desc.songEndEvent = "event:/song_end/song_end_nopitch";
                    break;

                case 1:
                    Timeline.desc.songEndEvent = "event:/song_end/song_end_A";
                    break;

                case 2:
                    Timeline.desc.songEndEvent = "event:/song_end/song_end_A#";
                    break;

                case 3:
                    Timeline.desc.songEndEvent = "event:/song_end/song_end_B";
                    break;

                case 4:
                    Timeline.desc.songEndEvent = "event:/song_end/song_end_C";
                    break;

                case 5:
                    Timeline.desc.songEndEvent = "event:/song_end/song_end_C#";
                    break;

                case 6:
                    Timeline.desc.songEndEvent = "event:/song_end/song_end_D";
                    break;

                case 7:
                    Timeline.desc.songEndEvent = "event:/song_end/song_end_D#";
                    break;

                case 8:
                    Timeline.desc.songEndEvent = "event:/song_end/song_end_E";
                    break;

                case 9:
                    Timeline.desc.songEndEvent = "event:/song_end/song_end_F";
                    break;

                case 10:
                    Timeline.desc.songEndEvent = "event:/song_end/song_end_F#";
                    break;

                case 11:
                    Timeline.desc.songEndEvent = "event:/song_end/song_end_G";
                    break;

                case 12:
                    Timeline.desc.songEndEvent = "event:/song_end/song_end_G#";
                    break;
            }
        }

        public void TryDeleteDifficulty() {
            string diffName = "";
            if (selectedDiff == 0) diffName = "expert";
            if (selectedDiff == 1) diffName = "advanced";
            if (selectedDiff == 2) diffName = "standard";
            if (selectedDiff == 3) diffName = "easy";
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

            titleLine.color = NRSettings.config.leftColor;

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