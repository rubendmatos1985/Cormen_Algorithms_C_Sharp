using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algoritmos_C_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Node(5);
            var numbers = new Node[] { new Node(2), new Node(1), new Node(4), new Node(30), new Node(10) };

            foreach(var node in numbers)
            {
                root.Insert(node);
            }

            var searchTree = new BinarySearchTree(root);

            Console.WriteLine($"Maximum {searchTree.Maximum().Key}");
            Console.WriteLine($"Minimum {searchTree.Minimum().Key}");
            searchTree.Inspect();
        }

        static int[] InsertionSort(int[] arr)
        {
            for (int j = 1; j < arr.Length; j++)
            {
                int numberToInsert = arr[j];
                int i = j - 1;
                while (i > -1 && arr[i] > numberToInsert)
                {
                    arr[i + 1] = arr[i];

                    i -= 1;
                }
                arr[i + 1] = numberToInsert;
            }
            return arr;
        }



    }
}
