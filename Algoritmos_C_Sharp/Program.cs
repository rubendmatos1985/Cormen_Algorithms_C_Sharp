using Algoritmos_C_Sharp.CSP;
using System;

namespace Algoritmos_C_Sharp
{
	class Program
	{

		static void Main(string[] args)
		{

			var rbTree = new RedBlackTree(null);
			var nodes = new RedBlackTreeNode[]
			{
				new RedBlackTreeNode(41),
				new RedBlackTreeNode(38),
				new RedBlackTreeNode(31),
				new RedBlackTreeNode(12),
				new RedBlackTreeNode(19),
				new RedBlackTreeNode(8)
			};
			foreach (var node in nodes)
			{
				rbTree.Insert(node);
			}
			//var node1 = nodes[5]; // 8
			//var node2 = nodes[3]; // 12
			//  var node3 = nodes[4]; // 19
			var node4 = nodes[2]; // 31
			//var node5 = nodes[1]; // 38
			//var node6 = nodes[0]; // 41

			rbTree.Delete(node4);

			Console.Read();

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
