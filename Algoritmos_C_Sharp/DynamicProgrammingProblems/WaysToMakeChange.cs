using System;
using System.Collections.Generic;

namespace Algoritmos_C_Sharp.DynamicProgrammingAlgorithms
{

	class WaysToMakeChange
	{
		public void Run(int N, int S, string[] inputs)
		{
			
			var memo = new Dictionary<string, int>();
			
			int[] units = new int[S];
			for (int i = 0; i < S; i++)
			{
				int vi = int.Parse(inputs[i]);
				units[i] = vi;
				Console.WriteLine($"V{i} {inputs[i]}");
			}

			Console.WriteLine($"Solution: {Calc(N, units, S -1, memo)}");
		}

		int Calc(int n, int[] units, int length, Dictionary<string, int> memo)
		{
			if(n == 0)
			{
				return 1;
			}else if(n < 0)
			{
				return 0;
			}else if(length < 0 && n >= 1)
			{
				return 0;
			}
			else
			{
				if (memo.ContainsKey($"l{length}_n{n}"))
				{
					return memo[$"l{length}_n{n}"];
				}
				else
				{
					memo[$"l{length}_n{n}"] = Calc(n, units, length - 1, memo) + Calc(n - units[length], units, length, memo);
					return memo[$"l{length}_n{n}"];
				}
			}
		}

	}

}
