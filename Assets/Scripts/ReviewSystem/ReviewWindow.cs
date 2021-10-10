using NotReaper.Models;
using NotReaper.Targets;
using NotReaper.UI;
using NotReaper.Timing;
using SFB;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.Utilities;
using TMPro;
namespace NotReaper.ReviewSystem
{
    [RequireComponent(typeof(EditorInputDisabler))]
    public class ReviewWindow : MonoBehaviour
    {
        public static ReviewWindow Instance = null;
        public static bool IsOpen = false;
        #region References
        [SerializeField] private GameObject window;
        [SerializeField] private GameObject selectCuesPanel;
        [SerializeField] private TMP_InputField commentField;
        [SerializeField] private TMP_InputField authorField;
        [SerializeField] private TextMeshProUGUI authorText;
        [SerializeField] private TMP_Dropdown commentTypeDrop;
        [SerializeField] private TextMeshProUGUI commentTypeText;
        [SerializeField] private TextMeshProUGUI modeText;
        [SerializeField] private Button addCommentButton;
        [SerializeField] private Button deleteCommentButton;
        [SerializeField] private Button selectCuesButton;
        [SerializeField] private GameObject writeSidePanel;
        [SerializeField] private List<GameObject> bottomBarButtons;
        [SerializeField] private TextMeshProUGUI toggleCommentsButtonText;
        [Space]
        [SerializeField] private GameObject commentListPanel;
        [SerializeField] private CommentEntry commentEntryPrefab;
        [SerializeField] private RectTransform commentListContent;
        #endregion

        private ReviewContainer loadedContainer = new ReviewContainer();
        private ReviewComment currentComment;
        private ReviewMode reviewMode = ReviewMode.Read;

        private List<CommentEntry> commentEntries = new List<CommentEntry>();
        private Vector2 lastOpenPosition = Vector2.zero;
        private void Awake()
        {
            if (Instance is null) Instance = this;
            else
            {
                Debug.LogWarning("ReviewWindow already exists.");
                return;
            }
        }

        bool init = false;
        private void Start()
        {
            SetMode(ReviewMode.Read);
            ShowWindow(false);

            string exportFolder = Path.Combine(Directory.GetParent(Application.dataPath).ToString(), "reviews");
            if (!Directory.Exists(exportFolder)) Directory.CreateDirectory(exportFolder);
        }
        public void ShowWindow(bool show)
        {
            IsOpen = show;
            if (!show && init) lastOpenPosition = window.transform.localPosition;
            window.SetActive(show);
            window.transform.localPosition = show ? lastOpenPosition : new Vector2(-4300f, 0f);
            if (!init) init = true;
        }

        public void ToggleWindow()
        {
            ShowWindow(!IsOpen);
        }
        
        public void NextComment()
        {
            int nextIndex = loadedContainer.comments.IndexOf(currentComment) + 1;
            SelectComment(nextIndex);            
        }

        public void PreviousComment()
        {
            int nextIndex = loadedContainer.comments.IndexOf(currentComment) - 1;
            SelectComment(nextIndex);
        }

        public void SelectComment(int index)
        {
            if (index < 0 || index >= loadedContainer.comments.Count) return;
            Timeline.instance.DeselectAllTargets();
            currentComment = loadedContainer.comments[index];

            Cue firstCue = currentComment.selectedCues.FirstOrDefault();
            Cue lastCue = currentComment.selectedCues.LastOrDefault();

            foreach (Target target in SelectTargets(firstCue.tick, lastCue.tick))
                Timeline.instance.SelectTarget(target);

            StartCoroutine(Timeline.instance.AnimateSetTime(new QNT_Timestamp((ulong)firstCue.tick)));

            FillData();
        }

        public void FillData()
        {
            commentField.text = currentComment.description;
            switch (currentComment.type)
            {
                case CommentType.Positive:
                    commentTypeDrop.value = 1;
                    commentTypeText.text = @"<color=green>Positive";
                    break;
                case CommentType.Negative:
                    commentTypeDrop.value = 0;
                    commentTypeText.text = @"<color=orange>Negative";
                    break;
                case CommentType.Suggestion:
                    commentTypeDrop.value = 2;
                    commentTypeText.text = @"<color=lightblue>Suggestion";
                    break;
            }
        }

        public void RemoveComment()
        {
            if (loadedContainer.comments.Contains(currentComment))
            {
                Timeline.instance.DeselectAllTargets();
                RemoveCommentEntry(currentComment);
                loadedContainer.comments.Remove(currentComment);
                NotificationShower.Queue($"Removed comment", NRNotifType.Success);
            }
            else NotificationShower.Queue($"Comment doesn't exist", NRNotifType.Fail);
        }

        /// <summary>
        /// Creates a review comment using selected notes and text fields.
        /// </summary>
        public void CreateComment()
        {
            var selectedCues = new List<Cue>();
            
            foreach (Target target in Timeline.instance.selectedNotes)
            {
                selectedCues.Add(target.ToCue());
            }
            selectedCues.Sort((c1, c2) => c1.tick.CompareTo(c2.tick));
            var comment = new ReviewComment(selectedCues.ToArray(),
                commentField.text,
                (CommentType)commentTypeDrop.value);
            
            loadedContainer.comments.Add(comment);
            if(loadedContainer.comments.Count > 1) loadedContainer.comments.Sort((c1, c2) => c1.selectedCues.First().tick.CompareTo(c2.selectedCues.First().tick));
            string targetPlural = selectedCues.Count == 1 ? "target" : "targets";
            NotificationShower.Queue($"Added comment for {selectedCues.Count} {targetPlural}", NRNotifType.Success);

            CreateCommentEntry(comment);
            currentComment = new ReviewComment();
            FillData();
        }

        public void CreateCommentEntry(ReviewComment comment)
        {
            var entry = GameObject.Instantiate(commentEntryPrefab, commentListContent);
            comment.entry = entry;
            entry.SetComment(comment);
            entry.Index = loadedContainer.comments.IndexOf(comment);
            commentEntries.Add(entry);
            SortEntries();
           
          
        }
        public void RemoveCommentEntry(ReviewComment comment)
        {
            int index = loadedContainer.comments.IndexOf(comment);
            var entry = commentEntries[index];
            commentEntries.RemoveAt(index);
            Destroy(entry.gameObject);
            SortEntries();
        }

        private void SortEntries()
        {
            commentEntries.Sort((c1, c2) => c1.StartTick.CompareTo(c2.StartTick));
            int index = 0;
            foreach (CommentEntry ce in commentEntries)
            {
                ce.Index = index;
                index++;
            }
        }
        public void Load()
        {
            string reviewDirectory = Path.Combine(Directory.GetParent(Application.dataPath).ToString(), "reviews");
            string path = StandaloneFileBrowser.OpenFilePanel("Select review file", reviewDirectory, "review", false).FirstOrDefault();
            if (File.Exists(path) && path.Contains(".review")) LoadContainer(path);
            else NotificationShower.Queue($"Review file doesn't exist", NRNotifType.Fail);
        }

        public void SetMode(ReviewMode mode)
        {
            bool isReadMode = mode == ReviewMode.Read;
            commentTypeDrop.gameObject.SetActive(!isReadMode);
            commentTypeText.gameObject.SetActive(isReadMode);
            commentField.interactable = !isReadMode;
            addCommentButton.gameObject.SetActive(!isReadMode);
            selectCuesButton.gameObject.SetActive(!isReadMode);
            deleteCommentButton.gameObject.SetActive(!isReadMode);
            writeSidePanel.gameObject.SetActive(!isReadMode);

            reviewMode = mode;
        }

        public void SelectCues(bool selectMode)
        {
            window.SetActive(!selectMode);
            selectCuesPanel.SetActive(selectMode);

            foreach (GameObject go in bottomBarButtons) go.SetActive(!selectMode);
        }

        public void ToggleMode()
        {
            SetMode(reviewMode == ReviewMode.Read ? ReviewMode.Write : ReviewMode.Read);
        }

        void LoadContainer(string path)
        {
            if (File.Exists(path))
            {
                var container = ReviewContainer.Read(path);
                if (VerifyReview(container))
                {
                    foreach (CommentEntry entry in commentEntries) Destroy(entry.gameObject);
                    commentEntries.Clear();
                    currentComment = new ReviewComment();

                    loadedContainer = container;
                    NotificationShower.Queue($"Loaded {loadedContainer.reviewAuthor}'s review", NRNotifType.Success);
                    authorField.text = loadedContainer.reviewAuthor;
                    authorText.text = loadedContainer.reviewAuthor;
                    SetMode(ReviewMode.Read);
                    foreach (ReviewComment comment in loadedContainer.comments) CreateCommentEntry(comment);
                    NextComment();
                }
                else NotificationShower.Queue("This review was made for a different song.", NRNotifType.Fail);

            }
            else loadedContainer = new ReviewContainer();
        }

        public void OnAuthorNameChanged()
        {
            loadedContainer.reviewAuthor = authorField.text;
            authorText.text = authorField.text;
        }

        public void Export()
        {
            loadedContainer.Export();
            OpenReviewFolder();
            NotificationShower.Queue($"Successfully exported review", NRNotifType.Success);
        }

        public void ToggleComments()
        {
            bool active = !commentListPanel.activeSelf;
            commentListPanel.SetActive(active);
            toggleCommentsButtonText.text = active ? "Hide Comments" : "Show Comments";
        }

        void OpenReviewFolder()
        {
            string arguments = Path.Combine(Directory.GetParent(Application.dataPath).ToString(), "reviews");
            string fileName = "explorer.exe";

            System.Diagnostics.Process.Start(fileName, arguments);
        }

        public enum ReviewMode
        {
            Read,
            Write
        }

        bool VerifyReview(ReviewContainer container) 
            => container.songID == Timeline.audicaFile.desc.songID;


        /// <summary>
        /// Enumerates targets within a tick range.
        /// </summary>
        IEnumerable<Target> SelectTargets(int startTick, int endTick) =>
            from target in Timeline.orderedNotes
            where target.data.time.tick >= (ulong)startTick &&
                  target.data.time.tick <= (ulong)endTick
            select target;
    }

}