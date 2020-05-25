namespace ScriptUtils {
    using UnityEngine;

    [AddComponentMenu(""), DefaultExecutionOrder(-5000)]
    public class WorkScheduler : SingletonMonoBehavior<WorkScheduler> {

        public float MaxWorkTime = 0.002f;
        public float MaxFrameTime = 0.008f;
        private bool didWorkThisFrame;
        private bool alreadyDidMaxWorkThisFrame;
        private float frameStartReferenceTime;
        private float workStartreferenceTime;

        protected void Awake() {
            didWorkThisFrame = false;
            alreadyDidMaxWorkThisFrame = false;
        }

        private void Update() {
            frameStartReferenceTime = Time.realtimeSinceStartup;
        }
        private float currentTime;
        public bool IsToSkipToNextFrame
        {
            get
            {
                if (alreadyDidMaxWorkThisFrame) return true;
                if (!didWorkThisFrame) {
                    workStartreferenceTime = Time.realtimeSinceStartup;
                }
                currentTime = Time.realtimeSinceStartup;
                if (currentTime - frameStartReferenceTime >= MaxFrameTime) {
                    alreadyDidMaxWorkThisFrame = true;
                    return true;
                }
                if (currentTime - workStartreferenceTime >= MaxWorkTime) {
                    alreadyDidMaxWorkThisFrame = true;
                    return true;
                }
                return false;
            }
        }

        private void LateUpdate() {
            didWorkThisFrame = false;
            alreadyDidMaxWorkThisFrame = false;
        }
    }
}