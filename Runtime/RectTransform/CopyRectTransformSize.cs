namespace Funbites.UnityUtils.RectTransform
{
    using SerializeField = UnityEngine.SerializeField;
    using RectTransform = UnityEngine.RectTransform;
    using Vector2 = UnityEngine.Vector2;

    [UnityEngine.RequireComponent(typeof(RectTransform))]
    [UnityEngine.DisallowMultipleComponent]
    public class CopyRectTransformSize : UnityEngine.MonoBehaviour
    {
        [SerializeField, Sirenix.OdinInspector.Required]
        private RectTransform m_targetTransform = null;

        [SerializeField, Sirenix.OdinInspector.ToggleLeft]
        private bool m_copyHeight = true;

        [SerializeField, Sirenix.OdinInspector.ToggleLeft]
        private bool m_copyWidth = true;

        [SerializeField, Sirenix.OdinInspector.ShowIf("m_copyHeight")]
        private float m_heightOffset = 0;

        [SerializeField, Sirenix.OdinInspector.ShowIf("m_copyWidth")]
        private float m_widthOffset = 0;

        private RectTransform myTransform;

        private void Awake()
        {
            myTransform = GetComponent<RectTransform>();
        }

        private void LateUpdate()
        {
            myTransform.sizeDelta = new Vector2
            {
                x = m_copyWidth ? m_targetTransform.sizeDelta.x + m_widthOffset : myTransform.sizeDelta.x,
                y = m_copyHeight ? m_targetTransform.sizeDelta.y + m_heightOffset : myTransform.sizeDelta.y
            };
        }
    }
}