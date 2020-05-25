using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptUtils
{
    public class SetTransformPosition : MonoBehaviour
    {
        [SerializeField, Required]
        private Transform m_transform;

        [SerializeField]
        private Vector3 m_targetPosition;

        public void SetPosition()
        {
            m_transform.position = m_targetPosition;
        }
    }
}