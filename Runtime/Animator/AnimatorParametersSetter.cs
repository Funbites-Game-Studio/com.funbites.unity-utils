namespace Funbites.UnityUtils.AnimatorComponent {
    [System.Serializable]
    public class AnimatorFloatParameterValue {
        public string ParameterName;

        public bool useRandomValue = false;

        [Sirenix.OdinInspector.HideIf("useRandomValue")]
        public float value;

        [Sirenix.OdinInspector.ShowIf("useRandomValue")]
        public float min;

        [Sirenix.OdinInspector.ShowIf("useRandomValue")]
        public float max;
    }

    [UnityEngine.RequireComponent(typeof(UnityEngine.Animator))]
    public class AnimatorParametersSetter : UnityEngine.MonoBehaviour
    {
        private UnityEngine.Animator animator;

        

        [UnityEngine.SerializeField]
        private AnimatorFloatParameterValue[] m_onStartAnimatorFloatSet = null;

        private void Awake()
        {
            animator = GetComponent<UnityEngine.Animator>();
        }

        private void Start()
        {
            foreach (var parameterValue in m_onStartAnimatorFloatSet) {
                var finalValue = parameterValue.useRandomValue ? UnityEngine.Random.Range(parameterValue.min, parameterValue.max) : parameterValue.value;
                SetFloat(parameterValue.ParameterName, finalValue);
            }
        }

        public void SetBool(string parameterName, bool value)
        {
            animator.SetBool(parameterName, value);
        }

        public void SetBool(int parameterHash, bool value)
        {
            animator.SetBool(parameterHash, value);
        }

        public void SetFloat(string parameterName, float value)
        {
            animator.SetFloat(parameterName, value);
        }

        public void SetFloat(int parameterHash, float value)
        {
            animator.SetFloat(parameterHash, value);
        }
    }
}