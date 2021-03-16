using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] valArray = { 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210 };

            var curBinaryTree = new BinaryTree();
            for (int i = 0; i < valArray.Length; i++)
            {
                curBinaryTree.AddItem(valArray[i]);
            }
            curBinaryTree.PrintTree();
        }
    }
}
