using DG.Tweening;
using NotReaper.Keybinds;
using NotReaper.Models;
using NotReaper.Overlays;
using NotReaper.UI.Components;
using NotReaper.UserInput;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static NotReaper.Keybinds.RebindManager;

namespace NotReaper.MenuBrowser
{
    public class MenuPickerUI : NRMenu
    {
        [Header("References")]
        [SerializeField] private TMP_InputField searchInput;
        [SerializeField] private NRButton menuEntryPrefab;
        [SerializeField] private KeybindEntry keybindEntryPrefab;
        [SerializeField] private Canvas canvas;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private CanvasScaler scaler;
        [Space, Header("Parents")]
        [SerializeField] private GameObject menuParent;
        [SerializeField] private GameObject keybindParent;

        private Dictionary<string, GameObject> menuEntries = new();
        private Dictionary<string, List<KeybindEntry>> keybindEntries = new();

        private View activeView = View.Menu;

        [NRInject] private InputIcons icons;
        public static MenuPickerUI Instance { get; private set; } = null;
        protected override void Awake()
        {
            if (Instance != null)
            {
                Debug.Log("MenuBrowser already exists.");
                return;
            }
            Instance = this;
            base.Awake();
        }

        private void Start()
        {
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Shrink;
            menuParent.SetActive(true);
            keybindParent.SetActive(false);
            gameObject.SetActive(false);
            Timeline.onAudicaLoaded += OnAudicaLoaded;
        }

        private void OnAudicaLoaded(AudicaFile _)
        {
            foreach(var entry in MenuRegistration.menuEntries)
            {
                CreateMenuEntry(entry.Key, entry.Value);
            }
            foreach(var entry in MenuRegistration.overlayEntries)
            {
                CreateOverlayEntry(entry.Key, entry.Value);
            }
            foreach(var entry in MenuRegistration.keybindEntries)
            {
                CreateKeybindEntry(entry);
            }
        }

        private void CreateKeybindEntry(KeybindDisplayData data)
        {
            var keybind = Instantiate(keybindEntryPrefab, keybindParent.transform);
            keybind.Initialize(icons, null, data.displayName, "", false, null, Models.TargetHandType.Either, null, null);
            keybind.SetKeybind(new(data.keybind));
            if (!string.IsNullOrEmpty(data.modifier1)) keybind.SetFirstModifier(new(data.modifier1));
            if (!string.IsNullOrEmpty(data.modifier2)) keybind.SetSecondModifier(new(data.modifier2));
            if (keybindEntries.ContainsKey(data.displayName))
            {
                keybindEntries[data.displayName].Add(keybind);
            }
            else
            {
                keybindEntries.Add(data.displayName, new List<KeybindEntry>() { keybind });
            }
        }

        private void CreateMenuEntry(string name, NRMenu menu)
        {
            if (name.ToLower().Contains("downmap"))
            {
                if (!PlayerPrefs.HasKey("l_diffs"))
                {
                    return;
                }

                if (PlayerPrefs.GetInt("l_diffs") != 1)
                {
                    return;
                }
            }
            var go = Instantiate(menuEntryPrefab, menuParent.transform);
            go.SetText(name);
            UnityAction listener = new UnityAction(() =>
            {
                Hide();
                menu.Show();
            });
            go.onClick.AddListener(listener);
            menuEntries.Add(name, go.gameObject);
        }
        private void CreateOverlayEntry(string name, NROverlay overlay)
        {
            var go = Instantiate(menuEntryPrefab, menuParent.transform);
            go.SetText(name);
            UnityAction listener = new UnityAction(() =>
            {
                Hide();
                overlay.Show();
            });
            go.onClick.AddListener(listener);
            menuEntries.Add(name, go.gameObject);
        }


        public void OnMenusClicked()
        {
            ChangeView(true);
        }

        public void OnKeybindsClicked()
        {
            ChangeView(false);
        }

        private void ChangeView(bool menuView)
        {
            searchInput.SetTextWithoutNotify("");
            menuParent.SetActive(menuView);
            keybindParent.SetActive(!menuView);
            activeView = menuView ? View.Menu : View.Keybind;
            SetEntriesActive("");
        }

        private void SetEntriesActive(string search)
        {
            if(activeView == View.Menu)
            {
                foreach(var entry in menuEntries)
                {

                    entry.Value.gameObject.SetActive(entry.Key.ToLower().Contains(search.ToLower()));
                }
            }
            else
            {
                foreach(var entry in keybindEntries)
                {
                    foreach(var keybind in entry.Value)
                    {
                        keybind.gameObject.SetActive(entry.Key.ToLower().Contains(search.ToLower()));
                    }
                }
            }
        }

        public void OnSearchChanged()
        {
            SetEntriesActive(searchInput.text);
        }

        public override void Show()
        {
            OnActivated();
            canvasGroup.DOFade(1f, .3f);
        }

        public override void Hide()
        {
            canvasGroup.DOFade(0f, .3f).OnComplete(() =>
            {
                OnDeactivated();
            });
        }

        protected override void OnEscPressed(InputAction.CallbackContext context)
        {
            Hide();
        }

        private enum View
        {
            Menu,
            Keybind
        }
    }
}

