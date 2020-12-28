using NotReaper;
using NotReaper.Grid;
using NotReaper.Models;
using NotReaper.ReviewSystem;
using NotReaper.Targets;
using NotReaper.UI;
using NUnit.Framework;
using SFB;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace NotReaper.ReviewSystem
{
    public class ReviewWindow : MonoBehaviour
    {
        #region References
        [SerializeField] InputField descriptionField;
        [SerializeField] InputField authorField;
        [SerializeField] ToggleGroup commentTypeGroup;
        #endregion

        ReviewContainer loadedContainer;
        
        public void CreateComment()
        {
            var selectedCues = new List<Cue>();
            
            foreach (Target target in Timeline.instance.selectedNotes)
            {
                selectedCues.Add(target.ToCue());
            }

            var comment = new ReviewComment(selectedCues.ToArray(),
                descriptionField.text,
                (CommentType)int.Parse(commentTypeGroup.ActiveToggles().FirstOrDefault().name));
            
            loadedContainer.comments.Add(comment);
            
            string targetPlural = selectedCues.Count == 1 ? "target" : "targets";
            NotificationShower.Queue($"Added comment for {selectedCues.Count} {targetPlural}", NRNotifType.Success);
        }
        public void Load()
        {
            string path = StandaloneFileBrowser.OpenFilePanel("Select review file", Path.Combine(Application.persistentDataPath), ".review", false).FirstOrDefault();
            if (File.Exists(path) && path.Contains(".review"))
            {
                LoadContainer(path);
            }
            else NotificationShower.Queue($"Review file doesn't exist", NRNotifType.Fail);
        }

        void LoadContainer(string path)
        {
            if (File.Exists(path))
            {
                var container = ReviewContainer.Read(path);
                if (VerifyReview(container))
                {
                    loadedContainer = container;
                    NotificationShower.Queue($"Loaded {loadedContainer.reviewAuthor}'s review", NRNotifType.Success);
                }
                else NotificationShower.Queue("This review was made for a different song.", NRNotifType.Fail);

            }
            else loadedContainer = new ReviewContainer();
        }

        public void Export()
        {
            loadedContainer.Export();
            OpenReviewFolder();
            NotificationShower.Queue($"Successfully exported review", NRNotifType.Success);
        }

        void OpenReviewFolder()
        {
            string arguments = Path.Combine(Directory.GetParent(Application.dataPath).ToString(), "reviews");
            string fileName = "explorer.exe";

            System.Diagnostics.Process.Start(fileName, arguments);
        }

        bool VerifyReview(ReviewContainer container)
        {
            if (container.songDesc.songID == Timeline.desc.songID) return true;
            else return false;
        }
    }

}