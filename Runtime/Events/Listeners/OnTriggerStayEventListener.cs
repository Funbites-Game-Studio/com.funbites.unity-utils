﻿namespace Funbites.UnityUtils.Events
{
    using SerializeField = UnityEngine.SerializeField;
    public class OnTriggerStayEventListener : UnityEngine.MonoBehaviour
    {
        
        [SerializeField]
        private ColliderEvent m_onTriggerStay = null;
        [Sirenix.OdinInspector.ShowInInspector]
        public bool IsActive { get; set; } = true;
        [SerializeField]
        private float m_intervalInSeconds = 1;
        [SerializeField, Sirenix.OdinInspector.ToggleLeft]
        private bool m_triggerOnceInFrame = true;
        [SerializeField, Sirenix.OdinInspector.ValueDropdown("@Funbites.UnityUtils.Editor.OdinUtils.GetTags()")]
        private string m_tag = Constants.UntaggedTag;
        [SerializeField]
        private UnityEngine.LayerMask layerMask = -1;

        private float elapsedTime;
        private bool alreadyTriggered;

        private void Awake() {
            IsActive = true;
        }

        private void OnTriggerStay(UnityEngine.Collider other)
        {
            if (!IsActive) return;
            if (ValidateCollider(other)) {
                elapsedTime += UnityEngine.Time.deltaTime;

                var canTrigger = m_triggerOnceInFrame ? !alreadyTriggered : true;

                if (canTrigger)
                    if (elapsedTime >= m_intervalInSeconds) {
                        elapsedTime = 0;
                        alreadyTriggered = true;
                        m_onTriggerStay.Invoke(other);
                    }
            }
        }
        
        private bool ValidateCollider(UnityEngine.Collider other) {
            return LayerMaskExtensions.HasLayer(layerMask, other.gameObject.layer) &&
                (string.IsNullOrEmpty(m_tag) || m_tag.GetHashCode() == Constants.UntaggedHash || other.CompareTag(m_tag));
        }

        private void OnTriggerEnter(UnityEngine.Collider other)
        {
            if (ValidateCollider(other) && IsActive) {
                var canTrigger = m_triggerOnceInFrame ? !alreadyTriggered : true;

                if (canTrigger)
                    elapsedTime = 0;
            }
        }

        private void LateUpdate()
        {
            alreadyTriggered = false;
        }
    }
}