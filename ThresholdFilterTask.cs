using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        private static double[] GetPixelsArray(double[,] original)
        {
            var width = original.GetLength(0);
            var height = original.GetLength(1);
            var pixelsList = new List<double>();
            
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
            {
                pixelsList.Add(original[i, j]);
            }
            
            pixelsList.Sort();
            return pixelsList.ToArray();
        }

        private static double GetThreshold(double[] pixels, double whitePixelsFraction)
        {
            var whiteCount = (int)(whitePixelsFraction * pixels.Length);
            if (whiteCount == 0)
                return double.MaxValue;
            return pixels[pixels.Length - whiteCount];
        }

        public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
        {
            var width = original.GetLength(0);
            var height = original.GetLength(1);
            var threshold = GetThreshold(GetPixelsArray(original), whitePixelsFraction);
            var result = new double[width, height];
            
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
            {
                result[i, j] = original[i, j] >= threshold ? 1 : 0;
            }
            
            return result;
        }
    }
}