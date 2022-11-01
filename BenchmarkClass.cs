using System;
using NUnit.Framework;

namespace Recognizer
{
    public class BenchmarkClass
    {
        public static void SomeMethodVer1(double[,] image)
        {
            image.GetLength(0);
            image.GetLength(1);
            for (var i = 0; i < 10000; i++)
            for (var j = 0; j < 10000; j++)
            {
                
            }
        }
        
        public static void SomeMethodVer2(double[,] image)
        {
            for (var i = 0; i < 10000; i++)
            for (var j = 0; j < 10000; j++)
            {
                image.GetLength(0);
                image.GetLength(1);
            }
        }

        private static int GetLength(double[,] image, int index)
        {
            return image.GetLength(index);
        }

        public static void SomeMethodVer3(double[,] image)
        {
            GetLength(image, 0);
            GetLength(image, 1);
            for (var i = 0; i < 10000; i++)
            for (var j = 0; j < 10000; j++)
            {
                
            }
        }
    }
}