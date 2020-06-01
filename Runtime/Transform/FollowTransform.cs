namespace Funbites.UnityUtils.TransformComponent {
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class FollowTransform : MonoBehaviour {
        [Required]
        public Transform Target;
        
        public bool FollowPosition = true;
        [ShowIf("FollowPosition")]
        private bool m_useInitialDiffAsPositionOffset = false;
        [ShowIf("FollowPosition")]
        public Vector3 PositionOffset;

        public bool FollowRotation = false;
        [ShowIf("FollowRotation")]
        private bool m_useInitialDiffAsRotationOffset = false;
        [ShowIf("FollowRotation")]
        public Quaternion RotationOffset;

        public bool FollowScale = true;
        [ShowIf("FollowScale")]
        private bool m_useInitialDiffAsScaleOffset = false;
        [ShowIf("FollowScale")]
        public Vector3 ScaleOffset;

        
        
        void Start() {
            if (m_useInitialDiffAsPositionOffset) PositionOffset = transform.position - Target.position;
            if (m_useInitialDiffAsRotationOffset) RotationOffset = Quaternion.Inverse(transform.rotation) * Target.rotation;
            if (m_useInitialDiffAsScaleOffset) ScaleOffset = transform.localScale - Target.localScale;
        }

        void Update() {
            if (FollowPosition)
                transform.position = Target.position + PositionOffset;
            if (FollowRotation)
                transform.rotation = Target.rotation * RotationOffset;
            if (FollowScale)
                transform.localScale = Target.localScale + ScaleOffset;
        }
    }
}