using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2_5_1
{
    /*
        --56
           +--R:86
           |  +--R:96
           |  |  +--L:89
           |  +--L:70
           |     +--R:77
           |     +--L:69
           +--L:29
              +--R:34
              |  +--R:55
              |  +--L:30
              +--L:23
                 +--R:26
                 +--L:2
        DFS Expected
        -->56-->29-->23-->2-->26-->34-->30-->55-->86-->70-->69-->77-->96-->89
        DFS Actual
        -->56-->29-->23-->2-->26-->34-->30-->55-->86-->70-->69-->77-->96-->89

        BFS Expected
        -->56-->29-->86-->23-->34-->70-->96-->2-->26-->30-->55-->69-->77-->89
        BFS Actual
        -->56-->29-->86-->23-->34-->70-->96-->2-->26-->30-->55-->69-->77-->89
     */
    class Program
    {
        static void Main(string[] args)
        {
            TestDFS();
            TestBFS();
        }
        static void TestDFS()
        {
            var binaryTree = new BinaryTree();
            binaryTree.AddItem(2);
            binaryTree.AddItem(26);
            binaryTree.AddItem(23);
            binaryTree.AddItem(29);
            binaryTree.AddItem(34);
            binaryTree.AddItem(55);
            binaryTree.AddItem(30);
            binaryTree.AddItem(69);
            binaryTree.AddItem(77);
            binaryTree.AddItem(89);
            binaryTree.AddItem(70);
            binaryTree.AddItem(96);
            binaryTree.AddItem(86);
            binaryTree.AddItem(56);

            binaryTree.PrintTree();

            Console.WriteLine("DFS Expected");
            Console.WriteLine("-->56-->29-->23-->2-->26-->34-->30-->55-->86-->70-->69-->77-->96-->89");
            Console.WriteLine("DFS Actual");
            Console.WriteLine(GetDFSString(binaryTree));

        }
        static void TestBFS()
        {
            var binaryTree = new BinaryTree();
            binaryTree.AddItem(2);
            binaryTree.AddItem(26);
            binaryTree.AddItem(23);
            binaryTree.AddItem(29);
            binaryTree.AddItem(34);
            binaryTree.AddItem(55);
            binaryTree.AddItem(30);
            binaryTree.AddItem(69);
            binaryTree.AddItem(77);
            binaryTree.AddItem(89);
            binaryTree.AddItem(70);
            binaryTree.AddItem(96);
            binaryTree.AddItem(86);
            binaryTree.AddItem(56);

            binaryTree.PrintTree();

            Console.WriteLine("BFS Expected");
            Console.WriteLine("-->56-->29-->86-->23-->34-->70-->96-->2-->26-->30-->55-->69-->77-->89");
            Console.WriteLine("BFS Actual");
            Console.WriteLine(GetBFSString(binaryTree));

        }
        static string GetDFSString(BinaryTree tree)
        {
            string dfsOut = "";
            var treeStack = new Stack<TreeNode>();
            var curRoot = tree.GetRoot();
            if (curRoot != null)
            {
                treeStack.Push(curRoot);

                while (treeStack.Count != 0)
                {
                    var curNode = treeStack.Pop();
                    dfsOut += "-->" + curNode.Value.ToString();
                    if (curNode.RightChild != null)
                    {
                        treeStack.Push(curNode.RightChild);
                    }
                    if (curNode.LeftChild != null) 
                    {
                        treeStack.Push(curNode.LeftChild);
                    }
                }
            }
            return (dfsOut);
        }
        static string GetBFSString(BinaryTree tree)
        {
            string bfsOut = "";
            var treeQueue = new Queue<TreeNode>();
            var curRoot = tree.GetRoot();
            if (curRoot != null)
            {
                treeQueue.Enqueue(curRoot);

                while (treeQueue.Count != 0)
                {
                    var curNode = treeQueue.Dequeue();
                    bfsOut += "-->" + curNode.Value.ToString();
                    if (curNode.LeftChild != null)
                    {
                        treeQueue.Enqueue(curNode.LeftChild);
                    }
                    if (curNode.RightChild != null)
                    {
                        treeQueue.Enqueue(curNode.RightChild);
                    }
                }
            }
            return (bfsOut);
        }
    }
}
