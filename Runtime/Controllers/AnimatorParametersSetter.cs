using Sirenix.OdinInspector;
using System;
using UnityEngine;
using AnimatorComp = UnityEngine.Animator;

namespace ScriptUtils.AnimatorHelper
{
    [RequireComponent(typeof(UnityEngine.Animator))]
    public class AnimatorParametersSetter : MonoBehaviour
    {
        private AnimatorComp animator;

        [Serializable]
        public class AnimatorFloatParameterValue
        {
            public string ParameterName;

            public bool useRandomValue = false;

            [HideIf("useRandomValue")]
            public float value;

            [ShowIf("useRandomValue")]
            public float min;

            [ShowIf("useRandomValue")]
            public float max;
        }

        [SerializeField]
        private AnimatorFloatParameterValue[] m_onStartAnimatorFloatSet;

        private void Awake()
        {
            animator = GetComponent<AnimatorComp>();
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