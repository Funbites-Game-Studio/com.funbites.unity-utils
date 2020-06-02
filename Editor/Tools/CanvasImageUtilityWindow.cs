namespace Funbites.UnityUtils.Editor
{
    using Sirenix.OdinInspector;
    using Sirenix.OdinInspector.Editor;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.UI;

    public class CanvasImageUtilityWindow : OdinEditorWindow
    {
        [MenuItem("Tools/Funbites/Canvas Image Utility")]
        private static void OpenWindow()
        {
            GetWindow<CanvasImageUtilityWindow>().Show();
        }
        [Button]
        private void SetNativeSizeWithAspectDeformation(Image image, float originalAspectWidth = 10, float originalAspectHeight = 16, float scale = .9f)
        {
            image.SetNativeSize();
            int width = Mathf.CeilToInt(image.rectTransform.rect.width*scale);
            int height = Mathf.CeilToInt(width / originalAspectWidth * originalAspectHeight);
            image.rectTransform.sizeDelta = new Vector2(width, height);
        }
    }
}