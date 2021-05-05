using System;
using System.IO;
using System.Collections.Generic;

namespace Task2_8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var testBucket = new Bucket();
            using (var bucketSortExample = new SortExample(testBucket))
            {
                bucketSortExample.BucketSort();
                Console.WriteLine(bucketSortExample.TestArraysAreEqual());
            }
            
            var testExternalBucket = new ExternalBucket();
            using (var externalBucketSortExample = new SortExample(testExternalBucket))
            {
                externalBucketSortExample.BucketSort();
                Console.WriteLine(externalBucketSortExample.TestArraysAreEqual());
            }
        }
    }
    public class SortExample: IDisposable
    {
        private IBucket Source { get; set; }
        private IBucket Result { get; set; }

        private const int _arraySize = 100;
        private const int _bucketSize = 10;

        public SortExample(Bucket source)
        {
            if (source is null)
            {
                throw new ArgumentNullException();
            }
            source.SetSize(_arraySize);
            Source = source;
            Result = source.Clone();

            CreateTestArray();
        }
        public SortExample(ExternalBucket source)
        {
            if (source is null)
            {
                throw new ArgumentNullException();
            }
            source.SetSize(_arraySize);
            Source = source;
            Result = source.Clone();

            CreateTestArray();
        }
        public void BucketSort()
        {
            var buckets = new List<IBucket>();
            Type bucketType = Source.GetType();

            if (bucketType == typeof(Bucket))
            {
                buckets = CreateBuckets((Bucket)Source);
            }
            if (bucketType == typeof(ExternalBucket))
            {
                buckets = CreateBuckets((ExternalBucket)Source);
            }

            for (int i = 0; i < buckets.Count; i++)
            {
                buckets[i].Sort();
            }

            MergeBuckets(buckets);

            for (int i = 0; i < buckets.Count; i++)
            {
                buckets[i].Clear();
            }
        }
        public bool TestArraysAreEqual()
        {
            return Source.Equals(Result);
        }
        public void Dispose()
        {
            Source.Clear();
            Result.Clear();
        }
        private void CreateTestArray()
        {
            var rand = new Random();
            for (int i = 0; i < _arraySize; i++)
            {
                Source.AddValue(rand.Next(1,int.MaxValue));
            }
        }
        private List<IBucket> CreateBuckets(Bucket source)
        {
            List<IBucket> buckets = new();
            var curBacket = new Bucket(_bucketSize);        

            buckets.Add(curBacket);
            Source.SetFirst();

            do
            {
                if (!curBacket.AddValue(Source.GetValue()))
                {
                    curBacket = new Bucket(_bucketSize);
                    buckets.Add(curBacket);
                    curBacket.AddValue(Source.GetValue());
                }
            } while (Source.MoveNext());

            return buckets;
        }
        private List<IBucket> CreateBuckets(ExternalBucket source)
        {
            List<IBucket> buckets = new();
            IBucket curBacket = new ExternalBucket(_bucketSize);
            buckets.Add(curBacket);
            source.SetFirst();

            do
            {
                if (!curBacket.AddValue(Source.GetValue()))
                {
                    curBacket = new ExternalBucket(_bucketSize);
                    buckets.Add(curBacket);
                    curBacket.AddValue(Source.GetValue());
                }
            } while (Source.MoveNext());

            return buckets;
        }
        private void MergeBuckets(List<IBucket> buckets)
        {         
            int[] tmpCache = new int[buckets.Count];
            var finished = false;

            for (int i = 0; i < buckets.Count; i++)
            {
                buckets[i].SetFirst();
                tmpCache[i] = buckets[i].GetValue();
            }

            while (!finished)
            {
                var minValue = -1;
                var pointer = -1;

                for (int i = 0; i < tmpCache.Length; i++)
                {
                    if (tmpCache[i] > 0)
                    {
                        if (minValue == -1 || tmpCache[i] < minValue)
                        {
                            minValue = tmpCache[i];
                            pointer = i;
                        }
                    }
                }
                if (pointer >= 0)
                {
                    Result.AddValue(tmpCache[pointer]);
                    if (buckets[pointer].MoveNext())
                    {
                        tmpCache[pointer] = buckets[pointer].GetValue();
                    }
                    else 
                    {
                        tmpCache[pointer] = -1;
                    }                    
                }
                finished = pointer == -1;
            }           
        }
    }
}
