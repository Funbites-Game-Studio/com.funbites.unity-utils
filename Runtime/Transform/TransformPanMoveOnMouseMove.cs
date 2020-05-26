namespace Funbites.UnityUtils.TransformComponent {
    using Input = UnityEngine.Input;
    public class TransformPanMoveOnMouseMove : UnityEngine.MonoBehaviour {

        public float MouseSensitivity = 1f;

        private UnityEngine.Vector3 lastPosition;

        void Update() {
            if (Input.GetMouseButtonDown(0)) {
                lastPosition = UnityEngine.Input.mousePosition;
            }
            if (Input.GetMouseButton(0)) {
                UnityEngine.Vector3 delta = Input.mousePosition - lastPosition;
                transform.Translate(-delta.x * MouseSensitivity, delta.y * MouseSensitivity, 0);
                lastPosition = Input.mousePosition;
            }
        }
    }
}