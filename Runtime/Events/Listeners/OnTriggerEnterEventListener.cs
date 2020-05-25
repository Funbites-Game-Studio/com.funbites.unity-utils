namespace Funbites.UnityUtils.Events
{
    public class OnTriggerEnterEventListener : UnityEngine.MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private ColliderEvent on_TriggerEnter;
        //TODO: Fix this
        [UnityEngine.SerializeField, Sirenix.OdinInspector.ValueDropdown("Funbites.UnityUtils.Editor.OdinUtils.GetTags")]
        private string m_tag = Constants.UntaggedTag;
        [UnityEngine.SerializeField]
        private bool m_triggerOnceInFrame;
        [UnityEngine.SerializeField]
        private bool m_triggerOnceInLifeTime;

        private bool hasTriggered;
        private bool alreadyTriggeredInFrame;

        private void OnEnable() {
            hasTriggered = false;
            alreadyTriggeredInFrame = false;
        }

        private bool CanTrigger => (!m_triggerOnceInFrame || (m_triggerOnceInFrame && !alreadyTriggeredInFrame)) &&
                    (!m_triggerOnceInLifeTime || (m_triggerOnceInLifeTime && !hasTriggered));

        private void OnTriggerEnter(UnityEngine.Collider other)
        {
            if (string.IsNullOrEmpty(m_tag) || other.CompareTag(m_tag)) {
                if (CanTrigger) {
                    alreadyTriggeredInFrame = true;
                    hasTriggered = true;
                    on_TriggerEnter.Invoke(other);
                } 
            }
        }

        private void LateUpdate()
        {
            alreadyTriggeredInFrame = false;
        }
    }
}