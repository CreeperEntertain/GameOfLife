using GameOfLife.Exec.Structs;

namespace GameOfLife.Exec.FunctionClasses.ImageManagement.ImageData
{
    internal class HSVRetrieve
    {
        public HSVRetrieve()
        {

        }

        public HSV[,] HSV2D(Image image)
        {
            Color[,] colorArray = image.pixel;
            HSV[,] hsvArray = new HSV[image.size[0], image.size[1]];
            for (int x = 0; x < colorArray.GetLength(0); x++)
                for (int y = 0; y < colorArray.GetLength(1); y++)
                    hsvArray[x, y] = colorArray[x, y].HSV;
            return hsvArray;
        }

        public int[,] Hue2D(Image image)
        {
            Color[,] colorArray = image.pixel;
            int[,] intArray = new int[image.size[0], image.size[1]];
            for (int x = 0; x < colorArray.GetLength(0); x++)
                for (int y = 0; y < colorArray.GetLength(1); y++)
                    intArray[x, y] = colorArray[x, y].HSV.H;
            return intArray;
        }
        public float[,] Saturation2D(Image image)
        {
            Color[,] colorArray = image.pixel;
            float[,] floatArray = new float[image.size[0], image.size[1]];
            for (int x = 0; x < colorArray.GetLength(0); x++)
                for (int y = 0; y < colorArray.GetLength(1); y++)
                    floatArray[x, y] = colorArray[x, y].HSV.S;
            return floatArray;
        }
        public float[,] Volume2D(Image image)
        {
            Color[,] colorArray = image.pixel;
            float[,] floatArray = new float[image.size[0], image.size[1]];
            for (int x = 0; x < colorArray.GetLength(0); x++)
                for (int y = 0; y < colorArray.GetLength(1); y++)
                    floatArray[x, y] = colorArray[x, y].HSV.V;
            return floatArray;
        }
    }
}