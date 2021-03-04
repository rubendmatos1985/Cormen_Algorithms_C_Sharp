using Algoritmos_C_Sharp.CSP;
using Algoritmos_C_Sharp.DynamicAlgorithms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Algoritmos_C_Sharp
{
	class Program
	{

		static void Main(string[] args)
		{
			var obst = new OptimalBinarySearchTree();
			OBSTNode[] nodes = new OBSTNode[]
			{
				new OBSTNode(0)
				{
					Probability = 0.213f
				},
				new OBSTNode(1)
				{
					Probability = 0.020f
				},
				new OBSTNode(2)
				{
					Probability = 0.547f
				},
				new OBSTNode(3)
				{
					Probability = 0.100f
				},
				new OBSTNode(4)
				{
					Probability = 0.120f
				}
			};



			var root = obst.RunWith(nodes);
			

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
