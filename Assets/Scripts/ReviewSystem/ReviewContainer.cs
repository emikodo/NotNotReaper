using Newtonsoft.Json;
using NotReaper.Models;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace NotReaper.ReviewSystem
{
    [System.Serializable]
    public class ReviewContainer
    {
        public SongDesc songDesc;
        public List<ReviewComment> comments = new List<ReviewComment>();
        public string reviewAuthor;

        public ReviewContainer(SongDesc songDesc)
        {
            this.songDesc = songDesc;
        }

        public ReviewContainer()
        {
            this.songDesc = Timeline.desc;
        }

        public static ReviewContainer Read(string path)
        {
            if (File.Exists(path)) return JsonConvert.DeserializeObject<ReviewContainer>(File.ReadAllText(path));
            else return default;
        }

        public void Export()
        {
            string dataDirectory = Application.dataPath;
            string exportFolder = Path.Combine(Directory.GetParent(dataDirectory).ToString(), "reviews");
            if (!Directory.Exists(exportFolder)) Directory.CreateDirectory(exportFolder);
            string reviewText = JsonConvert.SerializeObject(this);
            string exportPath = Path.Combine(exportFolder, $"{songDesc.songID}_{reviewAuthor}");
            File.WriteAllText(reviewText, exportPath);
        }
    }

    [System.Serializable]
    public struct ReviewComment
    {
        public Cue[] selectedCues;
        public string description;
        public CommentType type;
    }
    
    [System.Serializable]
    public enum CommentType
    {
        Negative,
        Positive,
        Suggestion,
    }
}