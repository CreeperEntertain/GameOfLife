using GameOfLife.Exec.Enums;
using GameOfLife.Exec.Structs;

namespace GameOfLife.Exec.Utilities
{
    internal static class ConvertColor
    {
        public static RGB HSVToRGB(HSV receivedColor)
            => new RGB();
        public static RGB CMYKToRGB(CMYK receivedColor)
            => new RGB();

        public static HSV RGBToHSV(RGB receivedColor)
            => new HSV();
        public static HSV CMYKToHSV(CMYK receivedColor)
            => new HSV();

        public static CMYK RGBToCMYK(RGB receivedColor)
            => new CMYK();
        public static CMYK HSVtoCMYK(HSV receivedColor)
            => new CMYK();
    }
}