using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookmarkColorPicker : MonoBehaviour
{
    public static BookmarkColorPicker Instance = null;
    public static Color selectedColor;
    public static BookmarkUIColor selectedUIColor;

    public BookmarkColor red;
    public BookmarkColor blue;
    public BookmarkColor green;
    public BookmarkColor yellow;
    public BookmarkColor purple;
    public BookmarkColor icy;


    private void Start()
    {
        if (Instance is null) Instance = this;
        else
        {
            Debug.LogWarning("Trying to create second BookmarkColorPicker instance.");
            return;
        }
        selectedUIColor = BookmarkUIColor.Red;
        selectedColor = red.color;
    }

    public void SetColorRed()
    {
        DeselectAll();
        selectedUIColor = BookmarkUIColor.Red;
        selectedColor = red.color;
        red.EnableGlow(true);
    }

    public void SetColorBlue()
    {
        DeselectAll();
        selectedUIColor = BookmarkUIColor.Blue;
        selectedColor = blue.color;
        blue.EnableGlow(true);
    }

    public void SetColorGreen()
    {
        DeselectAll();
        selectedUIColor = BookmarkUIColor.Green;
        selectedColor = green.color;
        green.EnableGlow(true);
    }

    public void SetColorYellow()
    {
        DeselectAll();
        selectedUIColor = BookmarkUIColor.Yellow;
        selectedColor = yellow.color;
        yellow.EnableGlow(true);
    }

    public void SetColorPurple()
    {
        DeselectAll();
        selectedUIColor = BookmarkUIColor.Purple;
        selectedColor = purple.color;
        purple.EnableGlow(true);
    }

    public void SetColorIcy()
    {
        DeselectAll();
        selectedUIColor = BookmarkUIColor.Icy;
        selectedColor = icy.color;
        icy.EnableGlow(true);
    }

    private void DeselectAll()
    {
        red.EnableGlow(false);
        blue.EnableGlow(false);
        green.EnableGlow(false);
        yellow.EnableGlow(false);
        purple.EnableGlow(false);
        icy.EnableGlow(false);
    }

    public BookmarkUIColor GetUIColor()
    {
        return selectedUIColor;
    }

    public Color GetUIColor(BookmarkUIColor uiColor)
    {
        switch (uiColor)
        {
            case BookmarkUIColor.Blue:
                return blue.color;
            case BookmarkUIColor.Green:
                return green.color;
            case BookmarkUIColor.Icy:
                return icy.color;
            case BookmarkUIColor.Purple:
                return purple.color;
            case BookmarkUIColor.Red:
                return red.color;
            case BookmarkUIColor.Yellow:
                return yellow.color;
            default:
                return Color.red;
        }
    }
}

public enum BookmarkUIColor
{
    Red,
    Blue,
    Green,
    Yellow,
    Purple,
    Icy
}
