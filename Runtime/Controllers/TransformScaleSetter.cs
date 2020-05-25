using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptUtils
{
    public class TransformScaleSetter : MonoBehaviour
    {
        [SerializeField, Required]
        private Transform m_transform;

        public void SetScaleX(float x)
        {
            m_transform.localScale = new Vector3(x, m_transform.localScale.y, transform.localScale.z);
        }

        public void SetScaleY(float y)
        {
            m_transform.localScale = new Vector3(m_transform.localScale.x, y, transform.localScale.z);
        }

        public void SetScaleZ(float z)
        {
            m_transform.localScale = new Vector3(m_transform.localScale.x, m_transform.localScale.y, z);
        }
    }
}