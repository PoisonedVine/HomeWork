using System;

namespace Task4_3
{
    class Program
    {
        [Flags]
        enum Season
        {
            Winter,
            Spring,
            Summer,
            Autumn
        }
        enum Months
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
        static string SeasonTranslate(Season CurSeason)
        {
            switch (CurSeason)
            {
                case Season.Winter: return ("зима");
                case Season.Spring: return ("весна");
                case Season.Summer: return ("лето");
                case Season.Autumn: return ("осень");
                default: return ("not defined");
            }
        }
        static void PrintSeason(string input)
        {
            int CurMonthNum;
            if (!int.TryParse(input, out CurMonthNum) || !Enum.IsDefined(typeof(Months), CurMonthNum))
            {
                Console.WriteLine("Введите число от 1 до 12");
                return;
            }
            Console.WriteLine($"Выбран месяц: {(Months)CurMonthNum}"); ;
            switch (CurMonthNum)
            {
                case 1:
                case 2:
                case 12: Console.WriteLine($"Сезон: {SeasonTranslate(Season.Winter)}"); break;
                case 3:
                case 4:
                case 5: Console.WriteLine($"Сезон: {SeasonTranslate(Season.Spring)}"); break;
                case 6:
                case 7:
                case 8: Console.WriteLine($"Сезон: {SeasonTranslate(Season.Summer)}"); break;
                case 9:
                case 10:
                case 11: Console.WriteLine($"Сезон: {SeasonTranslate(Season.Autumn)}"); break;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер месяца");
            PrintSeason(Console.ReadLine());
        }
    }
}
