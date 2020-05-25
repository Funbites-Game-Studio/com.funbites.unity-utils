namespace Funbites.UnityUtils.Events
{
    public class OnAwakeEventListener : UnityEngine.MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private UnityEngine.Events.UnityEvent m_onAwakeEvent;

        private void Awake() {
            m_onAwakeEvent.Invoke();
        }
    }
}