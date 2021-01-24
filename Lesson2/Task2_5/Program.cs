using System;

namespace Task2_5
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
        static private int GetMonth() {
            int Month_Num = 0;
            string Month_NumStr;

            Console.WriteLine("Введите порядковый номер месяца");
            Month_NumStr = Console.ReadLine();
            if (!int.TryParse(Month_NumStr, out Month_Num) || (Month_Num < 1 || Month_Num > 12))
            {
                Console.WriteLine("Введите число от 1 до 12");
                return(0);
            }
            Months CurMonth = (Months)Month_Num;
            Console.WriteLine($"Выбран месяц : {CurMonth}");
            return (Month_Num);

        }
        static private decimal GetAvgTemp() {
            //Определение средней температуры
            //Т.к. не интересна температура <= 0, то в качестве ошибки можно вернуть 0
            decimal MinTemp = 0;
            decimal MaxTemp = 0;

            {
                Console.WriteLine("Введите минимальную температуру за сутки");
                string tempStr = Console.ReadLine();
                if (!decimal.TryParse(tempStr, out MinTemp))
                {
                    Console.WriteLine("Ошибка! Необходимо указать число");
                    return(0);
                }

            }
            {
                Console.WriteLine("Введите максимальную температуру за сутки");
                string tempStr = Console.ReadLine();
                if (!decimal.TryParse(tempStr, out MaxTemp))
                {
                    Console.WriteLine("Ошибка! Необходимо указать число");
                    return(0);
                }

            }
            {
                decimal tmpAvgTemp = (MinTemp + MaxTemp) / 2;
                Console.WriteLine($"Средняя температура за сутки = {tmpAvgTemp}");
                return (tmpAvgTemp);
            }
        }
        static void Main(string[] args)
        {
            int CurMonth = GetMonth();

            if (CurMonth == 0)
            {
                return;
            }

            decimal AvgTemp = GetAvgTemp();

            if (AvgTemp > 0){
                switch (CurMonth) {
                    case 1:
                    case 11:
                    case 12: 
                        Console.WriteLine("Дождливая зима");
                        break;
                }
                
            }
            
        }
    }
}
