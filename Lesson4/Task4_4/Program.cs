using System;

namespace Task4_4
{
    class Program
    {
        static int CalcFib(int CurVal)
        {
            switch (CurVal)
            {
                case 0: return (0);
                case 1: return (1);
            }
            int factor = CurVal / Math.Abs(CurVal);

            return (CalcFib(CurVal - (factor * 2)) + (factor * CalcFib(CurVal - factor)));
        }
        static void CalcFibMatrix(ref int[,] ValArray, int CurVal)
        {
            switch (CurVal)
            {
                case 0:
                    ValArray[Math.Abs(CurVal), 0] = CurVal;
                    ValArray[Math.Abs(CurVal), 1] = 0;
                    return;
                case 1:
                case -1:
                    CalcFibMatrix(ref ValArray, 0);
                    ValArray[Math.Abs(CurVal), 0] = CurVal;
                    ValArray[Math.Abs(CurVal), 1] = 1;
                    return;
            }
            int factor = CurVal / Math.Abs(CurVal);
            CalcFibMatrix(ref ValArray, CurVal - factor);
            ValArray[Math.Abs(CurVal), 0] = CurVal;
            ValArray[Math.Abs(CurVal), 1] = ValArray[Math.Abs(CurVal) - 2, 1] + (factor * ValArray[Math.Abs(CurVal) - 1, 1]);
        }

        static void Main(string[] args)
        {

            int InputVal;
            Console.WriteLine("Введите значение для расчета числа фибоначчи"); // работает и в +, и в -
            if (!int.TryParse(Console.ReadLine(), out InputVal))
            {
                Console.WriteLine("Введите целое число");
                return;
            }
            //Расчет в лоб. Слишком много рекурсии
            //Console.WriteLine($"Число Фибоначчи: {CalcFib(InputVal)}");

            //расчет через матрицу. Только один проход по рекурсии
            int[,] ValArray = new int[Math.Abs(InputVal) + 1, 2];
            CalcFibMatrix(ref ValArray, InputVal);
            Console.WriteLine($"Число Фибоначчи: {ValArray[ValArray.GetLength(0) - 1, 1]}");

            // Проверка расчета матрицы
            /*
            for (int i = 0; i < ValArray.GetLength(0); i++) {
                Console.WriteLine(String.Format("n = {0,3}; {1,10}", ValArray[i, 0], ValArray[i, 1]));
            }
            */
        }
    }
}
