using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptUtils {
    public class FrameDropSimulation : MonoBehaviour {

        public float seconds = 1f; // Expose in the inspector how long the system will hang.
        public bool AssingToKeyboard = true;
        [ShowIf("AssingToKeyboard")]
        public KeyCode KeyboardKey = KeyCode.Alpha0;
        void Update() {
            if (AssingToKeyboard && Input.GetKeyDown(KeyboardKey)) // Trigger by pushing alphanumeric 0
            {
                DropFrames();
            }
        }
        [Button]
        void DropFrames() {
            long startingTicks = DateTime.Now.Ticks; // Get the current time in ticks
            while (true) {
                long currentTicks = DateTime.Now.Ticks - startingTicks; // find ticks since the loop started
                TimeSpan elapsedSpan = new TimeSpan(currentTicks); // We use TimeSpan to convert to seconds
                if (elapsedSpan.TotalSeconds > seconds) // If the time runs out we break the loop.
                    break;
            }
        }
    }
}