using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptUtils
{
    [RequireComponent(typeof(RectTransform)), DisallowMultipleComponent]
    public class CopyRectTransformSize : MonoBehaviour
    {
        [SerializeField, Required]
        private RectTransform m_targetTransform;

        [SerializeField, ToggleLeft]
        private bool m_copyHeight = true;

        [SerializeField, ToggleLeft]
        private bool m_copyWidth = true;

        [SerializeField, ShowIf("m_copyHeight")]
        private float m_heightOffset;

        [SerializeField, ShowIf("m_copyWidth")]
        private float m_widthOffset;

        private RectTransform myTransform;

        private void Awake()
        {
            myTransform = GetComponent<RectTransform>();
        }

        private void FixedUpdate()
        {
            var newSize = new Vector2();
            newSize.x = m_copyWidth ? m_targetTransform.sizeDelta.x + m_widthOffset : myTransform.sizeDelta.x;
            newSize.y = m_copyHeight ? m_targetTransform.sizeDelta.y + m_heightOffset : myTransform.sizeDelta.y;

            myTransform.sizeDelta = newSize;
        }
    }
}