namespace Funbites.UnityUtils {
    public static class FloatExtension {

        public static int Compare(float a, float b) {
            return (int)(a - b);
        }
        public static float AlternatingSequence(int n, float offset, float step, int repeat, bool startPositive)
        {
            float sign = (n % 2 == (startPositive ? 0 : 1) ? 1 : -1);
            return sign * step * UnityEngine.Mathf.Ceil((float)n / repeat) + offset;
        }
    }
}
