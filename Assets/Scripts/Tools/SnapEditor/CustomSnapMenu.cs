/*File made by MeepsKitten*/

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NotReaper.Tools.CustomSnapMenu {
    public class CustomSnapMenu : MonoBehaviour {
        public TMP_InputField inputField;
        public Button resetButton;
        private bool confirmationOfDestructiveActionRequired = true;
        public Button confirmButton;
        public GameObject window;

        public Michsky.UI.ModernUIPack.HorizontalSelector HorizontalSnapSelector;

        public Color ErrorColor = new Color (255, 10, 10, 0.59f);
        public Color NormalColor;

        enum SnapEditorMode {
            addMode,
            subtractMode,
            invalid
        }

        private SnapEditorMode mode = SnapEditorMode.invalid;

        void Start () {
            Vector3 defaultPos;
            defaultPos.x = 0;
            defaultPos.y = 0;
            defaultPos.z = -10.0f;
            window.GetComponent<RectTransform> ().localPosition = defaultPos;
            window.GetComponent<CanvasGroup> ().alpha = 0.0f;
            window.SetActive (false);
            ResetColor ();
            NRSettings.OnLoad (loadSavedSnaps);
        }
        private void loadSavedSnaps () {
            HorizontalSnapSelector.elements = NRSettings.config.snaps;
        }
        public void OnSnapSet () {
            int snap = 0;
            bool success = int.TryParse (inputField.text, out snap);
            if (success) {
                Timeline.instance.SetSnap (snap);
                AdjustSnapArray (snap);
            } else {
                ColorBlock colors = inputField.colors;
                colors.normalColor = ErrorColor;
                inputField.colors = colors;
            }
        }

        public void OnSnapClicked () {
            if (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl)) {
                OpenWindow ();
            }
        }

        public void OpenWindow () {
            window.GetComponent<CanvasGroup> ().DOFade (1.0f, 0.3f);
            HorizontalSnapSelector.elements = NRSettings.config.snaps;
            window.SetActive (true);
        }

        public void CloseWindow () {
            window.GetComponent<CanvasGroup> ().DOFade (0.0f, 0.3f);
            inputField.GetComponent<TMP_InputField> ().ReleaseSelection ();
            ResetColor ();
            window.SetActive (false);
        }

        public void OnSnapInputFieldChanged () {
            ResetColor ();

            int snap = 0;
            bool success = int.TryParse (inputField.text, out snap);
            mode = SnapEditorMode.invalid;
            if (success) {
                foreach (string element in HorizontalSnapSelector.elements) {
                    if (element == "1/" + snap) {
                        mode = SnapEditorMode.subtractMode;
                    }
                }

                if ((snap >= 1) && (snap <= 100) && (mode == SnapEditorMode.invalid)) {
                    mode = SnapEditorMode.addMode;
                }
            }

            SetConfirmButtonInfo ();
        }

        public void OnSnapInputFieldEntered () {
            ResetColor ();
        }

        public void ResetColor () {
            ColorBlock colors = inputField.colors;
            colors.normalColor = NormalColor;
            inputField.colors = colors;
        }

        public void SetConfirmButtonInfo () {
            if (mode == SnapEditorMode.addMode) {
                confirmButton.interactable = true;
                ColorBlock colors = confirmButton.colors;
                colors.normalColor = Color.white;
                confirmButton.colors = colors;
                confirmButton.GetComponentInChildren<TextMeshProUGUI> ().text = "Add Snap Preset";
            } else if (mode == SnapEditorMode.subtractMode) {
                confirmButton.interactable = true;
                ColorBlock colors = confirmButton.colors;
                colors.normalColor = ErrorColor;
                confirmButton.colors = colors;
                confirmButton.GetComponentInChildren<TextMeshProUGUI> ().text = "Remove Snap Preset";
            } else {
                confirmButton.interactable = false;
            }
        }

        private void AdjustSnapArray (int snap) {

            if (mode == SnapEditorMode.addMode) {
                HorizontalSnapSelector.elements.Add ("1/" + snap);
                HorizontalSnapSelector.elements.Sort (delegate (string l, string r) {
                    return l.Substring (2).PadLeft (3, '0').CompareTo (r.Substring (2).PadLeft (3, '0'));
                });

            } else if (mode == SnapEditorMode.subtractMode) {
                int indexseek = 0;
                int desiredIndex = -1;
                foreach (string element in HorizontalSnapSelector.elements) {
                    if (element == ("1/" + snap)) {
                        desiredIndex = indexseek;
                        break;
                    }
                    ++indexseek;
                }

                if (desiredIndex != -1)
                {
                    HorizontalSnapSelector.elements.RemoveAt (desiredIndex);
                    OnSnapInputFieldChanged();
                }
              
            }

            NRSettings.config.snaps = HorizontalSnapSelector.elements;
            NRSettings.SaveSettingsJson ();
        }

        public List<string> deafultSnaps = new List<string>(){
            "1/1",
            "1/2",
            "1/3",
            "1/4",
            "1/6",
            "1/8",
            "1/12",
            "1/16",
            "1/24",
            "1/32",
            "1/48",
            "1/64"
        };

        public void OnResetButton () {
            if(confirmationOfDestructiveActionRequired)
            {
                ColorBlock colors = resetButton.colors;
                colors.normalColor = ErrorColor;
                resetButton.colors = colors;
                resetButton.GetComponentInChildren<TextMeshProUGUI> ().text = "Click again to confirm\n(there is no way to undo this)";
                confirmationOfDestructiveActionRequired = false;
            }
            else
            {
                NRSettings.config.snaps = deafultSnaps;
                HorizontalSnapSelector.elements = deafultSnaps;
                NRSettings.SaveSettingsJson ();
                confirmationOfDestructiveActionRequired = true;


                ColorBlock colors = resetButton.colors;
                colors.normalColor = Color.white;
                resetButton.colors = colors;
                resetButton.GetComponentInChildren<TextMeshProUGUI> ().text = "Reset snap presets";
                CloseWindow();
            }
        }

    }

}