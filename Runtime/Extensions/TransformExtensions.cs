namespace Funbites.UnityUtils
{

    using UnityEngine;

    public static class TransformExtensions
    {
        public static Transform FindChildDeep(this Transform transform, string childName)
        {
            var child = FindChildByName(transform, childName);

            return child;
        }

        public static void SetX(this Transform transform, float x)
        {
            Vector3 newPosition =
               new Vector3(x, transform.position.y, transform.position.z);

            transform.position = newPosition;
        }

        public static void SetY(this Transform transform, float y)
        {
            Vector3 newPosition =
               new Vector3(transform.position.x, y, transform.position.z);

            transform.position = newPosition;
        }

        public static void SetZ(this Transform transform, float z)
        {
            Vector3 newPosition =
               new Vector3(transform.position.x, transform.position.y, z);

            transform.position = newPosition;
        }

        public static void SetLocalX(this Transform transform, float x)
        {
            Vector3 newPosition =
               new Vector3(x, transform.localPosition.y, transform.localPosition.z);

            transform.localPosition = newPosition;
        }

        public static void SetLocalY(this Transform transform, float y)
        {
            Vector3 newPosition =
               new Vector3(transform.localPosition.x, y, transform.localPosition.z);

            transform.localPosition = newPosition;
        }

        public static void SetLocalZ(this Transform transform, float z)
        {
            Vector3 newPosition =
               new Vector3(transform.localPosition.x, transform.localPosition.y, z);

            transform.localPosition = newPosition;
        }

        private static Transform FindChildByName(Transform transform, string childName)
        {
            Transform child = null;

            if (transform.childCount == 0)
                return child;

            foreach (Transform c in transform) {
                if (c.name == childName) {
                    child = c;
                    break;
                } else {
                    child = FindChildByName(c, childName);

                    if (child != null)
                        break;
                }
            }

            return child;
        }

        public static Transform GetChildThatContains(this Transform transform, string nameSubWord)
        {
            Transform result = transform;
            nameSubWord = nameSubWord.ToUpper();
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).name.ToUpper().Contains(nameSubWord))
                {
                    result = transform.GetChild(i);
                    break;
                }
            }
            return result;
        }

        public static void Reset(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

    }
}