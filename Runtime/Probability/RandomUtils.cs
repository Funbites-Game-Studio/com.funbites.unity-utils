namespace Funbites.Probability {

    using System.Collections;
    using UnityEngine;

    public class RandomUtils
    {
        public static void RandomizeList(IList list, int count)
        {
            int limit = Mathf.Min(list.Count, count);
            int listLastIndex = list.Count - 1;
            int sortedIndex;
            object tempVal;
            for (int i = 0; i < limit; i++) {
                sortedIndex = UnityEngine.Random.Range(i, listLastIndex);
                tempVal = list[i];
                list[i] = list[sortedIndex];
                list[sortedIndex] = tempVal;
            }
        }

        public static int[] RandomFromRange(int min, int max, int amount) {
            int range = max - min;
            if (amount > range) throw new System.Exception("Amount of elements must be less than the range");
            return SubArray<int>(CreateSortedRange(min, range), 0, amount);
        }

        public static int[] CreateSortedRange(int initialIndex, int total) {
            int[] result = new int[total];
            for (int i = 0; i < total; i++) {
                result[i] = initialIndex + i;
            }
            RandomizeList(result, total);
            return result;
        }

        public static T[] SubArray<T>(T[] data, int index, int length) {
            T[] result = new T[length];
            System.Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}