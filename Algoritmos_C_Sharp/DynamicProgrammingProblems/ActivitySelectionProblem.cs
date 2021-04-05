using System;

/**
 * 
 *  Introduction to Algorithms: Page 415
	Suppose we have a set S = { a1,a2,a3,a4,..., an } activities that wich to use a resource
	such as a service hall which can serve only one activity at a time. Each activity a[i] 
	has a start time s[i] and a finish time f[i], where 0 <= s[i] < f[i] < Infinity.
	Assume that the activities are sorted in monotonically increasing order of finish time.
	Example: 
	  i	|0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10
	____|__|___|___|___|___|___|___|___|___|____|___	
	  s |1 | 3 | 0 | 5 | 3 | 5 | 6 |8  |8  | 2  | 12	
	  f |4 | 5 | 6 | 7 | 9 | 9 |10 |11 |12 | 14 | 16

	The set { a[1], a[3], a[9], a[11] } consists of mutually compatible activities. Is not a maximum subset, 
	however, since the subset { a[1], a[4], a[8], a[11] } is larger. 
 */
namespace Algoritmos_C_Sharp.DynamicProgrammingProblems
{
	public class ActivitySelectionProblem
	{
		int[] start;
		int[] finish;
		int[] solution;

		public void Run()
		{
			start = new[] {  1, 3, 0, 5, 3, 5, 6,  8,  8,  2,  12 };
			finish = new[] { 4, 5, 6, 7, 9, 9, 10, 11, 12, 14, 16 };
			int result = Calc();

			Console.WriteLine(result);
		}

		// Greedy algorithm
		int Calc(int n = 0)
		{
			if (n >= start.Length) return 0;
			int f = finish[n];
			int r = 1;
			for (int i = n + 1; i < start.Length; i++)
			{
				if (start[i] >= f)
				{
					r += 1;
					f = finish[i];
				}
			}

			return Math.Max(r, Calc(n + 1));
		}
	}
			




}
