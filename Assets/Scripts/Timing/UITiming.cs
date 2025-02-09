using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using DG.Tweening;
using NLayer;
using NotReaper.IO;
using NotReaper.UI;
using NotReaper.UserInput;
using NotReaper.Tools;
using SFB;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using NotReaper.Models;

namespace NotReaper.Timing {


    public class UITiming : MonoBehaviour {


        [Header("UI Elements")]
        public Button genAudicaButton;
        public Button selectSongButton;
        public Button selectMidiButton;
        public Button selectArtButton;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI midiText;
        public TextMeshProUGUI artText;
        public TMP_InputField songNameInput;
        public TMP_InputField mapperInput;
        public TMP_InputField artistInput;


        [Header("Extras")]
        public Image BG;
        public Image AlbumArtImg;
        public CanvasGroup window;
        public UIInput uiInput;
        public int Setdifficulty = 0;

        private AudioClip audioFile;
        public Timeline timeline;
        public string loadedSong;
        public string loadedMidi;
        public string loadedArt;

        public string songName = "";
        public string mapperName = "";
        public string artistName = "";
        public string songEndEvent = "";

        public float moggSongVolume = -5;

        public bool skipOffset = true;
        public bool isMp3 = false;

        const int DefaultBPM = 150;

        [Space]
        [Header("Icons")]
        public TextMeshProUGUI beginnerText;
        public TextMeshProUGUI standardText;
        public TextMeshProUGUI advancedText;
        public TextMeshProUGUI expertText;
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


        TrimAudio trimAudio = new TrimAudio();

        Process ffmpeg = new Process();

        public static UITiming Instance = null;

        private void Awake()
        {
            Instance = this;
        }

        private void Start() {
            var t = this.transform;
            var position = t.localPosition;
            t.localPosition = new Vector3(0, position.y, position.z);
            window.alpha = 0;

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

        }

        public void UpdateUIValues() {
            if (NRSettings.config.savedMapperName != null) mapperInput.text = NRSettings.config.savedMapperName;
        }


        public void SkipOffset(bool yes) {

            skipOffset = yes;

        }
        


        public void SelectAudioFile() {
            var compatible = new[] { new ExtensionFilter("Compatible Audio Types", "mp3", "ogg", "flac") };
            //string[] paths = StandaloneFileBrowser.OpenFilePanel("Select music track", Path.Combine(Application.persistentDataPath), compatible, false);
            string[] paths = StandaloneFileBrowser.OpenFilePanel("Select music track", PlayerPrefs.GetString("lastSong"), compatible, false);
            if (paths is null || paths.Length == 0) return;
            var filePath = paths[0];
            PlayerPrefs.SetString("lastSong", Path.GetDirectoryName(filePath));
            if (filePath != null) {
                // if user loads mp3 or flac instead of ogg, do the conversion first
                if (paths[0].EndsWith(".mp3") || paths[0].EndsWith(".flac"))
                {
                    UnityEngine.Debug.Log(String.Format("-y -i \"{0}\" -map 0:a \"{1}\"", paths[0], "converted.ogg"));
                    ffmpeg.StartInfo.Arguments =
                        String.Format("-y -i \"{0}\" -map 0:a \"{1}\"", paths[0], "converted.ogg");
                    ffmpeg.Start();
                    ffmpeg.WaitForExit();
                    filePath = "converted.ogg";

                    isMp3 = true;

                    StartCoroutine(
	                    GetAudioClip($"file://" + Path.Combine(Application.streamingAssetsPath, "FFMPEG", filePath)));
                }

                else {
	                isMp3 = false;
                    StartCoroutine(GetAudioClip(filePath));
                }

                nameText.text = System.IO.Path.GetFileName(paths[0]);
	            loadedSong = paths[0];
                if (NRSettings.config.autoSongVolume) {
                    SetAutoVolume();
                }
            }
        }

        public void SetAutoVolume() // Compare to normalized and set song volume in moggsong to match OST
        {
            string retMessage = string.Empty;
            UnityEngine.Debug.Log("Start auto song volume");
            ffmpeg.StartInfo.RedirectStandardError = true;
            ffmpeg.StartInfo.Arguments =
            String.Format("-i \"{0}\" -filter:a volumedetect -f null /dev/null", loadedSong);
            ffmpeg.Start();
            retMessage = ffmpeg.StandardError.ReadToEnd();
            ffmpeg.WaitForExit();
            ffmpeg.Close();

            var outputFile = Path.Combine(Application.streamingAssetsPath, "Ogg2Audica", "audioOutput.txt");
            File.Delete(outputFile);
            File.WriteAllText(outputFile, retMessage);

            string max_volume = string.Empty; // Pulling max_volume line
            string songNameMeta = string.Empty; // Pulling meta
            string artistMeta = string.Empty;
            foreach (var line in File.ReadLines(outputFile))
            {
                if (line.Contains("max_volume:"))
                {
                    max_volume = line;
                }
                if (line.Contains(" title"))
                {
                    songNameMeta = line;
                }
                if (line.Contains(" artist"))
                {
                    artistMeta = line;
                }
            }
            string normalized_db = max_volume.Split(' ')[4]; // Grab only the number

            float foundVolume = float.Parse(normalized_db); // Crappy maths
            if (foundVolume > 0){
                foundVolume *= -1;
            }
            else if (foundVolume < 0){
                foundVolume = Mathf.Abs(foundVolume);
            }
            moggSongVolume = foundVolume - Mathf.Abs(moggSongVolume);

            if (!String.IsNullOrEmpty(songNameMeta))
            {
                string songNameMetaOnly = songNameMeta.Split(':')[1];
                songNameMetaOnly = songNameMetaOnly.TrimStart(' ');
                songNameInput.text = songNameMetaOnly;
            }
            if (!String.IsNullOrEmpty(artistMeta))
            {
                string artistMetaOnly = artistMeta.Split(':')[1];
                artistMetaOnly = artistMetaOnly.TrimStart(' ');
                artistInput.text = artistMetaOnly;
            }
        }

        public void SelectMidiFile() // Load Midi for tempo
        {
            var compatible = new[] { new ExtensionFilter("MIDI", "mid") };
            //string[] paths = StandaloneFileBrowser.OpenFilePanel("Select midi tempo map", Path.Combine(Application.persistentDataPath), compatible, false);
            string[] paths = StandaloneFileBrowser.OpenFilePanel("Select midi tempo map", PlayerPrefs.GetString("lastMidi"), compatible, false);
            if (paths is null || paths.Length == 0) return;
            var filePath = paths[0];
            PlayerPrefs.SetString("lastMidi", Path.GetDirectoryName(filePath));
            if (filePath != null)
            {
                midiText.text = System.IO.Path.GetFileName(paths[0]);
                loadedMidi = paths[0];
            }
        }

        public void SelectAlbumArtFile() // Album art
        {
            var compatible = new[] { new ExtensionFilter("Compatible Image Types", "png", "jpeg", "jpg") };
            //string[] paths = StandaloneFileBrowser.OpenFilePanel("Select album art", Path.Combine(Application.persistentDataPath), compatible, false);
            string[] paths = StandaloneFileBrowser.OpenFilePanel("Select album art", PlayerPrefs.GetString("lastAlbumArt"), compatible, false);
            if (paths is null || paths.Length == 0) return;
            var filePath = paths[0];
            PlayerPrefs.SetString("lastAlbumArt", Path.GetDirectoryName(filePath));
            if (filePath != null)
            {

                UnityEngine.Debug.Log(String.Format("-y -i \"{0}\" -vf scale=256:256 \"{1}\"", paths[0], "song.png"));
                ffmpeg.StartInfo.Arguments =
                    String.Format("-y -i \"{0}\" -vf scale=256:256 \"{1}\"", paths[0], "song.png");
                ffmpeg.Start();
                ffmpeg.WaitForExit();
                filePath = "song.png";


                 StartCoroutine(
                    GetAlbumArt($"file://" + Path.Combine(Application.streamingAssetsPath, "FFMPEG", filePath)));

                artText.text = "";
                loadedArt = Path.Combine(Application.streamingAssetsPath, "FFMPEG", "song.png");

            }
        }

        public void Cancel() {
            Timeline.inTimingMode = false;
            //uiInput.SelectMode(EditorMode.Compose);
            EditorState.SelectMode(EditorMode.Compose);
        }

        public void ChangeSelectedDifficulty(int diff) // Diff buttons on "New Audica" panel. (there's probably a better solution to reset colors)
        {
            expertText.color = new Color(0.8301887f, 0.8301887f, 0.8301887f, 0.8039216f);
            advancedText.color = new Color(0.8301887f, 0.8301887f, 0.8301887f, 0.8039216f);
            standardText.color = new Color(0.8301887f, 0.8301887f, 0.8301887f, 0.8039216f);
            beginnerText.color = new Color(0.8301887f, 0.8301887f, 0.8301887f, 0.8039216f);
            expertDiffDisplay.sprite = noExpertDiffSprite;
            advancedDiffDisplay.sprite = noAdvancedDiffSprite;
            standardDiffDisplay.sprite = noStandardDiffSprite;
            beginnerDiffDisplay.sprite = noBeginnerDiffSprite;

            switch (diff)
            {
                case 0:
                    Setdifficulty = 0;
                    expertDiffDisplay.sprite = expertDiffSprite;
                    expertText.color = new Color(0.74118f, 0.15686f, 1.00000f);
                    break;
                case 1:
                    Setdifficulty = 1;
                    advancedDiffDisplay.sprite = advancedDiffSprite;
                    advancedText.color = new Color(0.91765f, 0.65098f, 0.05490f);
                    break;
                case 2:
                    Setdifficulty = 2;
                    standardDiffDisplay.sprite = standardDiffSprite;
                    standardText.color = new Color(0.16078f, 0.86275f, 0.93725f);
                    break;
                case 3:
                    Setdifficulty = 3;
                    beginnerDiffDisplay.sprite = beginnerDiffSprite;
                    beginnerText.color = new Color(0.28235f, 0.87059f, 0.10980f);
                    break;
                default:
                    Setdifficulty = 0;
                    expertDiffDisplay.sprite = expertDiffSprite;
                    expertText.color = new Color(0.74118f, 0.15686f, 1.00000f);
                    break;
            }
        }


        public void ApplyValues() {

            if (!timeline.paused) {
                timeline.TogglePlayback();
            }

            timeline.SetTimingModeStats(Constants.MicrosecondsPerQuarterNoteFromBPM(DefaultBPM), 0);

            mapperName = mapperInput.text;
            songName = songNameInput.text;
            artistName = artistInput.text;
            songEndEvent = KeyScraper.GetSongEndEvent(artistInput.text, songNameInput.text);

            CheckAllUIFilled();

        }

        public void GenerateOgg() {
            ApplyValues();
            if(!CheckAllUIFilled()) {
                return;
            }
            

	        string path;
            Difficulty difficulty;
            switch (Setdifficulty)
            {
                case 0:
                    difficulty = Difficulty.Expert;
                    break;
                case 1:
                    difficulty = Difficulty.Advanced;
                    break;
                case 2:
                    difficulty = Difficulty.Standard;
                    break;
                case 3: 
                    difficulty = Difficulty.Easy;
                    break;
                default:
                    difficulty = Difficulty.Expert;
                    break;
            }
	        if (isMp3 || !skipOffset) {
                trimAudio.SetAudioLength(loadedSong, Path.Combine(Application.streamingAssetsPath, "FFMPEG", "output.ogg"), 0, DefaultBPM, skipOffset);
                //path = AudicaGenerator.Generate(Path.Combine(Application.streamingAssetsPath, "FFMPEG", "output.ogg"), moggSongVolume, RemoveSpecialCharacters(songName + "-" + mapperName), songName, artistName, DefaultBPM, songEndEvent, mapperName, 0, loadedMidi, loadedArt, difficulty);
		        
	        }
	        else {
                //path = AudicaGenerator.Generate(loadedSong, moggSongVolume, RemoveSpecialCharacters(songName + "-" + mapperName), songName, artistName, DefaultBPM, songEndEvent, mapperName, 0, loadedMidi, loadedArt, difficulty);
	        }
	        
            //timeline.LoadAudicaFile(false, path);
            //uiInput.SelectMode(EditorMode.Compose);
            EditorState.SelectMode(EditorMode.Compose);

            genAudicaButton.interactable = true;
            selectSongButton.interactable = false;
            selectMidiButton.interactable = false;
            selectArtButton.interactable = false;
        }

        public bool CheckAllUIFilled() {
            var workFolder = Path.Combine(Application.streamingAssetsPath, "Ogg2Audica");
            if (loadedSong != "" && mapperName != "" && songName != "" && artistName != "")
            {
                if (loadedMidi != "")
                {
                    return true;
                }
                else
                {
                    loadedMidi = Path.Combine(workFolder, "songtemplate.mid");
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public IEnumerator FadeIn() {


            float fadeDuration = (float) NRSettings.config.UIFadeDuration;


            BG.DOFade(1.0f, fadeDuration / 2f);

            yield return new WaitForSeconds(fadeDuration / 4f);

            DOTween.To(x => window.alpha = x, 0.0f, 1.0f, fadeDuration / 2f);
           
            UpdateUIValues();

            yield break;

        }

        public IEnumerator FadeOut() {

            float fadeDuration = (float) NRSettings.config.UIFadeDuration;

            DOTween.To(x => window.alpha = x, 1.0f, 0.0f, fadeDuration / 4f);

            BG.DOFade(0.0f, fadeDuration / 2f);

            yield return new WaitForSeconds(fadeDuration / 2f);

            UpdateUIValues();
            this.gameObject.SetActive(false);

            yield break;
        }


        IEnumerator GetAudioClip(string uri) {
            using(UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(uri, AudioType.OGGVORBIS)) {
                yield return www.SendWebRequest();

                if (www.isNetworkError) {
                    UnityEngine.Debug.Log(www.error);
                } else {
                    audioFile = DownloadHandlerAudioClip.GetContent(www);
                    timeline.LoadTimingMode(audioFile);
                    ApplyValues();

                    yield break;
                }
            }
        }

        IEnumerator GetAlbumArt(string filepath)
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
                AlbumArtImg.GetComponent<Image>().sprite = sprite;
                AlbumArtImg.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            yield break;
        }

        public void SetEmptyArt()
        {
            AlbumArtImg.GetComponent<Image>().sprite = null;
        }

        public AudioClip LoadMp3(string filePath) {
            string filename = System.IO.Path.GetFileNameWithoutExtension(filePath);

            MpegFile mpegFile = new MpegFile(filePath);

            // assign samples into AudioClip
            AudioClip ac = AudioClip.Create(filename,
                (int) (mpegFile.Length / sizeof(float) / mpegFile.Channels),
                mpegFile.Channels,
                mpegFile.SampleRate,
                true,
                data => { int actualReadCount = mpegFile.ReadSamples(data, 0, data.Length); },
                position => { mpegFile = new MpegFile(filePath); });

            //mpegFile.Dispose();

            return ac;
        }

        public string RemoveSpecialCharacters(string str) {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str) {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '_' || c == '-') {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }

}