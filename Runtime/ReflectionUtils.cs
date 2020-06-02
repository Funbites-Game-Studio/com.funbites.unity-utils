namespace Funbites.UnityUtils
{
    using System;
    using System.Collections.Generic;

    public static class ReflectionUtils
    {
        public static List<Type> FindAllDerivedTypes(this AppDomain aAppDomain, Type aType)
        {
            var result = new List<Type>();
            var assemblies = aAppDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsSubclassOf(aType))
                        result.Add(type);
                }
            }
            return result;
        }

        public static List<Type> FindAllDerivedTypesOfGeneric(this AppDomain appDomain, Type genericType)
        {
            var result = new List<Type>();
            var assemblies = appDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType) continue;
                    if (type.IsSubclassOfRawGeneric(genericType))
                        result.Add(type);
                }
            }
            return result;
        }

        public static bool IsSubclassOfRawGeneric(this Type toCheck, Type rawGeneric)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (rawGeneric == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }
    }
}