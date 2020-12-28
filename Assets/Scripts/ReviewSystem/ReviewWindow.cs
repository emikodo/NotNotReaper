using NotReaper;
using NotReaper.ReviewSystem;
using NotReaper.UI;
using SFB;
using System.IO;
using System.Linq;
using UnityEngine;

namespace NotReaper.ReviewSystem
{
    public class ReviewWindow : MonoBehaviour
    {
        ReviewContainer loadedContainer;
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