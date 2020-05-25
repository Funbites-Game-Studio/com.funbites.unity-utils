using UnityEngine;
namespace Funbites.UnityUtils.Events
{
    public class OnStartEventListener : MonoBehaviour
    {
        [SerializeField]
        private UnityEngine.Events.UnityEvent m_onStartEvent;

        private void Start() {
            m_onStartEvent.Invoke();
        }
    }
}