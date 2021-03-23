using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2_6_1
{
    class Program
    {
        const int _nodeCount = 13;
        static void Main(string[] args)
        {
            Console.WriteLine("BFS Expected");
            Console.WriteLine("-->0-->1-->2-->6-->3-->4-->5-->8-->9-->7-->10-->11-->12");
            Console.WriteLine("BFS Actual");
            Console.WriteLine(GetBFSString(CreateTestGraf()));

            Console.WriteLine();
            Console.WriteLine("DFS Expected");
            Console.WriteLine("-->0-->1-->6-->5-->3-->2-->4-->9-->7-->10-->8-->11-->12");
            Console.WriteLine("DFS Actual");
            Console.WriteLine(GetDFSString(CreateTestGraf()));
        }
        static Node CreateTestGraf()
        {
            var adgMatrix = new int[_nodeCount, _nodeCount];
            CreateAdjacencyMatrix(adgMatrix);

            //nodes
            var nodeList = new List<Node>();
            for (int i = 0; i < _nodeCount; i++) 
            {
                nodeList.Add(new Node { Value = i });
            }

            for (int i = 0; i < _nodeCount; i++)
            {
                var edgeList = new List<Edge>();

                for (int j = 0; j < _nodeCount; j++)
                {
                    if (adgMatrix[i, j] == 1)
                    {
                        edgeList.Add(new Edge { Weight = adgMatrix[i, j], Node = nodeList[j] });
                    }
                }
                nodeList[i].Edges = edgeList;
            }
            return nodeList[0];            
        }
        static string GetBFSString(Node root)
        {
            var _retVal = "";

            var curList = new List<Node>();
            var visitedList = new List<Node>();

            curList.Add(root);
            visitedList.Add(root);

            while (curList.Count != 0)
            {
                var curNode = curList[0];
                curList.RemoveAt(0);

                for (int i = 0; i < curNode.Edges.Count; i++)
                {
                    if (!visitedList.Contains(curNode.Edges[i].Node))
                    {
                        visitedList.Add(curNode.Edges[i].Node);
                        curList.Add(curNode.Edges[i].Node);
                    }
                }
                _retVal += "-->" + curNode.Value.ToString();
            }

            return _retVal;
        }
        static string GetDFSString(Node root)
        {
            var _retVal = "";
            var visitedList = new List<Node>();

            _retVal += GetDFSNode(visitedList, root);

            return _retVal;
        }
        private static string GetDFSNode(List<Node> visitedList, Node node)
        {
            var _retVal = "";

            visitedList.Add(node);

            _retVal += "-->" + node.Value.ToString();

            for (int i = 0; i < node.Edges.Count; i++)
            {
                if (!visitedList.Contains(node.Edges[i].Node))
                {
                    _retVal += GetDFSNode(visitedList, node.Edges[i].Node);
                }
            }
            return _retVal;
        }

        static void CreateAdjacencyMatrix(int[,] adgMatrix)
        {
            for (int i = 0; i < adgMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adgMatrix.GetLength(1); j++)
                {
                    adgMatrix[i, j] = 0;
                }
            }
            AddRoute(adgMatrix, 0, 1);
            AddRoute(adgMatrix, 0, 2);
            AddRoute(adgMatrix, 1, 6);
            AddRoute(adgMatrix, 2, 3);
            AddRoute(adgMatrix, 2, 4);
            AddRoute(adgMatrix, 3, 4);
            AddRoute(adgMatrix, 3, 5);
            AddRoute(adgMatrix, 4, 9);
            AddRoute(adgMatrix, 5, 6);
            AddRoute(adgMatrix, 5, 7);
            AddRoute(adgMatrix, 6, 8);
            AddRoute(adgMatrix, 7, 9);
            AddRoute(adgMatrix, 7, 10);
            AddRoute(adgMatrix, 8, 10);
            AddRoute(adgMatrix, 8, 11);
            AddRoute(adgMatrix, 9, 12);
            AddRoute(adgMatrix, 10, 11);
            AddRoute(adgMatrix, 10, 12);

        }
        private static void AddRoute(int[,] adgMatrix, int x, int y)
        {
            adgMatrix[x, y] = 1;
            adgMatrix[y, x] = 1;
        }
    }
}
