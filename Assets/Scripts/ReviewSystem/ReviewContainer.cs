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
        public string songID;
        public List<ReviewComment> comments = new List<ReviewComment>();
        public string reviewAuthor;

        public ReviewContainer(string songID)
        {
            this.songID = songID;
        }

        public ReviewContainer()
        {
            //this.songID = Timeline.desc.songID;
        }

        public static ReviewContainer Read(string path)
        {
            if (File.Exists(path)) return JsonConvert.DeserializeObject<ReviewContainer>(File.ReadAllText(path));
            else return default;
        }

        public void Export()
        {
            songID = Timeline.desc.songID;
            string dataDirectory = Application.dataPath;
            string exportFolder = Path.Combine(Directory.GetParent(dataDirectory).ToString(), "reviews");
            if (!Directory.Exists(exportFolder)) Directory.CreateDirectory(exportFolder);
            string reviewText = JsonConvert.SerializeObject(this);
            string exportPath = Path.Combine(exportFolder, $"{songID}_{reviewAuthor}.review");
            File.WriteAllText(exportPath, reviewText);
        }
    }

    [System.Serializable]
    public struct ReviewComment
    {
        public Cue[] selectedCues;
        public string description;
        public CommentType type;
        [System.NonSerialized, JsonIgnore] public CommentEntry entry;
        public ReviewComment(Cue[] selectedCues, string description, CommentType type, CommentEntry entry = null)
        {
            this.selectedCues = selectedCues;
            this.description = description;
            this.type = type;
            this.entry = entry;
        }
    }
    
    [System.Serializable]
    public enum CommentType
    {
        Negative,
        Positive,
        Suggestion,
    }
}