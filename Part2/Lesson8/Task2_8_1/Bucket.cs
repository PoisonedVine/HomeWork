using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8_1
{
    public class Bucket : IBucket
    {
        private int Position { get; set; }
        private int[] Values { get; set; }
        private int BucketSize { get; set; }
        
        public Bucket(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Values = new int[size];
            Position = 0;
            BucketSize = size;
        }
        public Bucket()
        {
            Position = 0;
        }
        public void SetSize(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Values = new int[size];
            BucketSize = size;
        }
        public void SetFirst()
        {
            Position = 0;
        }
        public int GetValue()
        {
            return (Values[Position]);
        }
        public bool MoveNext() 
        {
            if (Position + 1 > Values.Length - 1)
            {
                return false;
            }
            Position++;
            return true;
        }
        public bool AddValue(int value) 
        {
            if (Position + 1 > BucketSize)
            {
                return false;
            }
            Values[Position++] = value;
            return true;
        }
        public void Sort()
        {
            MergeSort(Values, 0, Values.Length - 1);
        }
        public IBucket Clone()
        {
            return (new Bucket(BucketSize));
        }
        public override bool Equals(object obj)
        {
            var bucket = (Bucket)obj;
            if (bucket is null)
            {
                return false;
            }
            bucket.SetFirst();
            int test = bucket.GetValue();

            for (int i = 0; i < BucketSize; i++)
            {
                test ^= Values[i];
                if (bucket.MoveNext())
                { 
                    test ^= bucket.GetValue();
                }                               
            }
            return test == 0;            
        }
        public void Clear()
        {
            Values = null;
        }
        private void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }
        private int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                if (highIndex - lowIndex == 1)
                {
                    if (array[highIndex] < array[lowIndex])
                    {
                        var t = array[lowIndex];
                        array[lowIndex] = array[highIndex];
                        array[highIndex] = t;
                    }
                }
                else
                {
                    var middleIndex = (lowIndex + highIndex) / 2;
                    MergeSort(array, lowIndex, middleIndex);
                    MergeSort(array, middleIndex + 1, highIndex);
                    Merge(array, lowIndex, middleIndex, highIndex);
                }
            }

            return array;
        }
    }
}
