namespace Funbites.UnityUtils.Editor {
    using Sirenix.OdinInspector;
    using Sirenix.OdinInspector.Editor;
    using UnityEditor;
    using UnityEngine;
    public class ScreenHelperWindow : OdinEditorWindow {
        [MenuItem("Tools/Funbites/Screen Helper")]
        private static void OpenWindow() {
            GetWindow<ScreenHelperWindow>().Show();
        }
        [SerializeField]
        private string m_filePath = "Screenshot.png";
        [Button]
        void CaptureScreenshot() {
            ScreenCapture.CaptureScreenshot(m_filePath);
        }
    }

}