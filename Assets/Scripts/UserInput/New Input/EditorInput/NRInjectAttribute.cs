using NotReaper.Models;
using NotReaper.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NotReaper
{
    /// <summary>
    /// Injects a dependency automatically.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class NRInjectAttribute : Attribute { }

    /// <summary>
    /// Subscribes to OnChanged events in EditorState. Make sure the method has 1 parameter with the corresponding enum.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class NRListenerAttribute : Attribute { }
}

