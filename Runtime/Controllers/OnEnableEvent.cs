using UnityEngine;
using UnityEngine.Events;

namespace ScriptUtils
{
    public class OnEnableEvent : MonoBehaviour
    {
        public UnityEvent OnEnabled;

        private void OnEnable()
        {
            OnEnabled.Invoke();
        }
    } 
}