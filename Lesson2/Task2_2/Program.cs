using System;

namespace Task2_2
{
    class Program
    {
        enum Months
        {      
            Январь = 1,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октбярь,
            Ноябрь,
            Декабрь
        }
        static void Main(string[] args)
        {
            int Month_Num = 0;
            string Month_NumStr;

            Console.WriteLine("Введите порядковый номер месяца");
            Month_NumStr = Console.ReadLine();
            if (!int.TryParse(Month_NumStr, out Month_Num) || (Month_Num < 1 || Month_Num > 12)) {
                Console.WriteLine("Введите число от 1 до 12");
                return;
            }
            Months CurMonth = (Months)Month_Num;
            Console.WriteLine($"Выбран месяц : {CurMonth}");
        }
    }
}
