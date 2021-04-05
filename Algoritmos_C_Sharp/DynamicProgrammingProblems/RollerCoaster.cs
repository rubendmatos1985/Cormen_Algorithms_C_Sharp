using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos_C_Sharp.DynamicProgrammingAlgorithms
{
	class RollerCoaster
	{
		public void Run()
		{
			int L = 100000;
			List<int> queue = new List<int> { 100000, 9999 };
			int N = 5;
			int C = 10;
			Dictionary<string, int> memo = new Dictionary<string, int>();
			Console.WriteLine("Running");
			int revenue = Calc(C, L, queue, memo);
			Console.WriteLine($"Total revenue: {revenue}");
		}

		int Calc(int C, int L, List<int> queue, Dictionary<string, int> memo)
		{
			int revenue = 0;
			string memoKey = string.Join(',', queue.ToArray());
			if (C <= 0) return 0;

			if (memo.ContainsKey(memoKey))
			{
				Console.Error.WriteLine($"Getting value for queue {memoKey} from memo");
				revenue = memo[memoKey];
			}
			else
			{
				int capacity = L;
				List<int> temp = new List<int>();
				while (capacity >= 0 && queue.Count > 0)
				{
					int group = queue[0];
					Console.Error.WriteLine($"current group {group}");
					Console.Error.WriteLine($"capacity {capacity}");
					if (capacity - group >= 0)
					{
						capacity -= group;
						revenue += group;
						queue.RemoveAt(0);
						temp.Add(group);
					}
					else
					{
						break;
					}
				}
				queue = queue.Concat(temp).ToList();
				memo[memoKey] = revenue;
			}
			memo[memoKey] = revenue + Calc(C - 1, L, queue, memo);
			return memo[memoKey];
		}

	}
}
