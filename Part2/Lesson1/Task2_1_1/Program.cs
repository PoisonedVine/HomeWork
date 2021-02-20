using System;

namespace Task2_1_1
{
    class Program
    {
        static bool IsPrimeNumber(int number) {
            int d = 0;
            int i = 2;

            while (i < number) {
                if (number % i == 0) {
                    d++;
                }
                i++;
            }
            return (d == 0);
        }
        static bool TestPrime(int number) {
            int[] TestPrimeNumbers = { 2, 3, 5, 7, 11 };  //ряд простых чисел для проверки
            for (int i = 0; i < TestPrimeNumbers.Length; i++) {
                if (number == TestPrimeNumbers[i]) {
                    return (true);
                }
            }
            return (false);
        }
        static void Main(string[] args)
        {
            for (int i = 2; i <= 11; i++) //тестовое покрытие. Ряд простых числе начинается с 2, все что меньше 2 по умолчанию не простое. 
            {
                Console.WriteLine($"Число {i} простое: {IsPrimeNumber(i)} Тестовое Значение: {TestPrime(i)}");
            }
            

        }
    }
}
