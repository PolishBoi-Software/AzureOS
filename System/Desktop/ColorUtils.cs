using GrapeGL.Graphics;

namespace PBOS.System.Utils
{
    public static class ColorUtils
    {
        public static Color Brighten(Color src, byte intensity)
        {
            byte r = (byte)(src.R + intensity);
            byte g = (byte)(src.G + intensity);
            byte b = (byte)(src.B + intensity);
            return new Color(r, g, b);
        }

        public static Color Darken(Color src, byte intensity)
        {
            byte r = (byte)(src.R - intensity);
            byte g = (byte)(src.G - intensity);
            byte b = (byte)(src.B - intensity);
            return new Color(r, g, b);
        }
    }   
}