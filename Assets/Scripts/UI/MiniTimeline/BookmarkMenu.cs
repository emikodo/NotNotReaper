using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NotReaper.Notifications;
using UnityEngine.InputSystem;
namespace NotReaper.UI
{
    public class BookmarkMenu : NRMenu
    {
        public static BookmarkMenu Instance = null;
        public static bool isActive = false;
        public static bool inputFocused = false;
        public TMP_InputField inputField;
        public GameObject menu;
        private Vector3 activatePosition = new Vector3(0f, 0f, 0f);

        private void Start()
        {
            if (Instance is null) Instance = this;
            else
            {
                Debug.LogWarning("Trying to create a second BookmarkMenu instance.");
                return;
            }
            inputField.onSelect.AddListener(OnInputFocused);
            inputField.onDeselect.AddListener(OnInputFocused);
            menu.SetActive(false);
        }

        private void OnInputFocused(string _)
        {
            inputFocused = !inputFocused;
        }
        public void Activate(bool active)
        {
            isActive = active;
            menu.transform.localPosition = active ? activatePosition : new Vector3(-3000f, 13f, 0f);
            if (active) OnActivated();
            else OnDeactivated();
            //activatePosition = menu.transform.localPosition;
            menu.SetActive(active);
        }
        public void SetText(string text)
        {
            inputField.text = text;
        }

        public void Save()
        {
            if(inputField.text == "lowerdiffspls")
            {
                PlayerPrefs.SetInt("l_diffs", 1);
                PlayerPrefs.Save();
                inputField.text = "";
                NotificationCenter.SendNotification("Downmapper unlocked!", NotificationType.Success);
                Downmapper.Instance.Activate();
                Delete();
                return;
            }
            else if(inputField.text == "skipalignment")
            {
                PlayerPrefs.SetInt("s_align", 1);
                PlayerPrefs.Save();
                inputField.text = "";
                NotificationCenter.SendNotification("Alignment skipping unlocked!", NotificationType.Success);
                Delete();
                return;
            }
            MiniTimeline.Instance.selectedBookmark.SetText(inputField.text);
            MiniTimeline.Instance.selectedBookmark.SetColor(BookmarkColorPicker.selectedColor, BookmarkColorPicker.selectedUIColor);
            MiniTimeline.Instance.SaveSelectedBookmark();
            MiniTimeline.Instance.selectedBookmark.Deselect();
            MiniTimeline.Instance.OpenBookmarksMenu();
        }

        public void Delete()
        {
            MiniTimeline.Instance.DeleteBookmark();
        }

        public void Scale()
        {
            foreach (Bookmark b in MiniTimeline.Instance.bookmarks) b.Scale();
        }

        public void SetColor(BookmarkUIColor uiColor)
        {
            switch (uiColor)
            {
                case BookmarkUIColor.Blue:
                    BookmarkColorPicker.Instance.SetColorBlue();
                    break;
                case BookmarkUIColor.Green:
                    BookmarkColorPicker.Instance.SetColorGreen();
                    break;
                case BookmarkUIColor.Icy:
                    BookmarkColorPicker.Instance.SetColorIcy();
                    break;
                case BookmarkUIColor.Purple:
                    BookmarkColorPicker.Instance.SetColorPurple();
                    break;
                case BookmarkUIColor.Red:
                    BookmarkColorPicker.Instance.SetColorRed();
                    break;
                case BookmarkUIColor.Yellow:
                    BookmarkColorPicker.Instance.SetColorYellow();
                    break;
            }
        }

        protected override void OnEscPressed(InputAction.CallbackContext context)
        {
            Activate(false);
        }
    }

}
