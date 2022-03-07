using NotReaper.Keybinds;
using NotReaper.Overlays;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NotReaper.Keybinds.RebindManager;

namespace NotReaper.MenuBrowser
{
    public static class MenuRegistration
    {
        public static Dictionary<string, NRMenu> menuEntries { get; private set; } = new();
        public static Dictionary<string, NROverlay> overlayEntries { get; private set; } = new();
        public static List<KeybindDisplayData> keybindEntries { get; private set; } = new();

        public static void RegisterKeybind(KeybindDisplayData data)
        {
            keybindEntries.Add(data);
        }

        public static void RegisterMenu(string name, NRMenu menu)
        {
            menuEntries.Add(name, menu);
        }
        public static void RegisterOverlay(string name, NROverlay overlay)
        {
            overlayEntries.Add(name, overlay);
        }
    }
}
