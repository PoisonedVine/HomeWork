using System;

namespace Task2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal MinTemp = 0;
            decimal MaxTemp = 0;

            {
                Console.WriteLine("Введите минимальную температуру за сутки");
                string tempStr = Console.ReadLine();
                if (!decimal.TryParse(tempStr, out MinTemp))
                {
                    Console.WriteLine("Ошибка! Необходимо указать число");
                    return;
                }

            }
            {
                Console.WriteLine("Введите максимальную температуру за сутки");
                string tempStr = Console.ReadLine();
                if (!decimal.TryParse(tempStr, out MaxTemp))
                {
                    Console.WriteLine("Ошибка! Необходимо указать число");
                    return;
                }

            }
            Console.WriteLine($"Средняя температура за сутки {(MinTemp + MaxTemp)/2}");
        }
    }
}
