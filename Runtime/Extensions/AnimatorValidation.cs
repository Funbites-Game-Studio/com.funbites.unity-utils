using UnityEngine;

namespace ScriptUtils.AnimatorHelper {
    public static class AnimatorValidation {
        public static bool ContainsParam(this UnityEngine.Animator anim, int paramNameHash, AnimatorControllerParameterType paramType) {
            AnimatorControllerParameter[] animatorParams = anim.parameters;
            AnimatorControllerParameter param;
            for (int i = 0; i < animatorParams.Length; i++) {
                param = animatorParams[i];
                if (param.nameHash == paramNameHash && param.type == paramType) return true;
            }
            return false;
        }
    }
}