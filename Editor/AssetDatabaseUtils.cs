namespace Funbites.UnityUtils.Editor
{
    using UnityEditor;
    using System.Collections.Generic;

    public static class AssetDatabaseUtils {
        public static List<T> FindAssetsByType<T>() where T : UnityEngine.Object {
            string[] guids = AssetDatabase.FindAssets($"t:{typeof(T).Name}");
            List<T> assets = new List<T>(guids.Length);
            for (int i = 0; i < guids.Length; i++) {
                string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
                T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                if (asset != null) {
                    assets.Add(asset);
                }
            }
            return assets;
        }
    }
}