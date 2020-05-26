namespace Funbites.UnityUtils.CameraComponent {
    using UnityEngine;
    public static class CameraExtensions {

        public static bool IsPointInsideView(this Camera camera, Vector3 point, Vector2 screenPercentageSafeBorder) {
            Vector3 viewportPoint = camera.WorldToViewportPoint(point);
            return viewportPoint.x >= screenPercentageSafeBorder.x && viewportPoint.x <= (1 - screenPercentageSafeBorder.x) 
                && viewportPoint.y >= screenPercentageSafeBorder.y && viewportPoint.y <= (1 - screenPercentageSafeBorder.y);
        }

        public static Vector3 WorldToScreenNormalizedPoint(this Camera camera, Vector3 point) {
            Vector3 screenSpace = camera.WorldToScreenPoint(point);
            screenSpace.x /= Screen.width;
            screenSpace.y /= Screen.height;
            return screenSpace;
        }

        public static void DrawCameraGizmos(Transform transform, Camera camera, Vector3 offset) {
            DrawCameraGizmos(Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one), camera, offset);
        }

        public static void DrawCameraGizmos(Matrix4x4 matrix, Camera camera, Vector3 offset) {
            DrawCameraGizmos(matrix, camera.orthographic, camera.farClipPlane, camera.nearClipPlane,
            camera.orthographicSize, camera.aspect, camera.fieldOfView, offset);
        }
        public static void DrawCameraGizmosOverrideSize(Matrix4x4 matrix, Camera camera, Vector3 offset, float cameraOrthographicSize) {
            DrawCameraGizmos(matrix, camera.orthographic, camera.farClipPlane, camera.nearClipPlane,
            cameraOrthographicSize, camera.aspect, camera.fieldOfView, offset);
        }

        public static void DrawCameraGizmos(Matrix4x4 matrix, bool cameraOrthographic, float cameraFarClipPlane, float cameraNearClipPlane, 
            float cameraOrthographicSize, float cameraAspect, float cameraFieldOfView, Vector3 offset) {
            Matrix4x4 temp = Gizmos.matrix;
            Gizmos.matrix = matrix;
            if (cameraOrthographic) {
                float spread = cameraFarClipPlane - cameraNearClipPlane;
                float center = (cameraFarClipPlane + cameraNearClipPlane) * 0.5f;
                Gizmos.DrawWireCube(new Vector3(offset.x, offset.y, center), new Vector3(cameraOrthographicSize * 2 * cameraAspect, cameraOrthographicSize * 2, spread));
            } else {
                Gizmos.DrawFrustum(offset, cameraFieldOfView, cameraFarClipPlane, cameraNearClipPlane, cameraAspect);
            }
            Gizmos.matrix = temp;
        }

        public static void BoundsToCameraScreenSpace(this Camera camera, Bounds bounds, ref Rect outRect) {
            Vector3 min, max;
            min = camera.WorldToScreenPoint(new Vector3(bounds.min.x, bounds.min.y, 0f));
            max = camera.WorldToScreenPoint(new Vector3(bounds.max.x, bounds.max.y, 0f));
            outRect.xMin = min.x;
            outRect.yMin = min.y;
            outRect.xMax = max.x;
            outRect.yMax = max.y;
        }
    }
}