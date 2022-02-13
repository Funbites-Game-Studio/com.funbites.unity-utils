namespace Funbites.UnityUtils.Editor
{
    public static class OdinUtils
    {

        public const string IsApplicationPlaying = "@UnityEngine.Application.isPlaying";

        public static string[] GetTags()
        {
            return UnityEditorInternal.InternalEditorUtility.tags;
        }
    }
}