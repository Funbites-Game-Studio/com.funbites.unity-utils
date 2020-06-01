namespace Funbites.UnityUtils
{
    using System.Collections.Generic;
    public static class ListExtensions
    {

        public static List<T> Intersect<T>(this List<T> list, List<T> otherList)
        {
            List<T> result = new List<T>(list.Count);
            List<T> otherListTemp = new List<T>(otherList);
            foreach (T element in list)
            {
                if (otherListTemp.Contains(element))
                {
                    result.Add(element);
                    otherListTemp.Remove(element);
                }
            }
            return result;
        }
    }
}