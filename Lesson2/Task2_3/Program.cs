using System;

namespace Task2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string tempStr;
            long CurVal;

            Console.WriteLine("Введите целое число");
            tempStr = Console.ReadLine();

            if (!long.TryParse(tempStr, out CurVal)) {
                Console.WriteLine("Ошибка! Это не целое число");
                return;
            }
            
            if (CurVal % 2 == 0) {
                Console.WriteLine($"Число {CurVal} четное");
            } else {
                Console.WriteLine($"Число {CurVal} нечетное");
            }
        }
    }
}
