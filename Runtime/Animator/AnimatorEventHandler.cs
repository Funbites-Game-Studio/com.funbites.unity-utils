using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScriptUtils.AnimatorHelper {
    [RequireComponent(typeof(Animator))]
    public class AnimatorEventHandler : MonoBehaviour {
        private Animator animator;

        private void Awake() {
            animator = GetComponent<Animator>();
        }

        public void SetBoolToTrue(string parameterName) {
            animator.SetBool(parameterName, true);
        }

        public void SetBoolToFalse(string parameterName) {
            animator.SetBool(parameterName, false);
        }

        

    }
}