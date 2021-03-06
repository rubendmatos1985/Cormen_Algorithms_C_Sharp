﻿using Algoritmos_C_Sharp.CSP;
using Algoritmos_C_Sharp.DynamicProgrammingProblems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Algoritmos_C_Sharp
{
	class Program
	{

		static void Main(string[] args)
		{
			var dijkstra = new Dijkstra();
			dijkstra.Run();
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
