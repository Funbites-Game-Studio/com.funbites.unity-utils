using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptUtils
{
    public class Shadow : MonoBehaviour
    {
        [SerializeField, ToggleLeft]
        private bool m_updateSize = true;

        private float _maxDistanceFromFloor = 3.5f;

        public float DistanceFromFloor
        {
            get
            {
                var parentTransform = transform.parent;
                return Vector3.Distance(FloorPosition, parentTransform.position);
            }
        }

        public Vector3 UpVector { get { return transform.up; } }

        protected LayerMask floorLayerMask;

        public virtual Vector3 FloorPosition
        {
            get
            {
                var parentTransform = transform.parent;
                var position = parentTransform.position + UpVector * 0.1f;
                var ray = new Ray(position, -UpVector);
                RaycastHit hit;
                var hitSomething = Physics.Raycast(ray, out hit, 50, floorLayerMask);
                if (hitSomething)
                    return hit.point;
                else return parentTransform.position;
            }
        }

        private void Awake()
        {
            SetupSpriteRenderer();
            gameObject.layer = 0;//Default;
            floorLayerMask = LayerMask.GetMask("Obstacles", "LevelCollision");

            transform.localPosition = new Vector3(transform.localPosition.x, 0, 0);
            var view = transform.GetChild(0);
            if (view != null)
                view.transform.position += Vector3.forward * 0.1f;
            OnAwake();
        }

        private void SetupSpriteRenderer()
        {
            var spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingLayerName = "Gameplay";
                spriteRenderer.gameObject.layer = 0;
            }
        }

        protected virtual void OnAwake()
        {
        }

        public void DisableShadow()
        {
            gameObject.SetActive(false);
        }

        public void EnableShadow()
        {
            gameObject.SetActive(true);
        }

        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, FloorPosition.y, FloorPosition.z);
            if (m_updateSize)
                ChangeShadowSize();
        }

        private void ChangeShadowSize()
        {
            var factor = (_maxDistanceFromFloor - DistanceFromFloor) / _maxDistanceFromFloor;
            factor = Mathf.Clamp(factor, 0, 1);

            transform.localScale = new Vector3(factor, factor, factor);
        }
    }
}