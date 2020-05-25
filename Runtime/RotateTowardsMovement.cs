using UnityEngine;

namespace ScriptUtils
{
    [DisallowMultipleComponent]
    public class RotateTowardsMovement : MonoBehaviour
    {
        [SerializeField]
        private float _angleOffset;

        private Rigidbody myRigidbody;

        private void Awake()
        {
            myRigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Rotate(myRigidbody.velocity.normalized);
        }

        private void Rotate(Vector2 moveDirection)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + _angleOffset, Vector3.forward);
        }
    }
}