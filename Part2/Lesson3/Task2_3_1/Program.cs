using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task2_3_1
{
    class Program
    {

        /*
        |                                  Method |       Mean |      Error |     StdDev |
        | --------------------------------------- | ----------:| ----------:| ----------:|
        | TestFloatPointClassDistanceCalc         | 10.220 us  | 0.1224 us  | 0.1085 us  |
        | TestFloatPointStructDistanceCalc        | 7.630 us   | 0.1436 us  | 0.1344 us  |
        | TestDoublePointStructDistanceCalc       | 8.102 us   | 0.1616 us  | 0.1985 us  |
        | TestFloatPointStructDistanceWOSqrtCalc  | 7.512 us   | 0.0726 us  | 0.0679 us  |
        */

        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }


    }
    public class BechmarkClass 
    {
        public FloatPointClass[] FloatClassArray { get; set; }
        public FloatPointStruct[] FloatStructArray { get; set; }
        public DoublePointStruct[] DoubleStructArray { get; set; }
        private const int _arraySize = 10000;

        public BechmarkClass() {
            FloatClassArray = new FloatPointClass[_arraySize];
            FloatStructArray = new FloatPointStruct[_arraySize];
            DoubleStructArray = new DoublePointStruct[_arraySize];

            CreateDoublePointStructArray();
            CreateFloatPointClassArray();
            CreateFloatPointStructArray();
        }
        private float NextFloat(Random random)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }
        private float PointDistanceFloatClassCalc(FloatPointClass pointOne, FloatPointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        private float PointDistanceFloatStructCalc(FloatPointStruct pointOne, FloatPointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        private double PointDistanceDoubleStructCalc(DoublePointStruct pointOne, DoublePointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        private float PointDistanceFloatStructWOSqrtCalc(FloatPointStruct pointOne, FloatPointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return ((x * x) + (y * y));
        }
        private void CreateFloatPointClassArray()
        {
            var rand = new Random();
            int i = 0;
            while(i < FloatClassArray.Length)
            {
                var FloatPointA = new FloatPointClass();
                FloatPointA.X = NextFloat(rand);
                FloatPointA.Y = NextFloat(rand);

                var FloatPointB = new FloatPointClass();
                FloatPointB.X = NextFloat(rand);
                FloatPointB.Y = NextFloat(rand);

                FloatClassArray[i++] = FloatPointA;
                FloatClassArray[i++] = FloatPointB;
            }
        }
        private void CreateFloatPointStructArray()
        {
            var rand = new Random();
            int i = 0;
            while(i < FloatStructArray.Length)
            {
                var FloatPointA = new FloatPointStruct();
                FloatPointA.X = NextFloat(rand);
                FloatPointA.Y = NextFloat(rand);

                var FloatPointB = new FloatPointStruct();
                FloatPointB.X = NextFloat(rand);
                FloatPointB.Y = NextFloat(rand);

                FloatStructArray[i++] = FloatPointA;
                FloatStructArray[i++] = FloatPointB;
            }
        }
        private void CreateDoublePointStructArray()
        {
            var rand = new Random();
            int i = 0;
            while (i < DoubleStructArray.Length)
            {
                var DoublePointA = new DoublePointStruct();
                DoublePointA.X = rand.NextDouble() * 10000;
                DoublePointA.Y = rand.NextDouble() * 10000;

                var DoublePointB = new DoublePointStruct();
                DoublePointB.X = rand.NextDouble() * 10000;
                DoublePointB.Y = rand.NextDouble() * 10000;

                DoubleStructArray[i++] = DoublePointA;
                DoubleStructArray[i++] = DoublePointB;
            }
        }
        [Benchmark]
        public void TestFloatPointClassDistanceCalc() 
        {
            int i = 0;
            while (i < FloatClassArray.Length)
            {
                PointDistanceFloatClassCalc(FloatClassArray[i++], FloatClassArray[i++]);
            }
        }
        [Benchmark]
        public void TestFloatPointStructDistanceCalc()
        {
            int i = 0;
            while (i < FloatStructArray.Length)
            {
                PointDistanceFloatStructCalc(FloatStructArray[i++], FloatStructArray[i++]);
            }
        }
        [Benchmark]
        public void TestDoublePointStructDistanceCalc()
        {
            int i = 0;
            while (i < DoubleStructArray.Length)
            {
                PointDistanceDoubleStructCalc(DoubleStructArray[i++], DoubleStructArray[i++]);
            }
        }
        [Benchmark]
        public void TestFloatPointStructDistanceWOSqrtCalc()
        {
            int i = 0;
            while (i < FloatStructArray.Length)
            {
                PointDistanceFloatStructWOSqrtCalc(FloatStructArray[i++], FloatStructArray[i++]);
            }
        }
    }
    public class FloatPointClass
    {
        public float X;
        public float Y;
    }

    public struct FloatPointStruct
    {
        public float X;
        public float Y;
    }
    public struct DoublePointStruct
    {
        public double X;
        public double Y;
    }
}
