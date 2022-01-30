using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RecentDownload : MonoBehaviour
{
    public string FileName
    {
        get
        {
            return fileName;
        }
        set
        {
            SetFilename(value);
        }
    }
    public TextMeshProUGUI label;

    private string fileName;

    private void SetFilename(string name)
    {
        label.text = fileName.Substring(0, fileName.Length - 6);
    }
}
