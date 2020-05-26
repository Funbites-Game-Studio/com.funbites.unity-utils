namespace Funbites.UnityUtils.Probability {
    
    using Sirenix.OdinInspector;
    using System;
    using UnityEngine;

    [Serializable]
    public abstract class ProbabilityElement<T> {
        [SerializeField, MinValue(1)]
        private float m_weight = 1;
        public float Weight { get => m_weight; protected set => m_weight = value; }

        public abstract T Element { get; }
        [ShowInInspector, ReadOnly]
        public int Ocorrences { get; private set; }

        internal void AddOcorrence() {
            Ocorrences++;
        }

        internal void ClearOcorrences() {
            Ocorrences = 0;
        }

        internal float CalculateChance(bool isStatic, float elementsWeightSum, float ocorrencesSum) {
            float staticWeight = m_weight / elementsWeightSum;
            if (isStatic) return staticWeight;
            float actualProb = Ocorrences / ocorrencesSum;
            return 2* staticWeight - actualProb;
        }

        internal float CalculateError(float elementsWeightSum, float ocorrencesSum) {
            return (m_weight / elementsWeightSum) - (Ocorrences / ocorrencesSum);
        }

    }
}
