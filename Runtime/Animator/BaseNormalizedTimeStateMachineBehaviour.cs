namespace Funbites.UnityUtils.AnimatorComponent { 

    using Animator = UnityEngine.Animator;
    using AnimatorStateInfo = UnityEngine.AnimatorStateInfo;
    public enum AnimatorStateCallbackOption {
        Start,
        Update,
        Exit
    }

    public abstract class BaseNormalizedTimeStateMachineBehaviour : UnityEngine.StateMachineBehaviour {
        [Sirenix.OdinInspector.ShowInInspector]
        [Sirenix.OdinInspector.ReadOnly]
        private bool didExecute;

        protected abstract AnimatorStateCallbackOption CallbackOption { get; }

        protected abstract bool UpdateZeroCanCallOnStart { get; }
        protected abstract bool IsGuaranteedToCallOnExit { get; }
        protected abstract float NormalizedDelay { get; }

        protected abstract void Execute(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            didExecute = false;
            if (CallbackOption == AnimatorStateCallbackOption.Start || (UpdateZeroCanCallOnStart && NormalizedDelay == 0)) {
                OnExecute(animator, stateInfo, layerIndex);
            }
        }

        private float clampedNormalizedTime;

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (CallbackOption != AnimatorStateCallbackOption.Update) return;
            clampedNormalizedTime = stateInfo.normalizedTime % 1;
            if (!didExecute && clampedNormalizedTime >= NormalizedDelay) {
                OnExecute(animator, stateInfo, layerIndex);
            }
        }

        private void OnExecute(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            didExecute = true;

            Execute(animator, stateInfo, layerIndex);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (CallbackOption == AnimatorStateCallbackOption.Exit || (!didExecute && (IsGuaranteedToCallOnExit || NormalizedDelay >= 1))) {
                OnExecute(animator, stateInfo, layerIndex);
            }
        }

        protected bool IsUpdateCallback()
        {
            return CallbackOption == AnimatorStateCallbackOption.Update;
        }
    }
}