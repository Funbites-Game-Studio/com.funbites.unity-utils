namespace Funbites.UnityUtils.Shapes {
    using UnityEngine;

    [System.Serializable]
    public class Arc {
        [SerializeField]
        private float m_fromDegree = 0;
        [SerializeField]
        private float m_toDegree = 180;
        [SerializeField]
        private float m_radius = 2;
        [SerializeField]
        private Vector2 m_centerOffset = Vector2.zero;

        public Vector2 CenterOffset
        {
            get { return m_centerOffset; }
        }
        public float AngleDiff
        {
            get
            {
                return m_toDegree - m_fromDegree;
            }
        }

        private Vector3 CenterOffset3
        {
            get { return new Vector3(m_centerOffset.x, 0, m_centerOffset.y); }
        }

        public bool Contains(Vector3 targetPosition, Transform arcSourceTransform) {
            Vector3 diff = targetPosition - (arcSourceTransform.position + CenterOffset3);
            //Debug.Log ("Source: "+arcSourceTransform.position+" target: "+targetObject);
            //Debug.Log ("Diff: "+diff+" forward: "+arcSourceTransform.forward);
            if (diff.magnitude > m_radius)
                return false;
            diff.Normalize();
            //diff = Vector3.Cross (diff, arcSourceTransform.up);
            //Debug.LogWarning ("B: "+diff+ " "+arcSourceTransform.right);
            float angle = Vector3.Angle(arcSourceTransform.forward, diff);//Mathf.Rad2Deg*Mathf.Atan2 (diff.z, diff.x)-90;
            float side = Vector3.Dot(arcSourceTransform.right, diff);
            angle = (side <= 0) ? angle + 90 : 90 - angle;
            angle %= 360;
            if (angle < 0) {
                angle += 360;
            }
            //Debug.Log("angle: "+angle+" side:"+side);
            return (angle >= m_fromDegree && angle <= m_toDegree);
        }

#if UNITY_EDITOR
        public void DrawInteractionArc(Transform objInteraction) {
            UnityEditor.Handles.color = new Color(1, 1, 1, 0.2f);
            Vector3 fromAngle = Quaternion.AngleAxis(-m_fromDegree, objInteraction.up) * objInteraction.right;
            Vector3 toAngle = Quaternion.AngleAxis(-AngleDiff, objInteraction.up) * fromAngle;
            Vector3 middleAngle = Quaternion.AngleAxis(-(AngleDiff / 2 + m_fromDegree), objInteraction.up) * objInteraction.right;
            Vector3 centerPos = objInteraction.TransformPoint(CenterOffset3);
            //Handles.DrawDottedLine(objInteraction.TransformDirection(new Vector3(
            UnityEditor.Handles.DrawSolidArc(centerPos, objInteraction.up, fromAngle,
                -AngleDiff, m_radius);
            UnityEditor.Handles.color = Color.white;
            m_radius = UnityEditor.Handles.ScaleValueHandle(m_radius,
                centerPos + middleAngle * m_radius,
                Quaternion.FromToRotation(Vector3.forward, middleAngle), 1, UnityEditor.Handles.ConeHandleCap, 1);

            UnityEditor.Handles.color = Color.red;
            m_fromDegree = UnityEditor.Handles.ScaleValueHandle(m_fromDegree,
                centerPos + fromAngle * m_radius / 2,
                objInteraction.rotation, 1, UnityEditor.Handles.SphereHandleCap, 1);

            UnityEditor.Handles.color = Color.blue;
            m_toDegree = UnityEditor.Handles.ScaleValueHandle(m_toDegree,
                centerPos + toAngle * m_radius / 2,
                objInteraction.rotation, 1, UnityEditor.Handles.SphereHandleCap, 1);
        }
#endif
    }
}
