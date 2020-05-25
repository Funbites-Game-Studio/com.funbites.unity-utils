using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ScriptUtils.Rand {
    public abstract class AdaptativeRandomPicker<T, J> : ScriptableObject where J : ProbabilityElement<T>  {
        private const int MaxOccorrencesCount = 20;

        public static float WeightSum(List<J> elementList) {
            float result = 0;
            foreach (ProbabilityElement<T> element in elementList) {
                result += element.Weight;
            }
            return result;
        }

        public abstract List<J> ElementsList { get; }



        [ShowInInspector, ReadOnly]
        private float elementsWeightSum = 0;
        public float ElementsWeightSum
        {
            get
            {
                if (elementsWeightSum > 0) return elementsWeightSum;
                elementsWeightSum = WeightSum(ElementsList);
                return elementsWeightSum;
            }
        }
        [ShowInInspector, ReadOnly]
        private int ocorrencesSum = 0;

        public T GetAdaptativeRandomElement() {
            return GetRandomElement(ocorrencesSum < ElementsWeightSum && ocorrencesSum < MaxOccorrencesCount);
        }

        public T GetRandomElement() {
            return GetRandomElement(true);
        }

        private T GetRandomElement(bool isStatic) {
            float prob = Random.value;
            float c = 0;
            T result = default(T);
            foreach (ProbabilityElement<T> probElement in ElementsList) {
                c += probElement.CalculateChance(isStatic, ElementsWeightSum, ocorrencesSum);
                if (prob < c) {
                    result = probElement.Element;
                    probElement.AddOcorrence();
                    ocorrencesSum++;
                    break;
                }
            }
            return result;
        }

        public float CalculateAverageError() {
            float result = 0;
            float curError;
            foreach (var element in ElementsList) {
                curError = element.CalculateError(ElementsWeightSum, ocorrencesSum);
                curError *= curError;
                result += curError;
            }
            return Mathf.Sqrt(result);
        }

        public void Clear() {
            ocorrencesSum = 0;
            elementsWeightSum = 0;
            foreach (var element in ElementsList) {
                element.ClearOcorrences();
            }
        }

        public override string ToString() {
            StringBuilder result = new StringBuilder();
            foreach (var element in ElementsList) {
                result.Append((element.Element == null)?"null":element.Element.ToString());
                result.Append(" ");
                result.Append(element.Ocorrences);
                result.Append(" ");
                result.Append(element.CalculateError(ElementsWeightSum, ocorrencesSum));
                result.Append(" | ");
            }
            result.Append($"E: {CalculateAverageError() * 100}%");
            return result.ToString();
        }

        [Button]
        private void Test(int nTimes, bool isStatic) {
            Clear();
            for (int i = 0; i < nTimes; i++) {
                if (isStatic) {
                    GetRandomElement();
                } else {
                    GetAdaptativeRandomElement();
                }
            }
            Debug.Log(ToString());
        }
    }
}
