using System;

namespace Task4_1
{
    class Program
    {
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return ($"{lastName} {firstName} {patronymic}");
        }
        static void FillDict(ref string[][] Dict)
        {
            string[] Questions = { "Введите имя", "Введите фамилию", "Введите отчество" };


            for (int i = 0; i < Dict.Length; i++)
            {
                Console.WriteLine("Заполнение справочника. Для выхода нажмите 0");
                Console.WriteLine($"Заполнено {i} значений из {Dict.Length}");
                Dict[i] = new string[3];

                for (int j = 0; j < Questions.Length; j++)
                {
                    Console.WriteLine(Questions[j]);
                    string input;
                    do
                    {
                        input = Console.ReadLine();
                    } while (String.IsNullOrEmpty(input));

                    if (input == "0")
                    {
                        Dict[i] = new string[3];
                        return;
                    }
                    Dict[i][j] = input;
                }
                Console.Clear();
            }

        }
        static void PrintDict(ref string[][] Dict)
        {
            for (int i = 0; i < Dict.Length; i++)
            {
                if (String.IsNullOrEmpty(Dict[i][0]))
                    return;
                Console.WriteLine(GetFullName(Dict[i][0], Dict[i][1], Dict[i][2]));
            }
        }
        static void InitDict(ref string[][] Dict, int DictRecSize)
        {
            for (int i = 0; i < Dict.Length; i++)
            {
                Dict[i] = new string[DictRecSize];
            }
        }
        static void Main(string[] args)
        {
            int DictSize = 4;
            int DictRecSize = 3;
            string[][] Dict = new string[DictSize][];

            InitDict(ref Dict, DictRecSize);
            FillDict(ref Dict);
            PrintDict(ref Dict);


        }
    }
}
