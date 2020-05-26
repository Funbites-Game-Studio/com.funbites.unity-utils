namespace Funbites.UnityUtils.Editor {
    public static class CustomCreateAsset {
        public static void CreateScriptableAssetInCurrentSelection(UnityEngine.ScriptableObject instance, string name) {
            var path = "Assets/";
            var obj = UnityEditor.Selection.activeObject;
            if (obj != null) {
                path = UnityEditor.AssetDatabase.GetAssetPath(obj.GetInstanceID());
                if (System.IO.Directory.Exists(path)) {
                    path += "/";
                } else {
                    path = path.Substring(0, path.LastIndexOf("/") + 1);
                }
            }
            path = path + name + ".asset";
            path = UnityEditor.AssetDatabase.GenerateUniqueAssetPath(path);
            UnityEditor.AssetDatabase.CreateAsset(instance, path);
        }
    }
}