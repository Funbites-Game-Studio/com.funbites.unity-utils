using UnityEngine;
namespace ScriptUtils.Range {
    public static class Vector2AsRange {

        public static float RangeInverseLerp(this Vector2 vector2AsRange, float value) {
            return Mathf.InverseLerp(vector2AsRange.x, vector2AsRange.y, value);
        }

        public static float RangeLerp(this Vector2 vector2AsRange, float value) {
            return Mathf.Lerp(vector2AsRange.x, vector2AsRange.y, value);
        }

        public static float RangeRandomValue(this Vector2 vector2AsRange) {
            return Random.Range(vector2AsRange.x, vector2AsRange.y);
        }

    }
}