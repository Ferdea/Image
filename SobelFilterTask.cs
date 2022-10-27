using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var halfSxSize = sx.GetLength(0) / 2;
            var result = new double[width, height];
            for (int x = halfSxSize; x < width - halfSxSize; x++)
            for (int y = halfSxSize; y < height - halfSxSize; y++)
            {
                var gx = 0.0;
                var gy = 0.0;
                for (var i = -halfSxSize; i < halfSxSize + 1; i++)
                for (var j = -halfSxSize; j < halfSxSize + 1; j++)
                {
                    gx += g[x + i, y + j] * sx[i + halfSxSize, j + halfSxSize];
                    gy += g[x + i, y + j] * sx[j + halfSxSize, i + halfSxSize];
                }
                result[x, y] = Math.Sqrt(gx * gx + gy * gy);
            }
            return result;
        }
    }
}