namespace Funbites.UnityUtils.Events
{
    public class OnDisableEventListener : UnityEngine.MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private UnityEngine.Events.UnityEvent m_onDisable = null;

        private void OnDisable()
        {
            m_onDisable.Invoke();
        }
    } 
}