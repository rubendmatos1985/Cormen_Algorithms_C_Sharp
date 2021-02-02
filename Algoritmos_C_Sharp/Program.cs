using Algoritmos_C_Sharp.CSP;
using Algoritmos_C_Sharp.DynamicAlgorithms;
using System;
using System.Collections.Generic;

namespace Algoritmos_C_Sharp
{
	class Program
	{

		static void Main(string[] args)
		{

			var rod = new List<int> { 1, 5, 8, 9 };
			var rodCuttingProblem = new RodCuttingProblem();

			rodCuttingProblem
				.Run(rod);
			
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
