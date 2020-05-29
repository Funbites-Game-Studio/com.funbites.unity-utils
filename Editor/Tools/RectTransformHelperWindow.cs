namespace Funbites.UnityUtils.Editor {
    using Sirenix.OdinInspector;
    using Sirenix.OdinInspector.Editor;
    using System;
    using UnityEditor;
    using UnityEngine;
    public class RectTransformHelperWindow : OdinEditorWindow {
        [MenuItem("Tools/Funbites/Rect Transform Helper")]
        private static void OpenWindow() {
            GetWindow<RectTransformHelperWindow>().Show();
        }

        private void ValidateTarget(RectTransform target)
        {
            if (target == null) throw new Exception("Set a target to perform operation.");
            if (target.parent == null) throw new Exception("Target RectTransform must have a parent RectTransform.");
        }

        [Button]
        private void StickAnchorsToBounds(RectTransform target) {
            ValidateTarget(target);
            Stick(target);
        }


        static private void Stick(RectTransform currentRectTransform) {
            
            Vector2 sizes = new Vector2(currentRectTransform.rect.width, currentRectTransform.rect.height);
            Vector2 posXY = CalculateCurrentXY(currentRectTransform, sizes);
            Rect anchorRect = new Rect(posXY, sizes);
            AnchorsToCorners(currentRectTransform, anchorRect);
            EditorUtility.SetDirty(currentRectTransform.gameObject);
        }

        static private Vector2 CalculateCurrentXY(RectTransform currentRectTransform, Vector2 sizes) {
            RectTransform parentRectTransform = currentRectTransform.parent.gameObject.GetComponent<RectTransform>();
            float pivotX = sizes.x * currentRectTransform.pivot.x;
            float pivotY = sizes.y * (1 - currentRectTransform.pivot.y);
            return new Vector2(currentRectTransform.anchorMin.x * parentRectTransform.rect.width + currentRectTransform.offsetMin.x + pivotX,
                                      -(1 - currentRectTransform.anchorMax.y) * parentRectTransform.rect.height + currentRectTransform.offsetMax.y - pivotY + parentRectTransform.rect.height);
        }

        static private void AnchorsToCorners(RectTransform currentRectTransform, Rect anchorRect) {
            RectTransform parentRectTransform = currentRectTransform.parent.gameObject.GetComponent<RectTransform>();

            float pivotX = anchorRect.width * currentRectTransform.pivot.x;
            float pivotY = anchorRect.height * (1 - currentRectTransform.pivot.y);
            currentRectTransform.anchorMin = new Vector2(0f, 1f);
            currentRectTransform.anchorMax = new Vector2(0f, 1f);
            currentRectTransform.offsetMin = new Vector2(anchorRect.x / currentRectTransform.localScale.x, anchorRect.y / currentRectTransform.localScale.y - anchorRect.height);
            currentRectTransform.offsetMax = new Vector2(anchorRect.x / currentRectTransform.localScale.x + anchorRect.width, anchorRect.y / currentRectTransform.localScale.y);
            currentRectTransform.anchorMin = new Vector2(currentRectTransform.anchorMin.x + (currentRectTransform.offsetMin.x - pivotX) / parentRectTransform.rect.width * currentRectTransform.localScale.x,
                                                     currentRectTransform.anchorMin.y - 1 + (currentRectTransform.offsetMin.y + pivotY) / parentRectTransform.rect.height * currentRectTransform.localScale.y);
            currentRectTransform.anchorMax = new Vector2(currentRectTransform.anchorMax.x + (currentRectTransform.offsetMax.x - pivotX) / parentRectTransform.rect.width * currentRectTransform.localScale.x,
                                                     currentRectTransform.anchorMax.y - 1 + (currentRectTransform.offsetMax.y + pivotY) / parentRectTransform.rect.height * currentRectTransform.localScale.y);
            currentRectTransform.offsetMin = new Vector2((0 - currentRectTransform.pivot.x) * anchorRect.width * (1 - currentRectTransform.localScale.x), (0 - currentRectTransform.pivot.y) * anchorRect.height * (1 - currentRectTransform.localScale.y));
            currentRectTransform.offsetMax = new Vector2((1 - currentRectTransform.pivot.x) * anchorRect.width * (1 - currentRectTransform.localScale.x), (1 - currentRectTransform.pivot.y) * anchorRect.height * (1 - currentRectTransform.localScale.y));
        }

        [Button]
        private void SetPivotToResetPosition(RectTransform target)
        {
            ValidateTarget(target);
            if (target.anchorMin != target.anchorMax) throw new Exception("AnchorMin and AnchorMax must be the same for this operation");
            if (target.localScale != Vector3.one) throw new Exception("This function does not work for scaled objects... it is good to TODO... sorry");
            //TODO: implement scale support
            target.pivot = -(target.anchoredPosition - target.rect.size * target.pivot) / target.rect.size;
            target.anchoredPosition = Vector2.zero;
        }
    }
}