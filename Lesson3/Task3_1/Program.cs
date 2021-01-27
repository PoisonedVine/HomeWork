using System;
using System.Text;

namespace Task3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            //определим размерность массива
            Random rand = new Random();
            int i = rand.Next(5, 10);
            int j = rand.Next(5, 10);

            //создадим массив и заполним его данными
            int[,] Matrix = new int[i, j];
            for (i = 0; i < Matrix.GetLength(0); i++) {
                for (j = 0; j < Matrix.GetLength(1); j++) {
                    Matrix[i, j] = rand.Next(1, 99);
                }
            }

            //Выведем диагональ
            int Shift = 0;
            for (i = 0; i < Matrix.GetLength(0) && i < Matrix.GetLength(1); i++) {
                sb.Append(' ', Shift).Append(Matrix[i, i]);
                sb.AppendLine();
                Shift += Matrix[i, i].ToString().Length;
            }
            Console.WriteLine(sb.ToString());

            //Выведем весь массив для проверки
            sb.Clear();
            Console.WriteLine("Исходный массив");
            for (i = 0; i < Matrix.GetLength(0); i++) {
                for (j = 0; j < Matrix.GetLength(1); j++) {                    
                    sb.AppendFormat("{0,2}", Matrix[i, j].ToString()).Append(' ');
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
