using GameOfLife.Exec.Enums;
using GameOfLife.Exec.Structs;
using GameOfLife.Exec.Utilities;

namespace GameOfLife.Exec
{
    internal class Color
    {
        public RGB RGB { get; set; }
        public HSV HSV { get; set; }
        public CMYK CMYK { get; set; }

        public Color(ColorType type = ColorType.RGB, byte value1 = 0, byte value2 = 0, byte value3 = 0, byte value4 = 0)
            => new Action[]
            {
                () => InitAsRGB(value1, value2, value3),
                () => InitAsHSV(value1, value2, value3),
                () => InitAsCMYK(value1, value2, value3, value4)
            }[(int)type]();

        private void InitAsRGB(byte r, byte g, byte b)
        {
            RGB = new RGB(r, g, b);
            HSV = ConvertColor.RGBToHSV(RGB);
            CMYK = ConvertColor.RGBToCMYK(RGB);
        }
        private void InitAsHSV(byte h, byte s, byte v)
        {
            HSV = new HSV(h, s, v);
            RGB = ConvertColor.HSVToRGB(HSV);
            CMYK = ConvertColor.HSVtoCMYK(HSV);
        }
        private void InitAsCMYK(byte c, byte m, byte y, byte k)
        {
            CMYK = new CMYK(c, m, y, k);
            RGB = ConvertColor.CMYKToRGB(CMYK);
            HSV = ConvertColor.CMYKToHSV(CMYK);
        }
    }
}