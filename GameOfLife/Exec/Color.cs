using GameOfLife.Exec.Structs;
using GameOfLife.Exec.Utilities;

namespace GameOfLife.Exec
{
    internal class Color
    {
        public RGB RGB { get; set; }
        public HSV HSV { get; set; }
        public CMYK CMYK { get; set; }

        public Color(byte r, byte g, byte b) => InitAsRGB(r, g, b);
        public Color(int h, float s, float v) => InitAsHSV(h, s, v);
        public Color(float c, float m, float y, float k) => InitAsCMYK(c, m, y, k);

        private void InitAsRGB(byte r, byte g, byte b)
        {
            RGB = new RGB(r, g, b);
            HSV = ConvertColor.RGBToHSV(RGB);
            CMYK = ConvertColor.RGBToCMYK(RGB);
        }
        private void InitAsHSV(int h, float s, float v)
        {
            HSV = new HSV(h, s, v);
            RGB = ConvertColor.HSVToRGB(HSV);
            CMYK = ConvertColor.HSVtoCMYK(HSV);
        }
        private void InitAsCMYK(float c, float m, float y, float k)
        {
            CMYK = new CMYK(c, m, y, k);
            RGB = ConvertColor.CMYKToRGB(CMYK);
            HSV = ConvertColor.CMYKToHSV(CMYK);
        }
    }
}