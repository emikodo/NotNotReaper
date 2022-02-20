using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;
using NotReaper.UserInput;
using NotReaper.Models;
using UnityEngine.UI;

namespace NotReaper.Keybinds
{
    public class RebindManager : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameObject rebindWindow;
        [SerializeField] private ScrollRect scroller;
        [Space, Header("Rebind References")]
        [SerializeField] private KeybindTitle keybindTitle;
        [SerializeField] private KeybindMap keybindMap;
        [SerializeField] private KeybindEntry keybindPrefab;
        [SerializeField] private Transform content;

        [NRInject] private InputIcons icons;

        private TargetHandType hand = TargetHandType.Left;
        public bool isRebinding = false;

        private void Start()
        {
            PopulateKeybindsMenu();
        }

        private void LoadKeybinds(InputActionAsset asset)
        {
            asset.LoadBindingOverridesFromJson(PlayerPrefs.GetString($"{asset.name}_keybinds", ""));
        }

        private void SaveKeybinds(InputActionAsset asset)
        {            
            var json = asset.SaveBindingOverridesAsJson();
            PlayerPrefs.SetString($"{asset.name}_keybinds", json);
        }

        private void OnRebind(bool isRebinding)
        {
            scroller.enabled = !isRebinding;
            this.isRebinding = isRebinding;
        }

        public void Close()
        {
            rebindWindow.SetActive(false);
        }

        public void Show()
        {
            rebindWindow.SetActive(true);
        }

        private void ResetKeybinds(InputActionMap map)
        {
            map.RemoveAllBindingOverrides();
            SaveKeybinds(map.asset);
        }

        private void ResetKeybinds(InputActionAsset asset)
        {
            asset.RemoveAllBindingOverrides();
            SaveKeybinds(asset);
        }

        private void PopulateKeybindsMenu()
        {
            var sets = KeybindManager.GetRegisteredKeybinds();
            var orderedSet = sets.OrderByDescending(x => x.Value.Priority);
            foreach(var entry in orderedSet)
            {
                LoadKeybinds(entry.Key);
                var title = Instantiate(keybindTitle, content);
                var rebindOptions = entry.Value;
                title.Initialize(rebindOptions.AssetName, hand, entry.Key);
                hand = hand == TargetHandType.Left ? TargetHandType.Right : TargetHandType.Left;
                foreach(var map in entry.Key.actionMaps)
                {
                    KeybindMap mapTitle = null;
                    if(entry.Key.actionMaps.Count > 1)
                    {
                        mapTitle = Instantiate(keybindMap, content);
                        mapTitle.Initialize(rebindOptions.GetMapName(map), hand, map, ResetKeybinds);
                    }
                    List<KeybindEntry> entries = new List<KeybindEntry>();
                    bool hasRebindableKeys = false;
                    foreach(var keybind in map.actions)
                    {
                        if (rebindOptions.IsHidden(keybind))
                        {
                            continue;
                        }

                        KeybindEntry key = Instantiate(keybindPrefab, content);
                        entries.Add(key);
                        bool isRebindable = rebindOptions.IsRebindable(keybind);
                        if (isRebindable) hasRebindableKeys = true;
                        key.Initialize(icons, keybind, rebindOptions.GetKeybindName(keybind), isRebindable, rebindOptions.GetOverrides(), hand, SaveKeybinds, OnRebind);
                        bool hasModifier1 = false;
                        if (keybind.bindings[0].isComposite)
                        {
                            for(int i = 1; i < keybind.bindings.Count; i++)
                            {
                                var bind = keybind.bindings[i];
                                if (!bind.isPartOfComposite) break;
                                if (bind.name.ToLower().Contains("modifier"))
                                {
                                    if (!hasModifier1)
                                    {
                                        hasModifier1 = true;
                                        key.SetFirstModifier(bind);
                                    }
                                    else
                                    {
                                        key.SetSecondModifier(bind);
                                    }
                                }
                                else
                                {
                                    key.SetBindingIndex(i);
                                }
                            }
                        }
                        else
                        {
                            key.SetBindingIndex(0);
                        }
                        
                    }
                    if (hasRebindableKeys)
                    {
                        if (mapTitle == null)
                        {
                            title.SetKeys(entries, ResetKeybinds);
                        }
                        else
                        {
                            mapTitle.SetKeys(entries);
                        }
                    }             
                    hand = hand == TargetHandType.Left ? TargetHandType.Right : TargetHandType.Left;

                }
            }
        }
    } 
}

