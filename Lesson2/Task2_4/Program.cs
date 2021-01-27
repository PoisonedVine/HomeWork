using System;

namespace Task2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string BillName = "Кассовый чек. Приход";
            string Name1 = "Общество с ограниченной";
            string Name2 = @"Ответственностью ""Яндекс.Такси""";
            string Email = "taxi.yandex.ru";
            long VatRegNo = 7704340310;
            byte Shift = 170;
            DateTime Dt = new DateTime(21, 1, 17, 14, 33, 0);
            string Item = "Перевозка пассажиров";
            double Price = 120.05;
            int Qty = 2;            
            double Amount = Qty * Price;

            Console.WriteLine($"              Чек                    ");
            Console.WriteLine("**************************************");
            Console.WriteLine($"     {Name1.ToUpper()}");
            Console.WriteLine($"  {Name2.ToUpper()}");
            Console.WriteLine($"        {Email}");
            Console.WriteLine($"        ИНН: {VatRegNo}");
            Console.WriteLine("**************************************");
            Console.WriteLine($"     {BillName.ToUpper()}");
            Console.WriteLine("**************************************");
            Console.WriteLine($"Смена N {Shift}          {Dt.ToString("dd.MM.yy HH:mm")}");
            Console.WriteLine("**************************************");
            Console.WriteLine($"Наим. пр.         {Item}");
            Console.WriteLine($"Цена за ед. пр.             {Price} руб");
            Console.WriteLine($"Колич. пр.                           {Qty}");
            Console.WriteLine($"Сумма. пр.                       {Amount}");
            Console.WriteLine("______________________________________");
            Console.WriteLine($"ИТОГО                            {Amount}");

            Console.ReadLine();
        }
    }
}
