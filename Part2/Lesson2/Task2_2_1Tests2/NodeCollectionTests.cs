using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2_2_1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_2_1.Program.Tests
{
    [TestClass()]
    public class NodeCollectionTests
    {
        [TestMethod()]
        public void GetZeroCountTest()
        {
            int expected = 0;

            ILinkedList CurCollection = new NodeCollection();
            Assert.AreEqual(expected, CurCollection.GetCount());
        }
        [TestMethod()]
        public void Get3CountTest()
        {
            int expected = 3;

            ILinkedList CurCollection = new NodeCollection();
            CurCollection.AddNode(1);
            CurCollection.AddNode(2);
            CurCollection.AddNode(3);
            Assert.AreEqual(expected, CurCollection.GetCount());
        }
        [TestMethod()]
        public void AddOneNodeValueTest()
        {
            int TestValue = 13;
            int ValueExpected = 13;
            int CountExpected = 1;

            ILinkedList CurCollection = new NodeCollection();
            CurCollection.AddNode(TestValue);

            Assert.AreEqual(CountExpected, CurCollection.GetCount());
            Assert.AreEqual(ValueExpected.ToString(), CurCollection.ToString());
        }
        [TestMethod()]
        public void FindNodeTest()
        {
            int TestValue = 13;
            int ValueExpected = 13;
            int CountExpected = 6;

            ILinkedList CurCollection = new NodeCollection();
            for (int i = 10; i <= 15; i++) //add 6 nodes
            {
                CurCollection.AddNode(i);
            }
            Assert.AreEqual(ValueExpected, CurCollection.FindNode(TestValue).Value);
            Assert.AreEqual(CountExpected, CurCollection.GetCount());
        }
        [TestMethod()]
        public void FindNonExistsNodeTest()
        {
            int TestValue = 99;
            int CountExpected = 6;

            ILinkedList CurCollection = new NodeCollection();
            for (int i = 10; i <= 15; i++) //add 6 nodes
            {
                CurCollection.AddNode(i);
            }
            Assert.AreEqual(null, CurCollection.FindNode(TestValue));
            Assert.AreEqual(CountExpected, CurCollection.GetCount());
        }
        [TestMethod()]
        public void AddNodeAfterTest()
        {
            int TestValue1 = 13;
            int TestValue2 = 99;

            int Value1Expected = 99;
            int Value2Expected = 13;
            int Value3Expected = 14;

            ILinkedList CurCollection = new NodeCollection();
            for (int i = 10; i <= 15; i++) //add 6 nodes
            {
                CurCollection.AddNode(i);
            }
            CurCollection.AddNodeAfter(CurCollection.FindNode(TestValue1), TestValue2);
            Assert.AreEqual(Value1Expected, CurCollection.FindNode(Value1Expected).Value);
            Assert.AreEqual(Value2Expected, CurCollection.FindNode(Value1Expected).PrevNode.Value);
            Assert.AreEqual(Value3Expected, CurCollection.FindNode(Value1Expected).NextNode.Value);
        }
        [TestMethod()]
        public void AddNodeAfterNonExistNodeTest()
        {
            int TestValue1 = 17;
            int TestValue2 = 99;

            int CountExpected = 6;

            ILinkedList CurCollection = new NodeCollection();
            for (int i = 10; i <= 15; i++) //add 6 nodes
            {
                CurCollection.AddNode(i);
            }
            CurCollection.AddNodeAfter(CurCollection.FindNode(TestValue1), TestValue2);

            Assert.AreEqual(null, CurCollection.FindNode(TestValue1));
            Assert.AreEqual(CountExpected, CurCollection.GetCount());

        }
        [TestMethod()]
        public void RemoveStartNodeByIndexTest()
        {
            int TestValue = 0;
            int TestValue2 = 10;

            int CountExpected = 5;

            ILinkedList CurCollection = new NodeCollection();
            for (int i = 10; i <= 15; i++) //add 6 nodes
            {
                CurCollection.AddNode(i);
            }
            CurCollection.RemoveNode(TestValue);
            Assert.AreEqual(CountExpected, CurCollection.GetCount());
            Assert.AreEqual(null, CurCollection.FindNode(TestValue2));

        }
        [TestMethod()]
        public void RemoveAnyNodeByIndexTest()
        {
            int TestValue = 3;
            int TestValue2 = 13;

            int CountExpected = 5;

            ILinkedList CurCollection = new NodeCollection();
            for (int i = 10; i <= 15; i++) //add 6 nodes
            {
                CurCollection.AddNode(i);
            }
            CurCollection.RemoveNode(TestValue);
            Assert.AreEqual(CountExpected, CurCollection.GetCount());
            Assert.AreEqual(null, CurCollection.FindNode(TestValue2));
        }
        [TestMethod()]
        public void RemoveNodeTest() 
        {
            int TestValue1 = 10;
            int TestValue2 = 13;

            int Value1Expected = 11;
            int Value2Expected = 12;
            int Value3Expected = 14;
            int CountExpected = 4;

            ILinkedList CurCollection = new NodeCollection();
            for (int i = 10; i <= 15; i++) //add 6 nodes
            {
                CurCollection.AddNode(i);
            }

            Node TestNode1 = CurCollection.FindNode(TestValue1);
            Node TestNode2 = CurCollection.FindNode(TestValue2);

            Assert.AreEqual(null, TestNode1.PrevNode);
            Assert.AreEqual(Value1Expected, TestNode1.NextNode.Value);

            Assert.AreEqual(Value2Expected, TestNode2.PrevNode.Value);
            Assert.AreEqual(Value3Expected, TestNode2.NextNode.Value);

            CurCollection.RemoveNode(TestNode1);
            CurCollection.RemoveNode(TestNode2);

            Assert.AreEqual(null, CurCollection.FindNode(Value1Expected).PrevNode);
            Assert.AreEqual(Value2Expected, CurCollection.FindNode(Value3Expected).PrevNode.Value);
            Assert.AreEqual(Value3Expected, CurCollection.FindNode(Value2Expected).NextNode.Value);
            Assert.AreEqual(CountExpected, CurCollection.GetCount());
        }
    }
}