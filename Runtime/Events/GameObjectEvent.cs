using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptUtils.Events {
    [Serializable]
    public class GameObjectEvent : UnityEvent<GameObject> {
    }
}