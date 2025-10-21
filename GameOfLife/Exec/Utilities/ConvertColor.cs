using GameOfLife.Exec.Structs;

namespace GameOfLife.Exec.Utilities
{
    internal static class ConvertColor
    {
        public static float epsilon = 1e-6f;

        public static RGB HSVToRGB(HSV receivedColor)
        {
            RGB rgbOut = new();

            float H = receivedColor.H;
            float S = receivedColor.S;
            float V = receivedColor.V;

            if (S < epsilon)
            {
                byte val = (byte)(V * 255f + .5f);
                return new RGB(val, val, val);
            }

            float C = V * S;
            float HPrime = H / 60f;
            float X = C * (1 - Math.Abs(HPrime % 2 - 1));
            float m = V - C;
            int sector = (int)Math.Floor(HPrime);
            float r1;
            float g1;
            float b1;
            switch (sector)
            {
                case 0: r1 = C; g1 = X; b1 = 0; break;
                case 1: r1 = X; g1 = C; b1 = 0; break;
                case 2: r1 = 0; g1 = C; b1 = X; break;
                case 3: r1 = 0; g1 = X; b1 = C; break;
                case 4: r1 = X; g1 = 0; b1 = C; break;
                case 5: r1 = C; g1 = 0; b1 = X; break;
                default: r1 = 0; g1 = 0; b1 = 0; break;
            }

            rgbOut.R = (byte)((r1 + m) * 255f + .5f);
            rgbOut.G = (byte)((g1 + m) * 255f + .5f);
            rgbOut.B = (byte)((b1 + m) * 255f + .5f);

            return rgbOut;
        }
        public static RGB CMYKToRGB(CMYK receivedColor)
        {
            RGB rgbOut = new();

            float normCyan = receivedColor.C;
            float normMagenta = receivedColor.M;
            float normYellow = receivedColor.Y;
            float normKey = receivedColor.K;

            rgbOut.R = (byte)Math.Clamp(255 * ((1 - normCyan) * (1 - normKey)) + .5f, 0, 255);
            rgbOut.G = (byte)Math.Clamp(255 * ((1 - normMagenta) * (1 - normKey)) + .5f, 0, 255);
            rgbOut.B = (byte)Math.Clamp(255 * ((1 - normYellow) * (1 - normKey)) + .5f, 0, 255);

            return rgbOut;
        }

        public static HSV RGBToHSV(RGB receivedColor)
        {
            HSV hsvOut = new();

            float normRed = receivedColor.R / 255f;
            float normGreen = receivedColor.G / 255f;
            float normBlue = receivedColor.B / 255f;

            float max = Math.Max(normRed, Math.Max(normGreen, normBlue));
            float min = Math.Min(normRed, Math.Min(normGreen, normBlue));
            float delta = max - min;

            hsvOut.V = max;
            hsvOut.S = (max < epsilon) ? 0f : delta / max;

            if (delta < epsilon)
                hsvOut.H = 0;
            else if (max == normRed)
                hsvOut.H = (int)(60f * ((normGreen - normBlue) / delta % 6f) + .5f);
            else if (max == normGreen)
                hsvOut.H = (int)(60f * ((normBlue - normRed) / delta + 2f) + .5f);
            else
                hsvOut.H = (int)(60f * ((normRed - normGreen) / delta + 4f) + .5f);

            if (hsvOut.H < 0)
                hsvOut.H += 360;

            return hsvOut;
        }
        public static HSV CMYKToHSV(CMYK receivedColor)
        =>  RGBToHSV(CMYKToRGB(receivedColor));

        public static CMYK RGBToCMYK(RGB receivedColor)
        {
            CMYK cmykOut = new();

            float normRed = receivedColor.R / 255f;
            float normGreen = receivedColor.G / 255f;
            float normBlue = receivedColor.B / 255f;

            float normKey = 1 - Math.Max(normRed, Math.Max(normGreen, normBlue));
            float normCyan;
            float normMagenta;
            float normYellow;
            if (Math.Abs(normKey - 1f) < epsilon)
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
        =>  RGBToCMYK(HSVToRGB(receivedColor));
    }
}