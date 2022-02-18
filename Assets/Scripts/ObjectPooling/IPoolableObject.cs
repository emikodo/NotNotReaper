using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.ObjectPooling
{
    /// <summary>
    /// Represents an object that can be pooled with <see cref="ObjectPool{T}"/>
    /// </summary>
    public interface IPoolableObject
    {
        /// <summary>
        /// Gets called when the object gets pooled.
        /// </summary>
        void OnInstantiated();
    }
}
