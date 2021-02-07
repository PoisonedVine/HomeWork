using System;
using System.IO;

namespace Task5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string Delimeter = " ";
            string FileFolder = @"C:\test\";
            string FileName = "BinaryString.bin";

            Console.WriteLine($"Введите произвольный набор чисел от 0 до 255, разделенный символом '{Delimeter}'");
            string[] InputArray = Console.ReadLine().Split(Delimeter, StringSplitOptions.RemoveEmptyEntries);

            byte[] CurByte = new byte[InputArray.Length];
            int j = 0;

            //выкинем лишнее из ввода
            for (int i = 0; i < InputArray.Length; i++) {
                byte.TryParse(InputArray[i], out CurByte[j++]);                                 
            }
            if (Directory.Exists(FileFolder)) {
                File.WriteAllBytes(Path.Combine(FileFolder, FileName), CurByte);
            }
        }
    }
}
