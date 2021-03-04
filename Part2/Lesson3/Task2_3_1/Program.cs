using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task2_3_1
{
    class Program
    {

        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        }


    }
    public class BechmarkClass 
    {
        public FloatPointClass[,] FloatClassArray { get; set; }
        public FloatPointStruct[,] FloatStructArray { get; set; }
        public DoublePointStruct[,] DoubleStructArray { get; set; }
        private const int _arraySize = 10000;

        public BechmarkClass() {
            FloatClassArray = new FloatPointClass[_arraySize, 2];
            FloatStructArray = new FloatPointStruct[_arraySize, 2];
            DoubleStructArray = new DoublePointStruct[_arraySize,2];

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
            for (int i = 0; i < FloatClassArray.GetLength(0); i++)
            {
                var FloatPointA = new FloatPointClass();
                FloatPointA.X = NextFloat(rand);
                FloatPointA.Y = NextFloat(rand);

                var FloatPointB = new FloatPointClass();
                FloatPointB.X = NextFloat(rand);
                FloatPointB.Y = NextFloat(rand);

                this.FloatClassArray[i, 0] = FloatPointA;
                this.FloatClassArray[i, 1] = FloatPointB;
            }
        }
        private void CreateFloatPointStructArray()
        {
            var rand = new Random();
            for (int i = 0; i < FloatStructArray.GetLength(0); i++)
            {
                var FloatPointA = new FloatPointStruct();
                FloatPointA.X = NextFloat(rand);
                FloatPointA.Y = NextFloat(rand);

                var FloatPointB = new FloatPointStruct();
                FloatPointB.X = NextFloat(rand);
                FloatPointB.Y = NextFloat(rand);

                this.FloatStructArray[i, 0] = FloatPointA;
                this.FloatStructArray[i, 1] = FloatPointB;
            }
        }
        private void CreateDoublePointStructArray()
        {
            var rand = new Random();
            for (int i = 0; i < DoubleStructArray.GetLength(0); i++)
            {
                var DoublePointA = new DoublePointStruct();
                DoublePointA.X = rand.NextDouble() * 10000;
                DoublePointA.Y = rand.NextDouble() * 10000;

                var DoublePointB = new DoublePointStruct();
                DoublePointB.X = rand.NextDouble() * 10000;
                DoublePointB.Y = rand.NextDouble() * 10000;

                this.DoubleStructArray[i, 0] = DoublePointA;
                this.DoubleStructArray[i, 1] = DoublePointB;
            }
        }
        [Benchmark]
        public void TestFloatPointClassDistanceCalc() 
        {
            for (int i = 0; i < FloatClassArray.GetLength(0); i++) 
            {
                PointDistanceFloatClassCalc(FloatClassArray[i, 0], FloatClassArray[i, 1]);
            }
        }
        [Benchmark]
        public void TestFloatPointStructDistanceCalc()
        {
            for (int i = 0; i < FloatStructArray.GetLength(0); i++)
            {
                PointDistanceFloatStructCalc(FloatStructArray[i, 0], FloatStructArray[i, 1]);
            }
        }
        [Benchmark]
        public void TestDoublePointStructDistanceCalc()
        {
            for (int i = 0; i < DoubleStructArray.GetLength(0); i++)
            {
                PointDistanceDoubleStructCalc(DoubleStructArray[i, 0], DoubleStructArray[i, 1]);
            }
        }
        [Benchmark]
        public void TestFloatPointStructDistanceWOSqrtCalc()
        {
            for (int i = 0; i < FloatStructArray.GetLength(0); i++)
            {
                PointDistanceFloatStructWOSqrtCalc(FloatStructArray[i, 0], FloatStructArray[i, 1]);
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
