using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NotReaper.MapBrowser.UI
{
    /// <summary>
    /// Responsible for the Downloading Overlay.
    /// </summary>
    public class DownloadOverlay : MonoBehaviour
    {
        #region References
        [Header("Overlays")]
        [SerializeField] private GameObject downloadingOverlay;
        [SerializeField] private GameObject downloadDoneOverlay;
        [Space, Header("Buttons")]
        [SerializeField] private GameObject retryButton;
        [SerializeField] private GameObject cancelButton;
        [Space, Header("Text")]
        [SerializeField] private TextMeshProUGUI downloadProgressText;
        [SerializeField] private TextMeshProUGUI failedMapsText;
        #endregion

        #region Hide and Show
        /// <summary>
        /// Shows the Downloading overlay.
        /// </summary>
        /// <param name="show">True if it should be shown.</param>
        public void ShowDownloadingOverlay(bool show)
        {
            downloadingOverlay.SetActive(show);
            cancelButton.SetActive(show);
        }
        /// <summary>
        /// Shows the Download Done overlay.
        /// </summary>
        /// <param name="show">True if it should be shown.</param>
        public void ShowDownloadDoneOverlay(bool show)
        {
            downloadDoneOverlay.SetActive(show);
        }
        /// <summary>
        /// Shows the cancel button.
        /// </summary>
        /// <param name="show">True if it should be shown.</param>
        public void ShowCancelButton(bool show)
        {
            cancelButton.SetActive(show);
        }
        /// <summary>
        /// Hides both the Downloading and Downloading Done overlays.
        /// </summary>
        public void HideOverlays()
        {
            downloadingOverlay.SetActive(false);
            downloadDoneOverlay.SetActive(false);
            retryButton.SetActive(false);
            downloadProgressText.text = "";
        }
        #endregion region

        #region Text Handling
        /// <summary>
        /// Sets the text for the progrogress text field.
        /// </summary>
        /// <param name="text">The text to set it to.</param>
        public void SetProgressText(string text)
        {
            downloadProgressText.text = text;
        }
        /// <summary>
        /// Sets the amount of failed maps.
        /// </summary>
        /// <param name="count">The amount of failed maps.</param>
        public void SetFailedMapsCount(int count)
        {
            failedMapsText.text = $"{count} maps failed to download.\nwould you like to retry?";
            retryButton.SetActive(true);
        }
        #endregion
    }
}

