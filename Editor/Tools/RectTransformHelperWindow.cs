namespace Funbites.UnityUtils.Editor {
    using Sirenix.OdinInspector;
    using Sirenix.OdinInspector.Editor;
    using UnityEditor;
    using UnityEngine;
    public class RectTransformHelperWindow : OdinEditorWindow {
        [MenuItem("Tools/Funbites/Rect Transform Helper")]
        private static void OpenWindow() {
            GetWindow<RectTransformHelperWindow>().Show();
        }

        [Button]
        private void SetAnchorsToResetCoordinates(RectTransform target) {
            if (target != null && target.parent != null && ShouldStick(target)) {
                //Debug.Log("[Anchors Tools] Updating");
                Stick(target);
            }
        }


        static public Rect anchorRect;
        static public Vector2 anchorVector;
        static private Rect anchorRectOld;
        static private Vector2 anchorVectorOld;
        //static private RectTransform currentRectTransform;
        //static private RectTransform parentRectTransform;
        static private Vector2 pivotOld;
        static private Vector2 offsetMinOld;
        static private Vector2 offsetMaxOld;

        static private bool ShouldStick(RectTransform currentRectTransform) {
            return (
                currentRectTransform.offsetMin != offsetMinOld ||
                currentRectTransform.offsetMax != offsetMaxOld ||
                currentRectTransform.pivot != pivotOld ||
                anchorVector != anchorVectorOld ||
                anchorRect != anchorRectOld
                );
        }

        static private void Stick(RectTransform currentRectTransform) {
            CalculateCurrentWH(currentRectTransform);
            CalculateCurrentXY(currentRectTransform);

            CalculateCurrentXY(currentRectTransform);
            pivotOld = currentRectTransform.pivot;
            anchorVectorOld = anchorVector;

            AnchorsToCorners(currentRectTransform);
            anchorRectOld = anchorRect;

            UnityEditor.EditorUtility.SetDirty(currentRectTransform.gameObject);
        }

        static private void CalculateCurrentXY(RectTransform currentRectTransform) {
            RectTransform parentRectTransform = currentRectTransform.parent.gameObject.GetComponent<RectTransform>();
            float pivotX = anchorRect.width * currentRectTransform.pivot.x;
            float pivotY = anchorRect.height * (1 - currentRectTransform.pivot.y);
            Vector2 newXY = new Vector2(currentRectTransform.anchorMin.x * parentRectTransform.rect.width + currentRectTransform.offsetMin.x + pivotX - parentRectTransform.rect.width * anchorVector.x,
                                      -(1 - currentRectTransform.anchorMax.y) * parentRectTransform.rect.height + currentRectTransform.offsetMax.y - pivotY + parentRectTransform.rect.height * (1 - anchorVector.y));
            anchorRect.x = newXY.x;
            anchorRect.y = newXY.y;
            anchorRectOld = anchorRect;
        }

        static private void CalculateCurrentWH(RectTransform currentRectTransform) {
            anchorRect.width = currentRectTransform.rect.width;
            anchorRect.height = currentRectTransform.rect.height;
            anchorRectOld = anchorRect;
        }

        static private void AnchorsToCorners(RectTransform currentRectTransform) {
            RectTransform parentRectTransform = currentRectTransform.parent.gameObject.GetComponent<RectTransform>();

            float pivotX = anchorRect.width * currentRectTransform.pivot.x;
            float pivotY = anchorRect.height * (1 - currentRectTransform.pivot.y);
            currentRectTransform.anchorMin = new Vector2(0f, 1f);
            currentRectTransform.anchorMax = new Vector2(0f, 1f);
            currentRectTransform.offsetMin = new Vector2(anchorRect.x / currentRectTransform.localScale.x, anchorRect.y / currentRectTransform.localScale.y - anchorRect.height);
            currentRectTransform.offsetMax = new Vector2(anchorRect.x / currentRectTransform.localScale.x + anchorRect.width, anchorRect.y / currentRectTransform.localScale.y);
            currentRectTransform.anchorMin = new Vector2(currentRectTransform.anchorMin.x + anchorVector.x + (currentRectTransform.offsetMin.x - pivotX) / parentRectTransform.rect.width * currentRectTransform.localScale.x,
                                                     currentRectTransform.anchorMin.y - (1 - anchorVector.y) + (currentRectTransform.offsetMin.y + pivotY) / parentRectTransform.rect.height * currentRectTransform.localScale.y);
            currentRectTransform.anchorMax = new Vector2(currentRectTransform.anchorMax.x + anchorVector.x + (currentRectTransform.offsetMax.x - pivotX) / parentRectTransform.rect.width * currentRectTransform.localScale.x,
                                                     currentRectTransform.anchorMax.y - (1 - anchorVector.y) + (currentRectTransform.offsetMax.y + pivotY) / parentRectTransform.rect.height * currentRectTransform.localScale.y);
            currentRectTransform.offsetMin = new Vector2((0 - currentRectTransform.pivot.x) * anchorRect.width * (1 - currentRectTransform.localScale.x), (0 - currentRectTransform.pivot.y) * anchorRect.height * (1 - currentRectTransform.localScale.y));
            currentRectTransform.offsetMax = new Vector2((1 - currentRectTransform.pivot.x) * anchorRect.width * (1 - currentRectTransform.localScale.x), (1 - currentRectTransform.pivot.y) * anchorRect.height * (1 - currentRectTransform.localScale.y));

            offsetMinOld = currentRectTransform.offsetMin;
            offsetMaxOld = currentRectTransform.offsetMax;
        }
    }
}