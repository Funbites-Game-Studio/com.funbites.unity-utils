namespace Funbites.UnityUtils {
    public static class LayerMaskExtensions {
        public static bool HasLayer(this UnityEngine.LayerMask layerMask, int layer) {
            return (layerMask | (1 << layer)) == layerMask;
        }
    }
}