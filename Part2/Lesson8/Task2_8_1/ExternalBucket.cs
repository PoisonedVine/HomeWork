using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8_1
{
    public class ExternalBucket: IBucket
    {
        private string FileName { get; set; }
        private int Position { get; set; }
        private int LineCount { get; set; }
        private int BucketSize { get; set; }
        private int Value { get; set; }

        public ExternalBucket(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            FileName = Path.GetTempFileName();
            Position = 0;
            BucketSize = size;
        }
        public ExternalBucket()
        {
            FileName = Path.GetTempFileName();
            Position = 0;
        }
        public void SetSize(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            BucketSize = size;
        }
        public void SetFirst() 
        {
            Position = 0;
            Value = Convert.ToInt32(File.ReadLines(FileName).First());
        }
        public bool MoveNext()
        {
            if (Position + 1 >= LineCount)
            {
                return false;
            }
            Value = Convert.ToInt32(File.ReadLines(FileName).Skip(++Position).First());

            return true;            
        }
        public bool AddValue(int value)
        {
            if (Position + 1 > BucketSize)
            {
                return false;
            }
            if (Position > 0)
            {
                File.AppendAllText(FileName, Environment.NewLine);
            }
            File.AppendAllText(FileName,value.ToString());
            Position++;
            LineCount++;
            return true;
        }
        public void Sort()
        {
            int[] _tmpArray = new int[LineCount];
            SetFirst();
            for (int i = 0; i < _tmpArray.Length; i++)
            {
                _tmpArray[i] = GetValue();
                MoveNext();
            }
            MergeSort(_tmpArray, 0, _tmpArray.Length - 1);

            Position = 0;
            using (var fs = new FileStream(FileName, FileMode.Truncate, FileAccess.ReadWrite, FileShare.None))
            {
                using (var sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < _tmpArray.Length; i++)
                    {
                        sw.WriteLine(_tmpArray[i].ToString());
                    }
                }                
            }
            
        }
        public int GetValue()
        {
            return Value;
        }
        public IBucket Clone()
        {
            return (new ExternalBucket(BucketSize));
        }
        public void Clear()
        {
            File.Delete(FileName);
        }
        public override bool Equals(object obj)
        {
            var extBucket = (ExternalBucket)obj;
            extBucket.SetFirst();
            int temp = extBucket.GetValue();
            SetFirst();
            temp ^= GetValue();
            while (MoveNext() && extBucket.MoveNext())
            {
                temp ^= GetValue() ^ extBucket.GetValue();    
            }

            return temp == 0;
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
