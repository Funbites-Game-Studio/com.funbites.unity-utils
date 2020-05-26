namespace Funbites.UnityUtils {
    using UnityEngine;
    public static class MultipleLerp  {
        public static T Evaluate<T>(float t, System.Func<T, T, float, T> lerpFunction, ValueWithLerp<T>[] values) {
            if (values.Length < 2) throw new System.ArgumentException("You must have at least 2 values, that will result in simple lerp");
            int referenceIndex;
            for (referenceIndex = 1; referenceIndex < values.Length; referenceIndex++) {
                if (t < values[referenceIndex].t) {
                    break;
                }
            }

            referenceIndex = Mathf.Clamp(referenceIndex, 0, values.Length - 1);
            float referenceT = Mathf.InverseLerp(values[referenceIndex - 1].t, values[referenceIndex].t, t);
            return lerpFunction(values[referenceIndex - 1].Value, values[referenceIndex].Value, referenceT);
        }

        public static Vector2 Evaluate(float t, params Vector2WithT[] values) {
            return Evaluate(t, Vector2.Lerp, values);
        }

        public static Color Evaluate(float t, params ColorWithT[] values) {
            return Evaluate(t, Color.Lerp, values);
        }

        public static string Evaluate(float t, params StringWithT[] values) {
            return Evaluate(t, LerpStringAtMiddle, values);
        }

        public static string LerpStringAtMiddle(string a, string b, float t) {
            return (t > .5f) ? b : a;
        }
    }


    public interface ValueWithLerp<T> {
        float t { get; }
        T Value { get; }
    }

    [System.Serializable]
    public abstract class BaseValueWithLerp<T> : ValueWithLerp<T> {
        [SerializeField]
        private float m_t = 0;
        public float t => m_t;

        public abstract T Value { get; }
    }

    [System.Serializable]
    public class Vector2WithT : BaseValueWithLerp<Vector2> {
        [SerializeField]
        private Vector2 m_value = Vector2.zero;
        public override Vector2 Value => m_value;
    }

    [System.Serializable]
    public class FloatWithT : BaseValueWithLerp<float> {
        [SerializeField]
        private float m_value = 0;
        public override float Value => m_value;
    }

    [System.Serializable]
    public class ColorWithT : BaseValueWithLerp<Color> {
        [SerializeField]
        private Color m_value = Color.white;
        public override Color Value => m_value;
    }

    [System.Serializable]
    public class StringWithT : BaseValueWithLerp<string> {
        [SerializeField]
        private string m_value = "";
        public override string Value => m_value;
    }

}