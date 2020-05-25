using UnityEngine;

namespace ScriptUtils
{
    public class CopyPosition : MonoBehaviour
    {
        public Transform transformToCopy;

        [SerializeField]
        private bool m_resetTranformOnDisable = true;

        private void OnDisable()
        {
            if (m_resetTranformOnDisable)
                transformToCopy = null;
        }

        private void LateUpdate()
        {
            if (transformToCopy != null)
                transform.position = transformToCopy.position;
        }
    }

}