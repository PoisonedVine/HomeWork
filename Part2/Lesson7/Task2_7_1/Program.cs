using System;
using System.Text;

namespace Task2_7_1
{
    /*
        Simple way matrix example
        +---+---+---+---+---+---+
        |  1|  1|  1|  1|  1|  1|
        +---+---+---+---+---+---+
        |  1|  2|  3|  4|  5|  6|
        +---+---+---+---+---+---+
        |  1|  3|  6| 10| 15| 21|
        +---+---+---+---+---+---+
        |  1|  4| 10| 20| 35| 56|
        +---+---+---+---+---+---+
        |  1|  5| 15| 35| 70|126|
        +---+---+---+---+---+---+
        |  1|  6| 21| 56|126|252|
        +---+---+---+---+---+---+

        Way matrix with blocks example
        +--+--+--+--+--+--+
        | 1| 1| 1| 1| 1| 1|
        +--+--+--+--+--+--+
        | 1| 0| 0| 1| 2| 3|
        +--+--+--+--+--+--+
        | 1| 1| 1| 0| 2| 5|
        +--+--+--+--+--+--+
        | 1| 2| 3| 3| 5|10|
        +--+--+--+--+--+--+
        | 1| 3| 6| 9|14|24|
        +--+--+--+--+--+--+
        | 1| 4|10|19|33|57|
        +--+--+--+--+--+--+
     */
    class Program
    {
        const int N = 6;
        const int M = 6;
        const int BlockCount = 4;

        private static void PrintField(int[,] field)
        {
            int maxValueLength = field[field.GetLength(0) - 1, field.GetLength(1) - 1].ToString().Length;
            var sb = new StringBuilder();

            for (int i = 0; i < field.GetLength(0); i++)
            {
                AddDelimeterString(sb, maxValueLength, field.GetLength(0));
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    sb.Append('|').Append(FormatValue(field[i, j], maxValueLength));
                }
                sb.Append('|').Append("\r\n");
            }
            AddDelimeterString(sb, maxValueLength, field.GetLength(0));
            Console.WriteLine(sb.ToString());
        }
        private static void AddDelimeterString(StringBuilder sb, int valueLength, int elemCount)
        {
            for (int i = 0; i < elemCount; i++)
            {
                sb.Append('+').Append('-', valueLength);
            }
            sb.Append('+').Append("\r\n");
        }
        private static string FormatValue(int value, int valueLength)
        {
            string retVal = "";
            int _shift = valueLength - value.ToString().Length;
            for (int i = 0; i < _shift; i++)
            {
                retVal += ' ';
            }
            retVal += value.ToString();
            return (retVal);
        }
        static void SimpleRootMatrix()
        {
            int[,] field = new int[N, M];
            for (int j = 0; j < field.GetLength(1); j++)
            {
                field[0, j] = 1;
            }
            for (int i = 1; i < field.GetLength(0); i++)
            {
                field[i, 0] = 1;
                for (int j = 1; j < field.GetLength(1); j++)
                {
                    field[i, j] = field[i - 1, j] + field[i, j - 1];
                }
            }
            PrintField(field);
        }
        static void RootMatrixWithBlocks()
        {
            int[,] map = new int[N, M];
            CreateMap(map);
            int[,] field = new int[N, M];
            for (int j = 0; j < field.GetLength(1); j++)
            {
                field[0, j] = 1;
            }
            for (int i = 1; i < field.GetLength(0); i++)
            {
                field[i, 0] = 1;
                for (int j = 1; j < field.GetLength(1); j++)
                {
                    if (map[i, j] == -1)
                    {
                        field[i, j] = 0;
                    }
                    else
                    {
                        field[i, j] = field[i - 1, j] + field[i, j - 1];
                    }
                }
            }
            PrintField(field);
        }
        private static void CreateMap(int[,] map)
        {
            var rand = new Random();
            for (int i = 0; i < BlockCount; i++)
            {
                int x = rand.Next(1, map.GetLength(0) - 2);
                int y = rand.Next(1, map.GetLength(1) - 2);
                map[x, y] = -1;
            }
        }
        static void Main(string[] args)
        {
            SimpleRootMatrix();
            RootMatrixWithBlocks();
        }
    }
}
