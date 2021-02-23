using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2_2_2
{

    public class BinarySearchClass
    {
        public static int BinarySearch(int[] inputArray, int searchValue) //В текущей реализации - O(N + (Log N))
        {
            if (!ArrayIsSorted(inputArray)) { //O(N)
                return -1; //const
            }

            int min = 0; //const
            int max = inputArray.Length - 1; //const
            while (min <= max) //O(Log n)
            {
                int mid = (min + (max - min) / 2); //const
                if (searchValue == inputArray[mid]) //const
                {
                    return mid; //const
                }
                else if (searchValue < inputArray[mid]) //const
                {
                    max = mid - 1; //const
                }
                else
                {
                    min = mid + 1; //const
                }
            }
            return -1; //const
        }
        private static bool ArrayIsSorted(int[] inputArray) { //O(N)
            for (int i = 1; i < inputArray.Length; i++) {
                if (inputArray[i - 1] > inputArray[i]) {
                    return (false);
                }
            }
            return (true);
        
        }        
    }
}
