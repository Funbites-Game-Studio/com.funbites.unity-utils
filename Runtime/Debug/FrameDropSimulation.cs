namespace Funbites.UnityUtils.Debug {
    public class FrameDropSimulation : UnityEngine.MonoBehaviour {
        [UnityEngine.SerializeField, UnityEngine.Range(.000001f, 30f)]
        private float m_seconds = 1f;
        [UnityEngine.SerializeField]
        private bool AssingToKeyboard = true;
        [Sirenix.OdinInspector.ShowIf("AssingToKeyboard")]
        [UnityEngine.SerializeField]
        private UnityEngine.KeyCode KeyboardKey = UnityEngine.KeyCode.Alpha0;
        
        void Update() {
            if (AssingToKeyboard && UnityEngine.Input.GetKeyDown(KeyboardKey))
            {
                DropFrames();
            }
        }

        [Sirenix.OdinInspector.Button]
        void DropFrames() {
            long startingTicks = System.DateTime.Now.Ticks;
            while (true) {
                long currentTicks = System.DateTime.Now.Ticks - startingTicks;
                System.TimeSpan elapsedSpan = new System.TimeSpan(currentTicks);
                if (elapsedSpan.TotalSeconds > m_seconds)
                    break;
            }
        }
    }
}