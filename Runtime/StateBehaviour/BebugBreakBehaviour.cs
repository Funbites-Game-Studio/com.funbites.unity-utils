using UnityEngine;

namespace ScriptUtils
{
    public class BebugBreakBehaviour : StateMachineBehaviour
    {
        public override void OnStateEnter(UnityEngine.Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Break();
        }
    }
}