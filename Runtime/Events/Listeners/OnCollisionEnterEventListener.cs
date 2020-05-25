namespace Funbites.UnityUtils.Events
{
    public class OnCollisionEnterEventListener : UnityEngine.MonoBehaviour {
        [UnityEngine.SerializeField]
        private CollisionEvent m_onCollisionEnter;
        //TODO: Fix this
        [UnityEngine.SerializeField]
        private string m_tag = Constants.UntaggedTag;

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if (string.IsNullOrEmpty(m_tag) || collision.gameObject.CompareTag(m_tag)) {
                m_onCollisionEnter.Invoke(collision);
            }
        }
    }
}