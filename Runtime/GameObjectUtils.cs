using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ScriptUtils {
    public static class GameObjectUtils {
        public static T[] FindGameObjectsWithLayer<T>(int layer) where T : MonoBehaviour {
            var goArray = GameObject.FindObjectsOfType<T>();
            var goList = new List<T>();
            for (var i = 0; i < goArray.Length; i++) {
                if (goArray[i].gameObject.layer == layer) {
                    goList.Add(goArray[i]);
                }
            }
            return goList.ToArray();
        }
#if UNITY_EDITOR
        public static void CopyAllComponentsTo(this GameObject gameObject, GameObject target, params Type[] ignore) {
            List<Type> ignoreTypes = new List<Type>(ignore);
            foreach (var comp in gameObject.GetComponents(typeof(Component))) {
                if (ignoreTypes.Contains(comp.GetType())) continue;
                UnityEditorInternal.ComponentUtility.CopyComponent(comp);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(target);
            }
        }
#endif

    }
}