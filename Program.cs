using System;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Say your name");
            string Name = Console.ReadLine();
            Console.WriteLine($"Hello, {Name}. Today is {DateTime.UtcNow}");
        }
    }
}
