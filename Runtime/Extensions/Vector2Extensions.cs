namespace Funbites.UnityUtils
{
    using Vector2 = UnityEngine.Vector2;
    using Mathf = UnityEngine.Mathf;
    public static class Vector2Extensions {

        public static float RangeInverseLerp(this Vector2 vector2AsRange, float value) {
            return Mathf.InverseLerp(vector2AsRange.x, vector2AsRange.y, value);
        }

        public static float RangeLerp(this Vector2 vector2AsRange, float value) {
            return Mathf.Lerp(vector2AsRange.x, vector2AsRange.y, value);
        }

        public static float RangeRandomValue(this Vector2 vector2AsRange) {
            return UnityEngine.Random.Range(vector2AsRange.x, vector2AsRange.y);
        }

    }
}