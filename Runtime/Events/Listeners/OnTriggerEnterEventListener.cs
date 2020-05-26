namespace Funbites.UnityUtils.Events
{
    using SerializeField = UnityEngine.SerializeField;
    public class OnTriggerEnterEventListener : UnityEngine.MonoBehaviour
    {
        [SerializeField]
        private ColliderEvent on_TriggerEnter = null;
        [SerializeField, Sirenix.OdinInspector.ValueDropdown("@Funbites.UnityUtils.Editor.OdinUtils.GetTags()")]
        private string m_tag = Constants.UntaggedTag;
        [SerializeField]
        private bool m_triggerOnceInFrame = true;
        [SerializeField]
        private bool m_triggerOnceInLifeTime = false;

        private bool hasTriggered = false;
        private bool alreadyTriggeredInFrame = false;

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