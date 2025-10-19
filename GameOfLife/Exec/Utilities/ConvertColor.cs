using GameOfLife.Exec.Structs;

namespace GameOfLife.Exec.Utilities
{
    internal static class ConvertColor
    {
        public static RGB HSVToRGB(HSV receivedColor)
            => new RGB();
        public static RGB CMYKToRGB(CMYK receivedColor)
        {
            RGB rgbOut;

            float normCyan = receivedColor.C;
            float normMagenta = receivedColor.M;
            float normYellow = receivedColor.Y;
            float normKey = receivedColor.K;

            byte R = (byte)Math.Clamp(Math.Round(255 * ((1 - normCyan) * (1 - normKey))), 0, 255);
            byte G = (byte)Math.Clamp(Math.Round(255 * ((1 - normMagenta) * (1 - normKey))), 0, 255);
            byte B = (byte)Math.Clamp(Math.Round(255 * ((1 - normYellow) * (1 - normKey))), 0, 255);

            rgbOut = new RGB(R, G, B);

            return rgbOut;
        }

        public static HSV RGBToHSV(RGB receivedColor)
            => new HSV();
        public static HSV CMYKToHSV(CMYK receivedColor)
            => new HSV();

        public static CMYK RGBToCMYK(RGB receivedColor)
        {
            CMYK cmykOut = new CMYK();

            float normRed = receivedColor.R / 255f;
            float normGreen = receivedColor.G / 255f;
            float normBlue = receivedColor.B / 255f;

            float normKey = 1 - Math.Max(normRed, Math.Max(normGreen, normBlue));
            float normCyan;
            float normMagenta;
            float normYellow;
            if (Math.Abs(normKey - 1f) < 1e-6f)
            {
                normCyan = 0;
                normMagenta = 0;
                normYellow = 0;
            }
            else
            {
                normCyan = (1 - normRed - normKey) / (1 - normKey);
                normMagenta = (1 - normGreen - normKey) / (1 - normKey);
                normYellow = (1 - normBlue - normKey) / (1 - normKey);
            }
            cmykOut.C = normCyan;
            cmykOut.M = normMagenta;
            cmykOut.Y = normYellow;
            cmykOut.K = normKey;

            return cmykOut;
        }
        public static CMYK HSVtoCMYK(HSV receivedColor)
            => new CMYK();
    }
}