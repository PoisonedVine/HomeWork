using System;

namespace Task2_1_2
{
    class Program
    {
        public static int StrangeSum(int[] inputArray) // O(N^3)
        {
            int sum = 0; //const
            for (int i = 0; i < inputArray.Length; i++) // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) //O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) // O(N)
                    {
                        int y = 0; //const

                        if (j != 0) //const
                        {
                            y = k / j; //const
                        }

                        sum += inputArray[i] + i + k + j + y; //const
                    }
                }
            }

            return sum; //const
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
