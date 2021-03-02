using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2_2_2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_2_2.Tests
{
    [TestClass()]
    public class BinarySearchClassTests
    {
        private int[] TestArray1 = { 2, 4, 14, 15, 21, 24, 26, 33, 37, 38, 43, 44, 45, 49, 51, 57, 63, 79, 81, 90 };
        private int[] TestArray2 = { };
        private int[] TestArray3 = { 13 };
        private int[] UnsortedArray = { 37, 26, 57, 24, 44, 43, 15, 2, 49, 90, 38, 51, 4, 14, 79, 45, 33, 81, 63, 21 };

        [TestMethod()]
        public void SimpleBinarySearchTest()
        {            
            int TestValue = 24;

            int ValueExpected = 5;

            Assert.AreEqual(ValueExpected, BinarySearchClass.BinarySearch(TestArray1, TestValue));
        }
        [TestMethod()]
        public void OutOfRangeValueTest() 
        {
            int TestValue = 99;

            int ValueExpected = -1;

            Assert.AreEqual(ValueExpected, BinarySearchClass.BinarySearch(TestArray1, TestValue));
        }
        [TestMethod()]
        public void EmptyArrayTest() 
        {
            int TestValue = 13;

            int ValueExpected = - 1;
            Assert.AreEqual(ValueExpected, BinarySearchClass.BinarySearch(TestArray2, TestValue));

        }
        [TestMethod()]
        public void FindFirstElementTest() 
        {
            int TestValue = 2;

            int ValueExpected = 0;

            Assert.AreEqual(ValueExpected, BinarySearchClass.BinarySearch(TestArray1, TestValue));
        }
        [TestMethod()]
        public void FindLastElementTest() 
        {
            int TestValue = 90;

            int ValueExpected = TestArray1.Length - 1;

            Assert.AreEqual(ValueExpected, BinarySearchClass.BinarySearch(TestArray1, TestValue));
        }
        [TestMethod()]
        public void SingleElemArrayTest()
        {
            int TestValue = 13;

            int ValueExpected = 0;
            Assert.AreEqual(ValueExpected, BinarySearchClass.BinarySearch(TestArray3, TestValue));

        }
        [TestMethod()]
        public void UnsortedArrayBinarySearchTest()
        {
            int TestValue = 24;

            int ValueExpected = -1;

            Assert.AreEqual(ValueExpected, BinarySearchClass.BinarySearch(UnsortedArray, TestValue));
        }
    }
}