namespace Funbites.UnityUtils
{
    using UnityEngine;
    public static class Vector3Utils
    {
        public static Vector3 GameSpaceAngleToVector(float angle, int direction)
        {
            return new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle) * direction,
          -Mathf.Cos(Mathf.Deg2Rad * angle), 0);
        }

        public static Vector3 FindNearestPointOnLine(Vector3 origin, Vector3 direction, Vector3 point)
        {
            direction.Normalize();
            Vector3 lhs = point - origin;

            float dotP = Vector3.Dot(lhs, direction);
            return origin + direction * dotP;
        }

        public static Vector3 FindNearestPointOnFiniteLine(Vector3 origin, Vector3 end, Vector3 point)
        {
            //Get heading
            Vector3 heading = (end - origin);
            float magnitudeMax = heading.magnitude;
            heading.Normalize();

            //Do projection from the point but clamp it
            Vector3 lhs = point - origin;
            float dotP = Vector3.Dot(lhs, heading);
            dotP = Mathf.Clamp(dotP, 0f, magnitudeMax);
            return origin + heading * dotP;
        }
    } 
}