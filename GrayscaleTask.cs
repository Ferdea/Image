namespace Recognizer
{
    public static class GrayscaleTask
    {
        public static double[,] ToGrayscale(Pixel[,] original)
        {
            var originalWidth = original.GetLength(0);
            var originalHeight = original.GetLength(1);
            var result = new double[originalWidth, originalHeight];
            for (var i = 0; i < originalWidth; i++)
            {
                for (var j = 0; j < originalHeight; j++)
                {
                    var pixel = original[i, j];
                    result[i, j] = (0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B) / 255;
                }
            }

            return result;
        }
    }
}