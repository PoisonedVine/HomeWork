using System;

namespace Task3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] AddressBook = new string[5, 2];

            AddressBook[0, 0] = "Вася";
            AddressBook[0, 1] = "+7123453246";

            AddressBook[1, 0] = "Петя";
            AddressBook[1, 1] = "Petya@mail.ru";

            AddressBook[2, 0] = "Коля";
            AddressBook[2, 1] = "+7923441341234";

            AddressBook[3, 0] = "Ваня";
            AddressBook[3, 1] = "Ivan@mail.ru";

            AddressBook[4, 0] = "Женя";
            AddressBook[4, 1] = "123133123123123";

            Console.WriteLine("Список контактов: ");
            for (int i = 0; i < AddressBook.GetLength(0); i++) {
                Console.WriteLine(AddressBook[i, 0]);
            }
            Console.WriteLine();
            Console.WriteLine("Введите имя контакта");
            {
                string CurContact = Console.ReadLine();
                for (int i = 0; i < AddressBook.GetLength(0); i++) {
                    if (AddressBook[i, 0] == CurContact) {
                        Console.WriteLine($"{AddressBook[i, 0]}: {AddressBook[i, 1]}");
                        return;
                    }
                }
                Console.WriteLine("Контакт не найден");
            }

        }
    }
}
