using System;

namespace Task3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string CurString;
            int j = 0;
                        
            Console.WriteLine("Введите произвольную строку");
            CurString = Console.ReadLine();
            char[] NewString = new char[CurString.Length];

            Console.WriteLine();
            for (int i = CurString.Length-1; i >= 0; i--) {
                NewString[j] = CurString[i];
                j++;
            }
            Console.WriteLine(NewString);
        }
    }
}
