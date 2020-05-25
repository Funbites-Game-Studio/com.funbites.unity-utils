using System;
using UnityEngine;
using UnityEngine.Events;

namespace Funbites.UnityUtils.Events
{
    [Serializable]
    public class ColliderEvent : UnityEvent<Collider> {
    }
}