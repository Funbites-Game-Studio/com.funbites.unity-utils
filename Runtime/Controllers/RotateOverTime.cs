using UnityEngine;

namespace ScriptUtils
{
    public class RotateOverTime : MonoBehaviour
    {
        [SerializeField]
        private float m_angularSpeed;

        private float currentAngle;
        private int randomDirection;

        private void OnEnable()
        {
            currentAngle = 0;
            randomDirection = UnityEngine.Random.value > 0.5f ? -1 : 1;
        }

        private void Update()
        {
            currentAngle += (randomDirection * m_angularSpeed * Time.deltaTime);
            transform.Rotate(Vector3.forward, currentAngle);
        }
    }
}