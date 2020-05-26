namespace Funbites.UnityUtils.Events
{
    using Vector3 = UnityEngine.Vector3;
    [UnityEngine.RequireComponent(typeof(UnityEngine.Transform))]
    public class SetTransformScaleHandler : UnityEngine.MonoBehaviour {
        
        private UnityEngine.Transform selfTransform = null;

        private void Awake() {
            selfTransform = GetComponent<UnityEngine.Transform>();
        }

        public void SetScaleX(float x)
        {
            selfTransform.localScale = new Vector3(x, selfTransform.localScale.y, transform.localScale.z);
        }

        public void SetScaleY(float y)
        {
            selfTransform.localScale = new Vector3(selfTransform.localScale.x, y, transform.localScale.z);
        }

        public void SetScaleZ(float z)
        {
            selfTransform.localScale = new Vector3(selfTransform.localScale.x, selfTransform.localScale.y, z);
        }
    }
}