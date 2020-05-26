namespace Funbites.UnityUtils.AnimatorComponent
{
    public class DebugBreakOnEnterStateBehaviour : UnityEngine.StateMachineBehaviour
    {
        public bool IsActive = true;
        public override void OnStateEnter(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (IsActive) UnityEngine.Debug.Break();
        }
    }
}