using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Task2_2_1
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }
    public class NodeCollection : ILinkedList
    {
        private Node StartNode { get; set; }
        private Node EndNode { get; set; }

        public NodeCollection() { }

        public int GetCount()
        {
            int count = 1;
            if (StartNode == null)
            {
                return 0;
            }
            Node CurNode = StartNode;
            while (CurNode.NextNode != null)
            {
                count++;
                CurNode = CurNode.NextNode;
            }
            return count;
        }
        public void AddNode(int value)
        {
            Node CurNode = new Node { Value = value };

            if (StartNode == null)
            {
                StartNode = CurNode;
                return;
            }
            if (EndNode == null)
            {
                EndNode = CurNode;
                StartNode.NextNode = EndNode;
                EndNode.PrevNode = StartNode;
                return;
            }
            EndNode.NextNode = CurNode;
            CurNode.PrevNode = EndNode;
            EndNode = CurNode;

        }
        public void AddNodeAfter(Node node, int value)
        {
            if (node == null)
            {
                return;
            }
            Node NewNode = new Node { Value = value };
            NewNode.NextNode = node.NextNode;
            NewNode.PrevNode = node;
            node.NextNode = NewNode;
        }
        public Node FindNode(int searchValue)
        {
            Node CurNode = StartNode;
            while (CurNode != null && CurNode.Value != searchValue)
            {
                CurNode = CurNode.NextNode;
            }
            return CurNode;
        }
        public void RemoveNode(int index)
        {
            if (index < 0)
            {
                return;
            }
            int i = 0;
            Node CurNode = StartNode;
            while (i++ != index && CurNode != null)
            {
                CurNode = CurNode.NextNode;
            }
            if (CurNode != null)
            {
                if (CurNode.PrevNode != null)
                {
                    CurNode.PrevNode.NextNode = CurNode.NextNode;
                }
                else
                {
                    StartNode = CurNode.NextNode;
                }
                if (CurNode.NextNode != null)
                {
                    CurNode.NextNode.PrevNode = CurNode.PrevNode;
                }
                else
                {
                    EndNode = CurNode.PrevNode;
                }
            }
        }
        public void RemoveNode(Node node)
        {
            if (node == null)
            {
                return;
            }
            if (node.PrevNode != null)
            {
                node.PrevNode.NextNode = node.NextNode;
            }
            else 
            {
                StartNode = node.NextNode;
            }
            if (node.NextNode != null)
            {
                node.NextNode.PrevNode = node.PrevNode;
            }
            else 
            {
                EndNode = node.PrevNode;
            }
        }
        public override string ToString()
        {
            string RetVal = String.Empty;
            Node CurNode = StartNode;
            while (CurNode != null)
            {
                if (!String.IsNullOrEmpty(RetVal)) {
                    RetVal += '\t';       
                }
                RetVal += CurNode.Value.ToString();
                CurNode = CurNode.NextNode;
            }

            return RetVal;
        }
    }
 /*
    class Program
    {
        static void Main(string[] args)
        {

            ILinkedList CurCollection = new NodeCollection();

            // проверка некорректных значений
            Console.WriteLine(CurCollection.GetCount());
            CurCollection.RemoveNode(99);                    
            CurCollection.AddNodeAfter(CurCollection.FindNode(99), 100);    
            CurCollection.RemoveNode(CurCollection.FindNode(99));
            Console.WriteLine(CurCollection);

            // заполнение и удаление элементов
            CurCollection.AddNode(10);
            CurCollection.AddNode(13);
            CurCollection.AddNode(15);
            CurCollection.AddNode(17);
            CurCollection.AddNode(19);
            CurCollection.RemoveNode(CurCollection.FindNode(17));
            CurCollection.RemoveNode(3);
            CurCollection.AddNodeAfter(CurCollection.FindNode(13), 21);

            Console.WriteLine(CurCollection); 

        }
    }
 */
}
