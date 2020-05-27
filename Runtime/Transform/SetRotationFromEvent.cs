namespace ScriptUtils.Events {
    using UnityEngine;
    //TODO: Rename this to SetRotationFromList and add lerp functionality
    public class SetRotationFromEvent : MonoBehaviour {
        [SerializeField]
        private Quaternion[] m_rotations = null;

        public void SetRotation(int index) {
            transform.rotation = m_rotations[index];
        }
    }
}