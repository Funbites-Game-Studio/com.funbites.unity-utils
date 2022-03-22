namespace Funbites.UnityUtils
{
    public static class OdinUtils
    {

        public const string IsApplicationPlaying = "@UnityEngine.Application.isPlaying";

        public static string[] GetTags()
        {
#if UNITY_EDITOR
            return UnityEditorInternal.InternalEditorUtility.tags;
#else
            throw new System.NotImplementedException("Editor only function.");
#endif
        }
    }
}