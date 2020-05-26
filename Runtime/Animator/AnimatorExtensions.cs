namespace Funbites.UnityUtils.AnimatorComponent {
    public static class AnimatorExtensions {
        public static bool ContainsParam(this UnityEngine.Animator anim, int paramNameHash, UnityEngine.AnimatorControllerParameterType paramType) {
            UnityEngine.AnimatorControllerParameter[] animatorParams = anim.parameters;
            UnityEngine.AnimatorControllerParameter param;
            for (int i = 0; i < animatorParams.Length; i++) {
                param = animatorParams[i];
                if (param.nameHash == paramNameHash && param.type == paramType) return true;
            }
            return false;
        }
    }
}