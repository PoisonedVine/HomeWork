using System;

namespace Task2_6
{
    class Program
    {
        [Flags]
        enum DayOfWeek { 
            понедельник     = 0b_0000001,
            вторник         = 0b_0000010,
            среда           = 0b_0000100,
            четверг         = 0b_0001000,
            пятница         = 0b_0010000,
            суббота         = 0b_0100000,
            воскресенье     = 0b_1000000
        }
        static void Main(string[] args)
        {
            // Запросить у пользователя день недели и проверить работают ли офисы в этот день.
            
            DayOfWeek CurDay = 0;
            DayOfWeek CurDayMask = 0;

            DayOfWeek OfficeA = DayOfWeek.понедельник | DayOfWeek.вторник | DayOfWeek.среда | DayOfWeek.четверг | DayOfWeek.пятница;
            DayOfWeek OfficeB = DayOfWeek.среда | DayOfWeek.четверг | DayOfWeek.пятница | DayOfWeek.суббота | DayOfWeek.воскресенье;

            Console.WriteLine("Введите день недели на русском языке");
            string CurDayStr = Console.ReadLine();

            if (Enum.TryParse<DayOfWeek>(CurDayStr.ToLower(), out CurDay))
            {
                if (!(Enum.IsDefined(typeof(DayOfWeek), CurDay)))
                {
                    Console.WriteLine("Ошибка! Это не день недели.");
                    return;
                }
                CurDayMask = CurDay & OfficeA;
                bool OfficeAOpen = (CurDay == CurDayMask);

                CurDayMask = CurDay & OfficeB;
                bool OfficeBOpen = (CurDay == CurDayMask);

                Console.WriteLine($"Текущий день: {CurDay}.");
                if (OfficeAOpen)
                    Console.WriteLine("Офис А открыт");
                else
                    Console.WriteLine("Офис А закрыт");

                if (OfficeBOpen)
                    Console.WriteLine("Офис Б открыт");
                else
                    Console.WriteLine("Офис Б закрыт");

                Console.WriteLine($"Дни работы офиса А: {OfficeA}");
                Console.WriteLine($"Дни работы офиса Б: {OfficeB}");
                Console.ReadLine();
            }else
                Console.WriteLine("Ошибка! Это не день недели.");
        }
    }
}
