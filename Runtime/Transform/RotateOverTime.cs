namespace Funbites.UnityUtils.TransformComponent
{
    public class RotateOverTime : UnityEngine.MonoBehaviour {
        [UnityEngine.SerializeField]
        private float m_angularSpeed = 10;

        private float currentAngle;
        private int randomDirection;

        private void OnEnable()
        {
            currentAngle = 0;
            randomDirection = UnityEngine.Random.value > 0.5f ? -1 : 1;
        }

        private void Update()
        {
            currentAngle += (randomDirection * m_angularSpeed * UnityEngine.Time.deltaTime);
            transform.Rotate(UnityEngine.Vector3.forward, currentAngle);
        }
    }
}