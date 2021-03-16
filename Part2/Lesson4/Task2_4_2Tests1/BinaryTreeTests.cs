using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2_4_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_4_2.Tests
{
    [TestClass()]
    public class BinaryTreeTests
    {
        private int[] valArray = {50,60,70,80,90,100,110,120,130,140,150,160,170,180,190,200,210 };

        /*
        --120
           +--R:160
           |  +--R:180
           |  |  +--R:200
           |  |  |  +--R:210
           |  |  |  +--L:190
           |  |  +--L:170
           |  +--L:140
           |     +--R:150
           |     +--L:130
           +--L:80
              +--R:100
              |  +--R:110
              |  +--L:90
              +--L:60
                 +--R:70
                 +--L:50
         */

        [TestMethod()]
        public void GetRootTestOneNode()
        {
            int testValue = 99;

            int valueExpected = 99;
            var testTree = new BinaryTree();

            testTree.AddItem(testValue);

            Assert.AreEqual(valueExpected, testTree.GetRoot().Value);          
        }
        [TestMethod()]
        public void GetRootTestEmpty()
        {
            var testTree = new BinaryTree();
            Assert.AreEqual(null, testTree.GetRoot());
        }
        [TestMethod()]
        public void TreeBalancingTest()
        {
            int valueExpected1 = 120;
            int valueExpected2 = 150;

            var testTree = new BinaryTree();
            for (int i = 0; i < valArray.Length; i++)
            {
                testTree.AddItem(valArray[i]);
            }
            Assert.AreEqual(valueExpected1, testTree.GetRoot().Value);
            testTree.RemoveItem(140);
            testTree.RemoveItem(110);

            Assert.AreEqual(valueExpected2, testTree.GetNodeByValue(160).LeftChild.Value);
            Assert.AreEqual(null, testTree.GetNodeByValue(100).RightChild);
        }
        [TestMethod()]
        public void TestDeleteRoot()
        {
            int valueExpected = 130;
            var testTree = new BinaryTree();
            for (int i = 0; i < valArray.Length; i++)
            {
                testTree.AddItem(valArray[i]);
            }
            testTree.RemoveItem(120);
            Assert.AreEqual(valueExpected, testTree.GetRoot().Value);
        }
        [TestMethod()]
        public void TestDelete()
        {
            int valueExpected = 210;
            var testTree = new BinaryTree();
            for (int i = 0; i < valArray.Length; i++)
            {
                testTree.AddItem(valArray[i]);
            }
            testTree.RemoveItem(200);
            Assert.AreEqual(valueExpected, testTree.GetNodeByValue(180).RightChild.Value);
        }
        [TestMethod()]
        public void TestTreeUnbalance()
            //удалим всю левую часть
        {
            var valueExpected = 160;
            var valueExpected1 = 120;
            var valueExpected2 =  180;

            var testTree = new BinaryTree();
            for (int i = 0; i < valArray.Length; i++)
            {
                testTree.AddItem(valArray[i]);
            }
            testTree.RemoveItem(80);
            testTree.RemoveItem(100);
            testTree.RemoveItem(110);
            testTree.RemoveItem(90);
            testTree.RemoveItem(60);
            testTree.RemoveItem(70);
            testTree.RemoveItem(50);

            Assert.AreEqual(valueExpected, testTree.GetRoot().Value);
            Assert.AreEqual(valueExpected2, testTree.GetRoot().RightChild.Value);
            Assert.AreEqual(valueExpected1, testTree.GetRoot().LeftChild.Value);
        }
    }
}

