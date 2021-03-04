using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace Benchmark
{
    public class PointClassFloat
    {
        public float X;
        public float Y;
    }

    public struct PointStructFloat
    {
        public float X;
        public float Y;
    }

    public struct PointStructDouble
    {
        public double X;
        public double Y;
    }

    public struct PointStructFloatWithoutSqrt
    {
        public float X;
        public float Y;
    }


    class Program
    {

        static void Main(string[] args)
        {
            Random random = new Random();

            for (int i = 0; i < BechmarkClass.myArray.Length; i++)
            {
                BechmarkClass.myArray[i] = random.Next(1000);
                //Console.WriteLine(BechmarkClass.myArray[i]);
            }

            for (int i = 0; i < BechmarkClass.floatArray.Length; i++)
            {
                BechmarkClass.floatArray[i] = (float)random.NextDouble();
            }

            for (int i = 0; i < BechmarkClass.floatArray.Length; i++)
            {
                BechmarkClass.doubleArray[i] = random.NextDouble();
            }


            //Для проверки (себя)
            //for (int i = 0; i <= 3; i++)
            //{
            //    var pointOneFloat = new PointClassFloat() { X = BechmarkClass.myArray[i], Y = BechmarkClass.myArray[i + 1] }; //{ X = floatArray[i], Y = floatArray[i] };
            //    var pointTwoFloat = new PointClassFloat() { X = BechmarkClass.myArray[i + 2], Y = BechmarkClass.myArray[i + 3] };  //{ X = floatArray[i + 1], Y = floatArray[i + 1] };
            //    var result = BechmarkClass.PointDistanceClass(pointOneFloat, pointTwoFloat);
            //    Console.WriteLine(result);

            //}


            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    public class BechmarkClass
    {
        public static int n = 50;
        public static int[] myArray = new int[n];
        public static float[] floatArray = new float[n];
        public static double[] doubleArray = new double[n];
        public static float PointDistanceClass(PointClassFloat pointOne, PointClassFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceStruct(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double PointDistanceDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceWithoutSqrt(PointStructFloatWithoutSqrt pointOne, PointStructFloatWithoutSqrt pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }


        [Benchmark]
        public void TestPointStructDistanceFloat()
        {

            for (int i = 0; i <= 5; i++)
            {
                //var pointOneFloat = new PointClassFloat() { X = myArray[i], Y = myArray[i + 1] };
                //var pointTwoFloat = new PointClassFloat() { X = myArray[i + 2], Y = myArray[i + 3] };
                var pointOneFloat = new PointClassFloat() { X = floatArray[i], Y = floatArray[i + 1] };
                var pointTwoFloat = new PointClassFloat() { X = floatArray[i + 2], Y = floatArray[i + 3] };
                PointDistanceClass(pointOneFloat, pointTwoFloat);
            }

        }

        [Benchmark]
        public void TestPointClassDistanceFloat()
        {

            for (int i = 0; i <= 5; i++)
            {
                //var pointOneFloat = new PointStructFloat() { X = myArray[i], Y = myArray[i + 1] };
                //var pointTwoFloat = new PointStructFloat() { X = myArray[i + 2], Y = myArray[i + 3] };
                var pointOneFloat = new PointStructFloat() { X = floatArray[i], Y = floatArray[i + 1] };
                var pointTwoFloat = new PointStructFloat() { X = floatArray[i + 2], Y = floatArray[i + 3] };
                PointDistanceStruct(pointOneFloat, pointTwoFloat);
            }
        }

        [Benchmark]
        public void TestPointStructDistanceDouble()
        {

            for (int i = 0; i <= 5; i++)
            {
                //var pointOneDouble = new PointStructDouble() { X = myArray[i], Y = myArray[i + 1] };
                //var pointTwoDouble = new PointStructDouble() { X = myArray[i + 2], Y = myArray[i + 3] };
                var pointOneDouble = new PointStructDouble() { X = doubleArray[i], Y = doubleArray[i + 1] };
                var pointTwoDouble = new PointStructDouble() { X = doubleArray[i + 2], Y = doubleArray[i + 3] };
                PointDistanceDouble(pointOneDouble, pointTwoDouble);
            }

        }

        [Benchmark]
        public void TestPointStructDistanceFloatWithoutSqrt()

        {
            for (int i = 0; i <= 5; i++)
            {
                //var pointOneFloat = new PointStructFloatWithoutSqrt() { X = myArray[i], Y = myArray[i + 1] };
                //var pointTwoFloat = new PointStructFloatWithoutSqrt() { X = myArray[i + 2], Y = myArray[i + 3] };
                var pointOneFloat = new PointStructFloatWithoutSqrt() { X = floatArray[i], Y = floatArray[i + 1] };
                var pointTwoFloat = new PointStructFloatWithoutSqrt() { X = floatArray[i + 2], Y = floatArray[i + 3] };
                PointDistanceWithoutSqrt(pointOneFloat, pointTwoFloat);
            }
        }

    }
}