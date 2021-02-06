using System;
using System.Text;

namespace Task4_2
{
    class Program
    {
        static void CreateValuesArray(string Delimiter, out string[] ValuesArray) {
            Console.WriteLine($"Введите строку - набор чисел, разделенных символом(-ами): '{Delimiter}'");
            ValuesArray = Console.ReadLine().Split(Delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
        static int SumValuesArray(ref string[] ValArray, out string[,] StatisticArray) { //Для самопроверки. Название переменной разные, но содержат ссылку на один и тот же массив
            int RetVal = 0;
            StatisticArray = new string[ValArray.Length, 2]; //Исключительно для красивого вывода :) 

            for (int i = 0; i < ValArray.Length; i++) {
                int CurVal = 0;
                StatisticArray[i, 0] = ValArray[i]; // Что было
                if (int.TryParse(ValArray[i], out CurVal))
                {
                    RetVal += CurVal;
                    StatisticArray[i, 1] = CurVal.ToString(); //Что получилось
                }
                else 
                {
                    StatisticArray[i, 1] = "Not defined";
                }
            }
            return (RetVal);           
        }
        static void PrintResult(ref string[,] StatisticArray, int Sum) {           
            for (int i = 0; i < StatisticArray.GetLength(0); i++) {
                Console.WriteLine(String.Format("{0,-11} -> {1,11}",StatisticArray[i,0],StatisticArray[i,1]));    
            }
            Console.WriteLine(String.Format("{0,-11}    {1,11}", "Сумма", Sum));
        }
        static void Main(string[] args)
        {
            string Delimiter = " ";
            CreateValuesArray(Delimiter, out string[] ValuesArray);
            int Sum = SumValuesArray(ref ValuesArray, out string[,] StatisticArray);
            PrintResult(ref StatisticArray, Sum);

        }
    }
}
