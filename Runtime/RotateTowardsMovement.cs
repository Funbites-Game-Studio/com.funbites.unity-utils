namespace Funbites.UnityUtils.Physics
{
    [UnityEngine.DisallowMultipleComponent]
    [UnityEngine.RequireComponent(typeof(UnityEngine.Rigidbody))]
    public class RotateTowardsMovement : UnityEngine.MonoBehaviour {
        [UnityEngine.SerializeField]
        private float _angleOffset = 0;

        private UnityEngine.Rigidbody myRigidbody;

        private void Awake()
        {
            myRigidbody = GetComponent<UnityEngine.Rigidbody>();
        }

        private void FixedUpdate()
        {
            Rotate(myRigidbody.velocity.normalized);
        }

        private void Rotate(UnityEngine.Vector2 moveDirection)
        {
            float angle = UnityEngine.Mathf.Atan2(moveDirection.y, moveDirection.x) * UnityEngine.Mathf.Rad2Deg;
            transform.rotation = UnityEngine.Quaternion.AngleAxis(angle + _angleOffset, UnityEngine.Vector3.forward);
        }
    }
}