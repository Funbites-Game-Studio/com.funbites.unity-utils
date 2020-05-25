using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ScriptUtils
{
    public static class NamingUtils
    {
        public static string GetFixedName(string defaultName, string descrition)
        {
            var descriptionMaxLength = 20;

            var newName = defaultName;

            if (!string.IsNullOrEmpty(descrition)) {
                var descriptionLessThanMaxLenght = descrition.Length <= descriptionMaxLength;

                var nameWithDescription = descriptionLessThanMaxLenght ?
                    $"{defaultName} ({descrition})" : $"{defaultName} ({descrition.Substring(0, descriptionMaxLength)}...)";

                newName = nameWithDescription;
            }

            return newName;
        }

        public static string TypeToText(Type type, string nameComplementToRemove)
        {
            if (type == null)
                return "None ..Please choose one!";

            var name = type.Name.Substring(0, type.Name.Length - nameComplementToRemove.Length);
            string[] splitedName = Regex.Split(name, @"(?<!^)(?=[A-Z])");

            string fullName = splitedName[0];

            for (int i = 1; i < splitedName.Length; i++) {
                var partialName = splitedName[i];
                fullName += $" {partialName}";
            }

            return fullName;
        }

        public static Type TextToType(string namespaceName, string text, string nameComplement)
        {
            var typeName = $"{namespaceName}.{text.Replace(" ", string.Empty)}";
            typeName += nameComplement;

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            List<Type> types = new List<Type>();

            foreach (Assembly assembly in assemblies) {
                Type type = assembly.GetType(typeName);
                if (type != null)
                    types.Add(type);
            }

            if (types.Count > 0)
                return types[0];

            return null;
        }

#if UNITY_EDITOR
        public static MonoScript[] GetScriptAssetsOfType<T>()
        {
            MonoScript[] scripts = (MonoScript[])Resources.FindObjectsOfTypeAll<MonoScript>();

            List<MonoScript> result = new List<MonoScript>();

            foreach (MonoScript m in scripts) {
                if (m.GetClass() != null && m.GetClass().IsSubclassOf(typeof(T))) {
                    result.Add(m);
                }
            }

            return result.ToArray();
        }
#endif
    }
}