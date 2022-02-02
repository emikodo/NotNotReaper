using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.MapBrowser.UI
{
    /// <summary>
    /// Represents a Panel. Should be implemented as base class.
    /// </summary>
    public class Panel : MonoBehaviour
    {
        /// <summary>
        /// Shows the panel.
        /// </summary>
        /// <param name="show">True if panel should be shown.</param>
        public void Show(bool show)
        {
            gameObject.SetActive(show);
        }
    }
}

