using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
  Given a two dimensional array representing a map
  find the total number of paths between two
  opposite points (0,0) and (N-1,M-1). You can only move from left to right
  and from top to bottom.
  Value 0 means that you are free to go on a cell, value 1 is a non reachable cell
 */
namespace Algoritmos_C_Sharp.DynamicProgrammingProblems
{
	class FindPathInGridWithObstacles
	{
		public void Run()
		{
			var table = new List<List<int>>
			{
				new List<int>
				{
					0, 0
				},
				new List<int>
				{
					1, 0
				}
			};

			var result = Calc(table, 0, 0);
			Console.WriteLine(result);
		}

		int Calc(List<List<int>> table, int x, int y)
		{
			if (x >= table.Count) return 0; // limit to the right found
			if (y >= table[0].Count) return 0; // limit bottom found
			if (table[x][y] == 1) return 0; // obstacle found
			if (x == table.Count - 1 && y == table[0].Count - 1) return 1; // path found

			return Calc(table, x + 1, y) + Calc(table, x, y + 1);
		}

	}
}
