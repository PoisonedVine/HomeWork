using System;
using System.Collections.Generic;

namespace Task2_4_2
{
    public class BinaryTree : ITree
    {
        private TreeNode Root { get; set; }
        public TreeNode GetRoot()
        {
            return Root;
        }
        public void AddItem(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode { Value = value };
                return;
            }
            var curTreeNode = Root;
            var newNode = new TreeNode { Value = value };

            bool inserted = false;

            while (!inserted)
            {
                if (value < curTreeNode.Value)
                {
                    if (curTreeNode.LeftChild == null)
                    {
                        curTreeNode.LeftChild = newNode;
                        newNode.Parent = curTreeNode;
                        inserted = true;
                    }
                    else
                    {
                        curTreeNode = curTreeNode.LeftChild;
                    }
                }
                else
                {
                    if (curTreeNode.RightChild == null)
                    {
                        curTreeNode.RightChild = newNode;
                        newNode.Parent = curTreeNode;
                        inserted = true;
                    }
                    else
                    {
                        curTreeNode = curTreeNode.RightChild;
                    }
                }
            }
            BalanceTreeByTurns();
        }
        private void RemoveItem(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftChild == null && node.RightChild == null)
            {
                if (node.Parent == null)
                {
                    Root = null;
                    return;
                }
                if (node.Parent.LeftChild == node)
                {
                    node.Parent.LeftChild = null;
                }
                else
                {
                    node.Parent.RightChild = null;
                }
                return;

            }
            if (node.LeftChild != null && node.RightChild == null)
            {
                if (node.Parent == null)
                {
                    Root = node.LeftChild;
                    return;
                }
                if (node.Parent.LeftChild == node)
                {
                    node.Parent.LeftChild = node.LeftChild;
                }
                else
                {
                    node.Parent.RightChild = node.LeftChild;
                }
                return;
            }
            if (node.LeftChild == null && node.RightChild != null)
            {
                if (node.Parent == null)
                {
                    Root = node.RightChild;
                    return;
                }

                if (node.Parent.LeftChild == node)
                {
                    node.Parent.LeftChild = node.RightChild;
                }
                else
                {
                    node.Parent.RightChild = node.RightChild;
                }
                return;
            }

            var minRightNode = node.RightChild;
            while (minRightNode.LeftChild != null)
            {
                minRightNode = minRightNode.LeftChild;
            }
            var newNode = new TreeNode { Value = minRightNode.Value };

            if (node.Parent != null)
            {
                if (node.Parent.LeftChild == node)
                {
                    node.Parent.LeftChild = newNode;
                }
                else
                {
                    node.Parent.RightChild = newNode;
                }
            }
            else
            {
                Root = newNode;
            }
            newNode.LeftChild = node.LeftChild;
            if (newNode.LeftChild != null)
            {
                newNode.LeftChild.Parent = newNode;
            }
            newNode.RightChild = node.RightChild;
            if (newNode.RightChild != null)
            {
                newNode.RightChild.Parent = newNode;
            }
            newNode.Parent = node.Parent;
            RemoveItem(minRightNode);

        }
        public void RemoveItem(int value)
        {
            var curRoot = GetRoot();

            while (curRoot.Value != value && curRoot != null)
            {

                if (value < curRoot.Value)
                {
                    curRoot = curRoot.LeftChild;
                }
                else
                {
                    curRoot = curRoot.RightChild;
                }
            }
            if (curRoot != null)
            {
                RemoveItem(curRoot);
                BalanceTreeByTurns();
            }
            
        }
        public TreeNode GetNodeByValue(int value)
        {
            var CurNode = GetRoot();
            while (CurNode != null && CurNode.Value != value)
            {
                if (value < CurNode.Value)
                {
                    CurNode = CurNode.LeftChild;
                }
                else
                {
                    CurNode = CurNode.RightChild;
                }
            }

            return CurNode;
        }
        public void PrintTree()
        {

            var curRoot = new NodeInfo { Node = GetRoot() };
            var rootStack = new Stack<NodeInfo>();
            rootStack.Push(curRoot);

            var childLists = new List<Stack<NodeInfo>>();
            childLists.Add(rootStack);

            while (childLists.Count != 0)
            {
                var curChildList = childLists[childLists.Count - 1];
                if (curChildList.Count == 0)
                {
                    childLists.RemoveAt(childLists.Count - 1);
                }
                else
                {
                    curRoot = curChildList.Pop();
                    var curChildStack = new Stack<NodeInfo>();

                    string indent = "";
                    for (int i = 0; i < childLists.Count - 1; i++)
                    {
                        indent += (childLists[i].Count > 0) ? "|  " : "   ";
                    }
                    if (indent != "")
                    {
                        indent += "+--";
                    }
                    else
                    {
                        indent += "--";
                    }
                    Console.WriteLine("{0}{2}{1}", indent, curRoot.Node.Value, curRoot.Position);

                    var depth = curRoot.Depth + 1;

                    if (curRoot.Node.LeftChild != null)
                    {
                        curChildStack.Push(new NodeInfo { Node = curRoot.Node.LeftChild, Depth = depth, Position = "L:" });
                    }
                    if (curRoot.Node.RightChild != null)
                    {
                        curChildStack.Push(new NodeInfo { Node = curRoot.Node.RightChild, Depth = depth, Position = "R:" });
                    }
                    if (curChildStack.Count != 0)
                    {
                        childLists.Add(curChildStack);
                    }
                }

            }

        }
        private List<TreeNode> GetBFSList()
        {
            var curList = new List<TreeNode>();

            var treeQueue = new Queue<TreeNode>();
            var curRoot = GetRoot();
            if (curRoot != null)
            {
                treeQueue.Enqueue(curRoot);

                while (treeQueue.Count != 0)
                {
                    var curNode = treeQueue.Dequeue();
                    curList.Add(curNode);
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
            return (curList);
        }
        private int GetHeight(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return (1 + Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild)));
        }
        private TreeNode GetUnbalancedSubTreeRoot(out int heightDif)
        {
            heightDif = 0;
            var curTreeList = GetBFSList();
            for (int i = curTreeList.Count - 1; i >= 0; i--)
            {
                heightDif = GetHeight(curTreeList[i].LeftChild) - GetHeight(curTreeList[i].RightChild);
                if (Math.Abs(heightDif) > 1)
                {
                    return (curTreeList[i]);    
                }
            }
            return null;
        }
        private void LeftTurn(TreeNode node)
        {
            var parentNode = node.Parent;

            if (node.RightChild is null)
            {
                return;
            }
            var curRoot = node.RightChild;
            node.RightChild = curRoot.LeftChild;
            if (node.RightChild is not null)
            {
                node.RightChild.Parent = node;
            }
            curRoot.LeftChild = node;
            node.Parent = curRoot;
            curRoot.Parent = parentNode;

            if (parentNode is not null)
            {
                if (parentNode.LeftChild == node)
                {
                    parentNode.LeftChild = curRoot;
                }
                else
                {
                    parentNode.RightChild = curRoot;
                }
            }
            else
            {
                Root = curRoot;
            }
        }
        private void RightTurn(TreeNode node)
        {
            var parentNode = node.Parent;

            if (node.LeftChild is null)
            {
                return;
            }
            var curRoot = node.LeftChild;
            node.LeftChild = curRoot.RightChild;
            if (node.LeftChild is not null)
            {
                node.LeftChild.Parent = node;
            }
            curRoot.RightChild = node;
            node.Parent = curRoot;
            curRoot.Parent = parentNode;

            if (parentNode is not null)
            {
                if (parentNode.LeftChild == node)
                {
                    parentNode.LeftChild = curRoot;
                }
                else
                {
                    parentNode.RightChild = curRoot;
                }
            }
            else
            {
                Root = curRoot;
            }
        }
        private void BalanceTreeByTurns()
        {
            int heightDiff = 0;
            var curTreeList = GetBFSList();
            bool rebuilded = false;
            do
            {
                rebuilded = false;
                for (int i = curTreeList.Count - 1; i >= 0; i--)
                {
                    heightDiff = GetHeight(curTreeList[i].LeftChild) - GetHeight(curTreeList[i].RightChild);
                    if (Math.Abs(heightDiff) > 1)
                    {
                        var parentNode = curTreeList[i].Parent;
                        TreeNode newRoot = null;
                        if (heightDiff > 0)
                        {
                            RightTurn(curTreeList[i]);
                        }
                        else
                        {
                            LeftTurn(curTreeList[i]);
                        }
                        rebuilded = true;
                        curTreeList = GetBFSList();
                        break;
                    }
                }
            } while (rebuilded);
        }
    }
}
