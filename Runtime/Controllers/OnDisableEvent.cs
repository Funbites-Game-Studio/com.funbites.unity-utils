namespace Funbites.UnityUtils.Events
{
    public class OnDisableEvent : UnityEngine.MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private UnityEngine.Events.UnityEvent m_onDisable = null;

        private void OnDisable()
        {
            m_onDisable.Invoke();
        }
    } 
}