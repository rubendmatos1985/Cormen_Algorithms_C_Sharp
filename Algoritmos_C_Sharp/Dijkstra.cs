using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
/**
 * Find shortest path from A to H
 * Using Djikstra Algorithm
 */
namespace Algoritmos_C_Sharp
{
	public class Dijkstra
	{
		public void Run()
		{

			var nodeA = new DjikstraNode
			{
				Key = "A",

			};
			var nodeB = new DjikstraNode
			{
				Key = "B"
			};
			var nodeC = new DjikstraNode
			{
				Key = "C"
			};
			var nodeD = new DjikstraNode
			{
				Key = "D"
			};
			var nodeE = new DjikstraNode
			{
				Key = "E"
			};
			var nodeF = new DjikstraNode
			{
				Key = "F"
			};
			var nodeG = new DjikstraNode
			{
				Key = "G"
			};
			var nodeH = new DjikstraNode
			{
				Key = "H"
			};

			// since A is the starting point set its distance to 0
			nodeA.Distance.Value = 0;
			var targetNode = nodeH;

			var tree = new List<DjikstraNode>
			{
				nodeA.AddConnection(nodeB, 8).AddConnection(nodeD, 5).AddConnection(nodeC, 2),
				nodeB.AddConnection(nodeD, 2).AddConnection(nodeF, 13),
				nodeC.AddConnection(nodeD, 2).AddConnection(nodeE, 5),
				nodeD.AddConnection(nodeE, 1).AddConnection(nodeF, 6).AddConnection(nodeG, 3),
				nodeE.AddConnection(nodeG, 1),
				nodeF.AddConnection(nodeG, 2).AddConnection(nodeH, 3),
				nodeG.AddConnection(nodeH, 6),
				nodeH
			};

			DjikstraNode? currentNode = null;
			while (currentNode != targetNode)
			{
				// pick the node with shortest path
				var minDistance = double.PositiveInfinity;
				for (int i = 0; i < tree.Count; i++)
				{

					if (!tree[i].Visited && minDistance > tree[i].Distance.Value)
					{
						minDistance = tree[i].Distance.Value;
						currentNode = tree[i];
					}
				}


				if (currentNode != null)
				{
					currentNode.Visited = true;
					foreach (var edge in currentNode.Edges)
					{
						var newDistance = currentNode.Distance.Value + edge.Cost;
						if (!edge.To.Visited && edge.To.Distance.Value > newDistance)
						{
							edge.To.Distance = new Distance
							{
								Value = newDistance,
								ComingFrom = edge.From
							};
						}
					}
				}
			}

			// print result 
			var node = targetNode;
			
			while(node.Distance.ComingFrom != null)
			{
				Console.WriteLine($"{node.Key}->{node.Distance.Value}->Comming from {node.Distance.ComingFrom.Key}");
				node = node.Distance.ComingFrom;	
			}
		}

	}



	public class DjikstraNode
	{
		public string Key { get; set; }
		public Distance Distance { get; set; }

		public bool Visited { get; set; }

		public List<Edge> Edges { get; set; }

		public DjikstraNode()
		{
			Distance = new Distance();
			Edges = new List<Edge>();
		}

		public DjikstraNode AddConnection(DjikstraNode node, int cost, bool twoWay = true)
		{
			Edges.Add(new Edge
			{
				From = this,
				To = node,
				Cost = cost
			});
			if (twoWay)
			{
				node.AddConnection(this, cost, false);
			}

			return this;
		}

	}

	public class Distance
	{
		public DjikstraNode? ComingFrom { get; set; }
		public double Value { get; set; }

		public Distance() => Value = double.PositiveInfinity;
	}

	public class Edge
	{
		public DjikstraNode From { get; set; }
		public DjikstraNode To { get; set; }

		public int Cost { get; set; }

	}

}


