using NotReaper;
using NotReaper.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TimingPointsPanel : NRMenu, IPointerEnterHandler, IPointerExitHandler
{
    private bool isActive;
    [SerializeField] private Timeline timeline;
    public TimingPointItem timingPointItem;
    public Transform scrollContent;
    public List<TimingPointItem> items = new List<TimingPointItem>();
    public bool isHovering;

    protected override void Awake()
    {
        base.Awake();
        gameObject.SetActive(false);
    }

    public void Show()
    {
        OnActivated();
        transform.position = new Vector3(0f, 0f, 0f);
        gameObject.SetActive(true);
        isActive = true;
        isHovering = false;
        UpdateTimingPointList(timeline.tempoChanges);
    }

    public void Hide()
    {
        isActive = false;
        isHovering = false;
        ClearTimingItems();
        OnDeactivated();
        gameObject.SetActive(false);
    }

    public void Toggle()
    {
        if (isActive) Hide();
        else Show();
    }

    public void UpdateTimingPointList(List<TempoChange> timingPoints)
    {
        ClearTimingItems();
        for (int i = 0; i < timingPoints.Count; i++)
        {
            var item = GameObject.Instantiate(timingPointItem.gameObject, scrollContent).GetComponent<TimingPointItem>();
            item.SetInfoFromData(timingPoints[i]);
            item.transform.localPosition = new Vector3(191.3f, -32.1f * (float)i, 0f);
            item.gameObject.SetActive(true);
            items.Add(item);
        }
    }

    public void ClearTimingItems()
    {
        foreach (var item in items)
        {
            Destroy(item.gameObject);
        }
        items.Clear();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }

    protected override void OnEscPressed(InputAction.CallbackContext context)
    {
        Hide();
    }
}
