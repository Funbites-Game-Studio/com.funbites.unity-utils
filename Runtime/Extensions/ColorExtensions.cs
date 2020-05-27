namespace Funbites.UnityUtils
{
    using Color = UnityEngine.Color;
    public static class ColorExtensions
    {
        public static Color ChangeAlpha(this Color defaultColor, float alpha = 0)
        {
            return new Color(defaultColor.r, defaultColor.g, defaultColor.b, alpha);
        }

        public static Color orange => new Color(1f, .6484375f, 0);

        public static Color lightGray => new Color(.75f, .75f, .75f);
        public static Color MultiplyBrightness(this Color originalColor, float brightnessFactor)
        {
            float hue, saturation, brightness;
            Color.RGBToHSV(originalColor, out hue, out saturation, out brightness);
            return Color.HSVToRGB(hue, saturation, brightness * brightnessFactor);
        }



        public static Color MultiplySaturation(this Color originalColor, float saturationFactor)
        {
            float hue, saturation, brightness;
            Color.RGBToHSV(originalColor, out hue, out saturation, out brightness);
            return Color.HSVToRGB(hue, saturation * saturationFactor, brightness);
        }

    }
}