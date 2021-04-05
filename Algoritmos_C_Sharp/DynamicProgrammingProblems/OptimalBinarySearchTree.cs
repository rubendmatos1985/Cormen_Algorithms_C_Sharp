using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Algoritmos_C_Sharp.DynamicProgrammingAlgorithms
{
	class OptimalBinarySearchTree
	{
		private OBSTTables FillUpTables(OBSTNode[] nodes)
		{
			float[][] c = new float[nodes.Length + 1][];
			int[][] r = new int[nodes.Length + 1][];

			// fill up the tables
			for (var i = 1; i <= nodes.Length; i++)
			{
				// initialize rows
				c[i] = new float[nodes.Length + 1];
				r[i] = new int[nodes.Length + 1];

				//fill up the tables
				//c[i][i - 1] =  0;
				c[i][i] = nodes[i - 1].Probability;
				r[i][i] = i;
			}

			c[nodes.Length] = new float[nodes.Length + 1];
			c[nodes.Length][nodes.Length] = nodes[nodes.Length - 1].Probability;

			return new OBSTTables
			{
				RootsTable = r,
				CostsTable = c
			};
		}
		private OBSTTables GenerateTables(OBSTNode[] nodes)
		{
			var tables = FillUpTables(nodes);
			var c = tables.CostsTable;
			var r = tables.RootsTable;

			for (var d = 1; d <= nodes.Length - 1; d++)
			{

				for (var i = 1; i <= nodes.Length - d; i++)
				{
					var j = d + i;
					float min = float.MaxValue;
					float q = 0;
					for (var l = i; l <= j; l++)
					{
						float costRight = c[i][l - 1];
						float costLeft = l + 1 <= nodes.Length ? c[l + 1][j] : 0;
						q = costLeft + costRight;

						if (q < min)
						{
							min = q;
							r[i][j] = l;
						}
					}

					float totalCosts = 0;
					for (var x = i; x <= j; x++)
					{
						totalCosts += c[x][x];
					}

					c[i][j] = min + totalCosts;
				}
			}
			return tables;
		}
		public OBSTNode RunWith(OBSTNode[] nodes)
		{
			var tables = GenerateTables(nodes);

			var rootsTable = tables.RootsTable;
			var costsTable = tables.CostsTable;
			int rootNodeKey = rootsTable[1][nodes.Length] -1;
			var root = nodes[rootNodeKey];
			root.Probability = costsTable[1][nodes.Length];


			var stack = new Stack<(OBSTNode, int, int)>();
			stack.Push((root, 1, nodes.Length));


			while (stack.Count > 0)
			{
				var (u, i, j) = stack.Pop();
				var l = rootsTable[i][j];

				if (l < j)
				{
					// build right tree
					var rightChildIndex = rootsTable[l + 1][j] -1;
					var rightChild = nodes[rightChildIndex];
					rightChild.Probability = costsTable[l + 1][j];
					rightChild.Parent = u;
					u.Right = rightChild;
					stack.Push((rightChild, l + 1, j));
				}

				if (i < l)
				{
					// build left tree
					var leftChildIndex = rootsTable[i][l - 1] -1;
					var leftChild = nodes[leftChildIndex];
					leftChild.Probability = costsTable[i][l - 1];
					leftChild.Parent = u;
					u.Left = leftChild;
					stack.Push((leftChild, i, l - 1));
				}
			}

			return root;
		}
	}


	public class OBSTTables
	{
		public int[][] RootsTable { get; set; }
		public float[][] CostsTable { get; set; }

	}

	public class OBSTNode : Node
	{

		public float Probability { get; set; }

		public OBSTNode(int value) : base(value)
		{

		}
	}

}
