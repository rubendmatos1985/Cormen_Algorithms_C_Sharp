using Algoritmos_C_Sharp.CSP;
using System;

namespace Algoritmos_C_Sharp
{
	class Program
	{

		static void Main(string[] args)
		{
			var root = new RedBlackTreeNode(3);
			var leaf1 = new RedBlackTreeNode(1);
			var leaf2 = new RedBlackTreeNode(5);
			var leaf3 = new RedBlackTreeNode(7);
			var leaf4 = new RedBlackTreeNode(6);
			var leaf5 = new RedBlackTreeNode(8);

			var rbTree = new RedBlackTree(root);

			rbTree.Insert(leaf1);
			rbTree.Insert(leaf2);
			rbTree.Insert(leaf3);
			rbTree.Insert(leaf4);
			rbTree.Insert(leaf5);

			rbTree.Inspect();	
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
