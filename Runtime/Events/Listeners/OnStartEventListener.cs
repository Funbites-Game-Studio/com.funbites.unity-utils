namespace Funbites.UnityUtils.Events
{
    public class OnStartEventListener : UnityEngine.MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private UnityEngine.Events.UnityEvent m_onStartEvent = null;

        private void Start() {
            m_onStartEvent.Invoke();
        }
    }
}