namespace Funbites.UnityUtils.Editor
{
    public static class OdinUtils
    {
        public static string[] GetTags()
        {
            return UnityEditorInternal.InternalEditorUtility.tags;
        }
    }
}