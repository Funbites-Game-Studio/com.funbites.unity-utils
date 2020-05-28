namespace Funbites.UnityUtils.Editor {
    using Sirenix.OdinInspector;
    using Sirenix.OdinInspector.Editor;
    using UnityEditor;

    public class DebugHelperWindow : OdinEditorWindow
    {
        internal const string AsmdefDebugActivationKey = "IS_DEBUG_HELPER_ASMDEF_DEBUG_KEY";
        [MenuItem("Tools/Funbites/Debug Helper")]
        private static void OpenWindow()
        {
            GetWindow<DebugHelperWindow>().Show();
        }
        [ShowInInspector, ToggleLeft]
        private bool Is_ASMDEF_Debug_Active {
            get {
                return EditorPrefs.GetBool(AsmdefDebugActivationKey, false);
            }
            set {
                EditorPrefs.SetBool(AsmdefDebugActivationKey, value);
                AsmdefDebug.SetActivation(value);
            }
        }

    }
}