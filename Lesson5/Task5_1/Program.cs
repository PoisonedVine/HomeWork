using System;
using System.IO;

namespace Task5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileFolder = @"C:\test\";
            string FileName = "test.txt";
            
            
            if (Directory.Exists(FileFolder))
            {
                Console.WriteLine("Введите произвольный набор данных:");
                File.WriteAllText(Path.Combine(FileFolder,FileName), Console.ReadLine());
            }
            else 
            {
                Console.WriteLine($"Путь {FileFolder} не существует");
            }
            

        }
    }
}
