namespace Funbites.UnityUtils.Events
{
    public class SetTransformPositionHandler : UnityEngine.MonoBehaviour {
        [UnityEngine.SerializeField, Sirenix.OdinInspector.Required]
        private UnityEngine.Transform m_transform = null;

        [UnityEngine.SerializeField]
        private UnityEngine.Vector3 m_targetPosition = default;

        public void SetPosition()
        {
            m_transform.position = m_targetPosition;
        }
    }
}