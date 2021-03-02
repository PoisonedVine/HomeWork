using System;

namespace Task2_1_3
{
    class Program
    {
        static long CalcFibRecursive( long[,] ValArray, int CurVal)
        {
            switch (CurVal)
            {
                case 0:
                    ValArray[Math.Abs(CurVal), 0] = CurVal;
                    ValArray[Math.Abs(CurVal), 1] = 0;
                    return(0);
                case 1:
                case -1:
                    CalcFibRecursive(ValArray, 0);
                    ValArray[Math.Abs(CurVal), 0] = CurVal;
                    ValArray[Math.Abs(CurVal), 1] = 1;
                    return(1);
            }
            int factor = (CurVal / Math.Abs(CurVal));

            if (CalcFibRecursive(ValArray, CurVal - factor) == 0) {
                return (0);
            }
            ValArray[Math.Abs(CurVal), 0] = CurVal;
            try
            {
                checked
                {
                    ValArray[Math.Abs(CurVal), 1] = ValArray[Math.Abs(CurVal) - 2, 1] + (factor * ValArray[Math.Abs(CurVal) - 1, 1]);
                }
            }
            catch (Exception ex) {
                //Console.WriteLine(ex.Message);
                return (0);
            }
            return (ValArray[Math.Abs(CurVal), 1]);

            }
        static long CalcFibCycle(int CurVal) {
            int factor = 1;
            if (CurVal != 0)
            {
                factor = (CurVal / Math.Abs(CurVal));
            }
            long[,] ValArray = new long[Math.Abs(CurVal) + 1, 2];

            for (int i = 0; i < ValArray.GetLength(0); i++) {
                switch (i) {
                    case 0:
                        ValArray[0, 0] = 0;
                        ValArray[0, 1] = 0;
                        break;
                    case  1:
                        ValArray[1, 0] = 1;
                        ValArray[1, 1] = 1;
                        break;
                    default:
                        {
                            ValArray[i, 0] = i;
                            try
                            {
                                checked { ValArray[i, 1] = ValArray[i - 2, 1] + (factor * ValArray[i - 1, 1]); }
                            }
                            catch (Exception ex) {
                                //Console.WriteLine(ex.Message);
                                return (0);
                            }
                            break;
                        }

                }
            }
            return (ValArray[Math.Abs(CurVal), 1]);
        }
        static void TestFunction() {
            
            // Тестовое покрытие
            int[,] TestArray = new int[21, 2];
            TestArray[0, 0] = -10; TestArray[0, 1] = -55;
            TestArray[1, 0] = -9; TestArray[1, 1] = 34;
            TestArray[2, 0] = -8; TestArray[2, 1] = -21;
            TestArray[3, 0] = -7; TestArray[3, 1] = 13;
            TestArray[4, 0] = -6; TestArray[4, 1] = -8;
            TestArray[5, 0] = -5; TestArray[5, 1] = 5;
            TestArray[6, 0] = -4; TestArray[6, 1] = -3;
            TestArray[7, 0] = -3; TestArray[7, 1] = 2;
            TestArray[8, 0] = -2; TestArray[8, 1] = -1;
            TestArray[9, 0] = -1; TestArray[9, 1] = 1;
            TestArray[10, 0] = 0; TestArray[10, 1] = 0;
            TestArray[11, 0] = 1; TestArray[11, 1] = 1;
            TestArray[12, 0] = 2; TestArray[12, 1] = 1;
            TestArray[13, 0] = 3; TestArray[13, 1] = 2;
            TestArray[14, 0] = 4; TestArray[14, 1] = 3;
            TestArray[15, 0] = 5; TestArray[15, 1] = 5;
            TestArray[16, 0] = 6; TestArray[16, 1] = 8;
            TestArray[17, 0] = 7; TestArray[17, 1] = 13;
            TestArray[18, 0] = 8; TestArray[18, 1] = 21;
            TestArray[19, 0] = 9; TestArray[19, 1] = 34;
            TestArray[20, 0] = 10; TestArray[20, 1] = 55;

            for (int i = 0; i < TestArray.GetLength(0); i++) {
                
                long[,] ValArray = new long[TestArray.GetLength(0), 2];
                long Recursive = CalcFibRecursive(ValArray, TestArray[i, 0]);

                long Cycle = CalcFibCycle(TestArray[i, 0]);
                long Correct = TestArray[i, 1];

                Console.WriteLine($"n = {TestArray[i,0]}; " +
                                  $"Рекурсивно = {Recursive} " +
                                  $"Циклом = {Cycle} " +
                                  $"Правильный = {TestArray[i,1]} " +
                                  $"Статус теста = {TestArray[i, 1] == Recursive && TestArray[i, 1] == Cycle}");
            }
            // некорректные значения
            {
                int TestVal = 100;

                long[,] ValArray = new long[TestVal+1, 2];
                long Recursive = CalcFibRecursive(ValArray, TestVal);

                long Cycle = CalcFibCycle(TestVal);
                long Correct = 0;
                Console.WriteLine($"n = {TestVal}; " +
                  $"Рекурсивно = {Recursive} " +
                  $"Циклом = {Cycle} " +
                  $"Правильный = {Correct} " +
                  $"Статус теста = {Correct == Recursive && Correct == Cycle}");
            }
        }
        static void Main(string[] args)
        {
            TestFunction();
            //Console.WriteLine(CalcFibCycle(20));
        }
    }
}
