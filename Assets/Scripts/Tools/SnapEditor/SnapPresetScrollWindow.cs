using NotReaper;
using NotReaper.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NotReaper.Tools.CustomSnapMenu {
public class SnapPresetScrollWindow : MonoBehaviour
{
    public SnapPresetScrollItem snapPresetItem;
    public Transform scrollContent;
    public List<SnapPresetScrollItem> items = new List<SnapPresetScrollItem>();
    public Michsky.UI.ModernUIPack.HorizontalSelector HorizontalSnapSelector;

    public CustomSnapMenu snapMenu;


    public void Show()
    {
        gameObject.SetActive(true);
        UpdateSnapList();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        ClearSnapItems();
    }

    public void UpdateSnapList()
    {
        ClearSnapItems();
        for (int i = 0; i < HorizontalSnapSelector.elements.Count; i++)
        {
            var item = GameObject.Instantiate(snapPresetItem.gameObject, scrollContent).GetComponent<SnapPresetScrollItem>();
            item.SetInfoFromData(HorizontalSnapSelector.elements[i]);
            item.transform.localPosition = new Vector3(51, -30.1f * (float)i, 0f);
            item.gameObject.SetActive(true);
            items.Add(item);
        }
    }

    public void ClearSnapItems()
    {
        foreach (var item in items)
        {
            Destroy(item.gameObject);
        }
        items.Clear();
    }
}
}
