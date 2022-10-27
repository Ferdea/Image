using System.Collections.Generic;

namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        private static List<(double, int, int)> GetPixelList(double[,] original)
        {
            var originalWidth = original.GetLength(0);
            var originalHeight = original.GetLength(1);
            var pixelList = new List<(double, int, int)>();
			
            for (var i = 0; i < originalWidth; i++)
            for (var j = 0; j < originalHeight; j++)
            {
                pixelList.Add((original[i, j], i, j));
            }
			
            pixelList.Sort();
            pixelList.Reverse();
            return pixelList;
        }

        private static double[,] GetThresholdFilter((int, int) resultSize, 
            List<(double, int, int)> pixelList, double whitePixelsFraction)
        {
            var pixelCount = pixelList.Count;
            var whiteCount = (int)(pixelCount * whitePixelsFraction);
            var threshold = whiteCount > 0 ? pixelList[whiteCount - 1].Item1 : 256.0;

            var result = new double[resultSize.Item1, resultSize.Item2];
            for (var i = 0; i < pixelCount; i++)
            {
                if (pixelList[i].Item1 >= threshold)
                    result[pixelList[i].Item2, pixelList[i].Item3] = 1.0;
                else
                    result[pixelList[i].Item2, pixelList[i].Item3] = 0.0;
            }
			
            return result;
        }
		
        public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
        {
            return GetThresholdFilter(
                (original.GetLength(0), original.GetLength(1)), 
                GetPixelList(original), 
                whitePixelsFraction
            );
        }
    }
}