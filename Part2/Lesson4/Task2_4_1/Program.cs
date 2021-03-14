using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;

namespace Task2_4_1
{
/*
|                Method |         Mean |       Error |      StdDev |
|---------------------- |-------------:|------------:|------------:|
|   FindStringArrayTest | 436,420.6 ns | 4,962.86 ns | 4,642.27 ns |
| FindStringHashSetTest |     409.0 ns |     4.26 ns |     3.99 ns | 
*/

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        }
    }
    public class BechmarkClass
    {
        private string[] StringArray { get; set; }
        private HashSet<string> MyHashSet { get; set; }
        private string[] TestStringArray { get; set; }

        const int _arraySize = 10000;
        const int _stringSize = 20;
        const int _testArraySize = 10;

        public BechmarkClass()
        {
            CreateTextArrays();
            TestStringArray = CreateRandomTestStringArray();
        }
        private void CreateTextArrays()
        {
            StringArray = new string[_arraySize];
            MyHashSet = new HashSet<string>();
            for (int i = 0; i < StringArray.Length; i++)
            {
                string tmpString = RandonString();
                StringArray[i] = tmpString;
                MyHashSet.Add(tmpString);
            }
        }
        private string RandonString()
        {
            var random = new Random();
            var sb = new StringBuilder(_stringSize);
            char startChar = 'a';
            const int charCount = 26;
            for (int i = 0; i < _stringSize; i++)
            {
                var curChar = (char)random.Next(startChar, startChar+charCount);
                sb.Append(curChar);
            }

            return sb.ToString();
        }
        private string[] CreateRandomTestStringArray()
        {
            var rand = new Random();
            var retVal = new string[_testArraySize];
            for (int i = 0; i < retVal.Length - 1; i++)
            {
                retVal[i] = StringArray[rand.Next(0, StringArray.Length - 1)];
            }
            retVal[retVal.Length - 1] = RandonString();

            return retVal;
        }
        private bool isContainsStringArray(string TargetString)
        {
            for (int j = 0; j < StringArray.Length; j++)
            {
                if (StringArray[j] == TargetString)
                {
                    return (true);
                }
            }
            return (false);
        }

        [Benchmark]
        public void FindStringArrayTest()
        {
            for (int i = 0; i < TestStringArray.Length; i++)
            {
                var isContains = isContainsStringArray(TestStringArray[i]);
            }
        }
        [Benchmark]
        public void FindStringHashSetTest()
        {
            for (int i = 0; i < TestStringArray.Length; i++)
            {
                var isContains = MyHashSet.Contains(TestStringArray[i]);
            }
        }
    }
}
