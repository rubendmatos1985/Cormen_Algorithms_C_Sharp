using System;
using System.Collections.Generic;
namespace Algoritmos_C_Sharp.DynamicProgrammingAlgorithms
{
	// Given a rod of length n inches 
	// and a table of prices pi for i = 1,2....,n
	// determine the maximum revenue rn obtainable
	// by cutting up the rod and selling the pieces.
	// Not cutting at all may be an option too.

	/**
	 * Solution:
	 *   A rod r of length n can be cut (decompose) in  
	 *   Example n = 4: xxxx | x xxx | xx xx | xxx x | x x xx
	 *   
	 */
	class RodCuttingProblem
	{
		private Dictionary<int, int> _memo;

		public RodCuttingProblem()
		{
			_memo = new Dictionary<int, int>();
		}
		public void Run(List<int> rod)
		{
			var result = MemoizedCutRod(rod, rod.Count);
			Console.WriteLine(result);
		}


		// With memoization O(n)
		private int MemoizedCutRod(List<int> rod, int length)
		{
			if (length == 0)
			{
				_memo[0] = 0;
				return 0;
			}

			int revenue = int.MinValue;
			int newCutRevenue;
			for (var i = 0; i < length; i++)
			{
				try
				{
					newCutRevenue = _memo[length - (i + 1)];
				}
				catch
				{
					newCutRevenue = MemoizedCutRod(rod, length - (i + 1));
				}

				var currentLengthPrice = rod[i];
				revenue = Math.Max(revenue, currentLengthPrice + newCutRevenue);


			}
			_memo[length] = revenue;
			return revenue;
		}


		// Brute force approach O(2^n)
		private int CutRod(List<int> rod, int length)
		{
			if (length == 0)
			{
				return 0;
			}

			int revenue = int.MinValue;
			for (var i = 0; i < length; i++)
			{
				var newCutRevenue = CutRod(rod, length - (i + 1));
				var currentLengthPrice = rod[i];
				revenue = Math.Max(revenue, currentLengthPrice + newCutRevenue);
			}
			return revenue;
		}

	}
}
