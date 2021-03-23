using System;
using System.Collections.Generic;

namespace Task2_5_1
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
            RebuildToBalancedTree();

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
            }
            RebuildToBalancedTree();
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
        private List<int> ConvertToList()
        {
            var curNode = GetRoot();
            var curList = new List<int>();

            var curStack = new Stack<TreeNode>();
            curStack.Push(curNode);

            while (curStack.Count != 0)
            {
                var node = curStack.Pop();
                curList.Add(node.Value);
                if (node.LeftChild != null)
                {
                    curStack.Push(node.LeftChild);
                }
                if (node.RightChild != null)
                {
                    curStack.Push(node.RightChild);
                }

            }

            curList.Sort();
            return curList;
        }
        private void RebuildToBalancedTree()
        {
            var curTreeList = ConvertToList();
            var curRoot = new TreeNode();
            ListToTree(out curRoot, curTreeList);
            Root = curRoot;

        }
        private void ListToTree(out TreeNode root, List<int> list)
        {
            if (list.Count == 0)
            {
                root = null;
                return;
            }
            var middlePoint = list.Count / 2;
            root = new TreeNode { Value = list[middlePoint] };

            var leftList = list.GetRange(0, middlePoint);
            var rightList = list.GetRange(middlePoint + 1, list.Count - middlePoint - 1);

            var leftChild = new TreeNode();
            var rightChild = new TreeNode();

            ListToTree(out leftChild, leftList);
            ListToTree(out rightChild, rightList);

            if (leftChild != null)
            {
                root.LeftChild = leftChild;
                root.LeftChild.Parent = root;
            }
            if (rightChild != null)
            {
                root.RightChild = rightChild;
                root.RightChild.Parent = root;
            }
        }
    }
}
