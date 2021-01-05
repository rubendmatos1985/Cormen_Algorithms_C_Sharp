#nullable enable
using System;
using System.Diagnostics;

namespace Algoritmos_C_Sharp
{
	/**
		Rules
		1- Every node is either red or black
		2- The root is black
		3- Every leaf null is black
		4- if a node is red both of its children are black
		5- for each node, all simple paths from the node to descendant leaves contain the same number of black nodes
	*/
	public class RedBlackTree
	{
		public RedBlackTreeNode Root { get; private set; }
		public RedBlackTree(RedBlackTreeNode root) { Root = root; Root.Color = Color.Black; }
		public void Insert(RedBlackTreeNode newNode)
		{

			Root.AddChild(newNode);
			InsertFixup(newNode);
		}

		public void Inspect()
		{
			int identationDeep = 15;
			int rowNumber;
			string result = ""; 

			Func<int, Func<string?, string>> configIdent = (int num)=> (string? str) =>
			{
				var result = str ?? "";
				while (num > 0)
				{
					result = " " + result;
					num--;
				}
				return result;
			};


			var identRoot = configIdent(identationDeep);
			var identRight = configIdent(identationDeep + 1);
			var identLeft = configIdent(identationDeep - 1);

			result += identRoot(Root.Key.ToString()) + "\b" + identLeft(Root.Left.Key.ToString()) + identRight(Root.Right.Key.ToString());

			Console.Write(result);
			
		}

		private void InsertFixup(RedBlackTreeNode newInsertedNode)
		{
			if (newInsertedNode.Parent == null)
			{
				Root = newInsertedNode;
				return;
			}
			// if black aunt or null (because every null leaf is black)-> rotate
			// if red aunt -> color flip
			while (newInsertedNode.Parent?.Color == Color.Red)
			{
				if (newInsertedNode.Aunt == null || newInsertedNode.Aunt.Color == Color.Black)
				{
					RedBlackTreeNode parent = new RedBlackTreeNode(0);
					if (newInsertedNode == newInsertedNode.Parent.Left)
					{    /*     c         b   
						 *     /         / \
						 *    b    ->   a   c
						 *   / 
						 *  a
						 */
						if (newInsertedNode.Parent == newInsertedNode.Parent.Parent?.Left)
						{
							parent = RotateRight(newInsertedNode.Parent.Parent);
							
						}
						/** a             c           b      
						 *   \			 /	         / \ 
						 *    c  ->		b	   ->   a   c 
						 *   /		   /
						 *  b		  a	
						*/
						if (newInsertedNode.Parent == newInsertedNode.Parent.Parent?.Right)
						{
							/**
							 * after rotation   B   
							 *				   / \
							 *				  R   R
							 */
							parent = RotateRigthLeft(newInsertedNode.Parent);
						}

					}
					else
					{
						/**
						  *  a               b 
						  *   \				/ \
						  *    b     ->    a   c    
						  *     \          
						  *      c        
						 */
						if (newInsertedNode.Parent == newInsertedNode.Parent.Parent?.Right)
						{
							parent = RotateLeft(newInsertedNode.Parent.Parent);
						}
						/**
						 *     c	            c			  b
						 *    /				   /			 / \
						 *   a       ->       b		->    	a   c
						 *    \				 /	
						 *     b			a
						 */
						if (newInsertedNode.Parent == newInsertedNode.Parent.Parent?.Left)
						{
							/**
							 * after rotation   B   
							 *				   / \
							 *				  R   R
							 */
						    parent = RotateLeftRight(newInsertedNode.Parent);
							
						}
					}
					ChangeColorsAfterRotation(parent);
				}
				else
				{
					// if aunt is red make color flip
					// grand parent red -> parent & aunt black
					// current node stays red  
					newInsertedNode.Parent.Color = Color.Black;
					newInsertedNode.Aunt.Color = Color.Black;
					newInsertedNode.Parent.Parent.Color = Color.Red;
					newInsertedNode = newInsertedNode.Parent.Parent;
				}
			}

			Root.Color = Color.Black;
		}

		private void ChangeColorsAfterRotation(RedBlackTreeNode node)
		{
			node.Color = Color.Black;
			node.Left.Color = Color.Red;
			node.Right.Color = Color.Red;
		}

		public RedBlackTreeNode? RotateRight(RedBlackTreeNode node)
		{

			if (node.Parent == null)
			{
				var p = node.Left;
				if (p != null)
				{
					Root = p;
					node.Left = p.Right;
					p.Right = node;
					node.Parent = p;
				}
			}
			else
			{
				var parent = node.Parent;
				var leftChild = node.Left;
				if (parent != null)
				{
					if (parent.Right == node)
					{
						parent.Right = leftChild;
					}
					else
					{
						parent.Left = leftChild;
					}
				}
				leftChild.Parent = parent;
				node.Left = leftChild.Right;
				leftChild.Right = node;

				node.Parent = leftChild;
			}
			return node.Parent;
		}

		public RedBlackTreeNode? RotateLeft(RedBlackTreeNode node)
		{
			if (node.Parent == null)
			{
				var newRoot = node.Right;
				if(newRoot != null)
				{
					Root = newRoot;
					newRoot.Parent = null;
					node.Right = newRoot.Left;
					newRoot.Left = node;
					node.Parent = newRoot;
				}
			}

			else
			{
				var rightChild = node?.Right;
				var parent = node?.Parent;
				if (parent != null)
				{
					if (parent.Left == node)
					{
						parent.Left = rightChild;
					}
					else
					{
						parent.Right = rightChild;
					}
				}
				if (rightChild != null)
				{
					rightChild.Parent = parent;
					node.Parent = rightChild;
					node.Right = rightChild.Left;
					rightChild.Left = node;
				}
			}
			return node?.Parent;
		}

		public RedBlackTreeNode? RotateRigthLeft(RedBlackTreeNode node)
		{
			var parent = RotateRight(node);
			if (parent == null)
			{
				Root = node;
				return node;
			}
			if(parent.Parent == null)
			{
				Root = parent;
				return parent;
			}
			return RotateLeft(parent.Parent);
		}

		public RedBlackTreeNode? RotateLeftRight(RedBlackTreeNode node)
		{
			var parent = RotateLeft(node);
			return RotateRight(parent.Parent);
		}
	}

	public class RedBlackTreeNode
	{
		public RedBlackTreeNode? Parent { get; set; }
		public RedBlackTreeNode? Aunt { get => Parent == Parent?.Parent?.Left ? Parent?.Parent?.Right : Parent?.Parent?.Left; }
		public Color Color { get; set; }
		public int Key { get; private set; }
		public RedBlackTreeNode? Left { get; set; }
		public RedBlackTreeNode? Right { get; set; }

		public RedBlackTreeNode(int key)
		{
			Key = key;
			Color = Color.Red;
		}

		// SAME BEHAVIOR AS IN BINARY SEARCH TREE
		public void AddChild(RedBlackTreeNode node)
		{
			// go to left
			if (node.Key < Key)
			{
				if (Left == null)
				{
					node.Parent = this;
					Left = node;
				}
				else
				{
					Left.AddChild(node);
				}

			}// go to right
			else
			{
				if (Right == null)
				{
					node.Parent = this;
					Right = node;
				}
				else
				{
					Right.AddChild(node);
				}
			}
		}
	}

	public enum Color
	{
		Red,
		Black
	}
}
