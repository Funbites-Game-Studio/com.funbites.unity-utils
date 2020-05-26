namespace Funbites.UnityUtils.Events
{
    public class OnEnableEventListener : UnityEngine.MonoBehaviour {
        [UnityEngine.SerializeField]
        private UnityEngine.Events.UnityEvent m_onEnabled = null;

        private void OnEnable()
        {
            m_onEnabled.Invoke();
        }
    } 
}