using UnityEngine;

namespace ScriptUtils
{
    public static class ColorExtensions
    {
        public static Color ChangeAlpha(this Color defaultColor, float alpha = 0)
        {
            return new Color(defaultColor.r, defaultColor.g, defaultColor.b, alpha);
        }

        public static Color orange => new Color(1f, .6484375f, 0);

        public static Color lightGray => new Color(.75f, .75f, .75f);

    }
}