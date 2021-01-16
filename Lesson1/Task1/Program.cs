using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Введите имя");
            string Name = Console.ReadLine();
            Console.WriteLine($"Привет, {Name}, сегодня {DateTime.Today.ToString("dd.MM.yyyy")}");
        }
    }
}
