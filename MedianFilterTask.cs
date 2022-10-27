using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        private static double GetMedian(List<double> neighborhood)
        {
            var count = neighborhood.Count;
            neighborhood.Sort();
            if (count % 2 == 0)
                return (neighborhood[count / 2 - 1] + neighborhood[count / 2]) / 2;
            return neighborhood[count / 2];
        }
		
        public static double[,] MedianFilter(double[,] original)
        {
            var originalWidth = original.GetLength(0);
            var originalHeight = original.GetLength(1);
            var result = new double[originalWidth, originalHeight];
            var neighborhood = new List<double>();
            for (var i = 0; i < originalWidth; i++)
            for (var j = 0; j < originalHeight; j++)
            {
                for (var x = Math.Max(i - 1, 0); x < Math.Min(i + 2, originalWidth); x++)
                for (var y = Math.Max(j - 1, 0); y < Math.Min(j + 2, originalHeight); y++)
                {
                    neighborhood.Add(original[x, y]);
                }

                result[i, j] = GetMedian(neighborhood);
                neighborhood.Clear();
            }
            return result;
        }
    }
}