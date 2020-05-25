using UnityEngine;
using UnityEngine.Events;

namespace ScriptUtils
{
    public class OnDisableEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent m_onDisable;

        private void OnDisable()
        {
            m_onDisable.Invoke();
        }
    } 
}