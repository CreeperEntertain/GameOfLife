using GameOfLife.Exec.Utilities;

namespace GameOfLife.Exec.Structs
{
    internal struct Color
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

        public Color(RGB rgb) => InitAsDirectRGB(rgb);
        public Color(HSV hsv) => InitAsDirectHSV(hsv);
        public Color(CMYK cmyk) => InitAsDirectCMYK(cmyk);

        private void InitAsDirectRGB(RGB rgb)
        {
            RGB = rgb;
            HSV = ConvertColor.RGBToHSV(rgb);
            CMYK = ConvertColor.RGBToCMYK(rgb);
        }
        private void InitAsDirectHSV(HSV hsv)
        {
            HSV = hsv;
            RGB = ConvertColor.HSVToRGB(hsv);
            CMYK = ConvertColor.HSVtoCMYK(hsv);
        }
        private void InitAsDirectCMYK(CMYK cmyk)
        {
            CMYK = cmyk;
            RGB = ConvertColor.CMYKToRGB(cmyk);
            HSV = ConvertColor.CMYKToHSV(cmyk);
        }

        public Color(string hexCode) => InitAsRGBHex(hexCode);

        private void InitAsRGBHex(string hexCode)
        {
            RGB rgb = new(hexCode);
            RGB = rgb;
            HSV = ConvertColor.RGBToHSV(rgb);
            CMYK = ConvertColor.RGBToCMYK(rgb);
        }
    }
}