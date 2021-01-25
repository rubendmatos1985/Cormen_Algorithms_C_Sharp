#nullable enable
using System;
using System.Diagnostics;

namespace Algoritmos_C_Sharp
{
	/**
		Rules:
		1- Every node is either red or black
		2- The root is black
		3- Every leaf null is black
		4- if a node is red both of its children are black
		5- for each node, all simple paths from the node to descendant leaves contain the same number of black nodes
	**/
	public class RedBlackTree
	{
		public RedBlackTreeNode Root { get; private set; }
		public RedBlackTree(RedBlackTreeNode? root)
		{
			if (root != null)
			{
				Root = root;
				Root.Color = Color.Black;
			}
		}
		public void Insert(RedBlackTreeNode newNode)
		{
			if (Root == null)
			{
				Root = newNode;
				Root.Color = Color.Black;
			}
			else
			{
				Root.AddChild(newNode);
			}
			InsertFixup(newNode);
		}

		private void InsertFixup(RedBlackTreeNode newInsertedNode)
		{
			// if black aunt or null (because every null leaf is black)-> rotate
			// if red aunt -> color flip
			while (newInsertedNode.Parent?.Color == Color.Red)
			{
				if (newInsertedNode.Aunt.Color == Color.Black) // if node is not root has aunt parent and siblings
				{
					RedBlackTreeNode parent = new RedBlackTreeNode(null);
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

		public void Delete(RedBlackTreeNode node)
		{
			var targetCopy = node;
			var targetColor = node.Color;
			RedBlackTreeNode childCopy = new RedBlackTreeNode(null);

			if (node.Left.Key == null)
			{
				childCopy = node.Right;
				Transplant(node, childCopy);
			}
			else if (node.Right.Key == null)
			{
				childCopy = node.Left;
				Transplant(node, node.Left);
			}
			else
			{
				// find  minimum of is right child
				targetCopy = Minimum(node.Right);
				targetColor = targetCopy.Color;
				childCopy = targetCopy.Right;

				if (targetCopy.Parent == node)
				{
					childCopy.Parent = targetCopy; /// useless ??

				}
				else
				{
					// transplant right child minimum for is right child
					Transplant(targetCopy, targetCopy.Right);
					targetCopy.Right = node.Right;
					targetCopy.Right.Parent = targetCopy;
				}
				// transplant target with the minimum of is right child
				Transplant(node, targetCopy);
				targetCopy.Left = node.Left;
				targetCopy.Left.Parent = targetCopy;
				targetCopy.Color = node.Color;

			}

			if (targetColor == Color.Black)
			{
				DeleteFixup(childCopy);
			}

		}

		/** 
		 * When DeleteFixup is called:
		 * 1. No black heights have changed
		 * 2. No red nodes have been made adjacent
		 * 3. The root remains black
		 */
		private void DeleteFixup(RedBlackTreeNode x)
		{
			while (x != Root && x.Color == Color.Black)
			{
				if (x == x.Parent.Left)
				{
					var sibling = x.Parent.Right;
					if (sibling.Color == Color.Red) // case 1 Sibling is red
					{
						sibling.Color = Color.Black;
						x.Parent.Color = Color.Red;
						RotateLeft(x.Parent);
						sibling = x.Parent.Right;
					}
					if (sibling.Left.Color == Color.Black && sibling.Right.Color == Color.Black) // case 2 sibling is black and both children black
					{
						sibling.Color = Color.Red;
						x = x.Parent;

					}
					else if (sibling.Right.Color == Color.Black)
					{
						sibling.Left.Color = Color.Black;
						sibling.Color = Color.Red;
						RotateRight(sibling);
						sibling = x.Parent.Right;
					}
					else // case 4 sibling is black and its right children is red
					{
						sibling.Color = x.Parent.Color;
						x.Parent.Color = Color.Black;
						sibling.Right.Color = Color.Black;
						RotateLeft(x.Parent);
						x = Root;
					}


				}
				else
				{
					var sibling = x.Parent.Left;
					if (sibling.Color == Color.Red) // case 1 Sibling is red
					{
						sibling.Color = Color.Black;
						x.Parent.Color = Color.Red;
						RotateLeft(x.Parent);
						sibling = x.Parent.Left;
					}
					if ((sibling.Left == null || sibling.Left.Color == Color.Black) && (sibling.Right == null || sibling.Right.Color == Color.Black)) // case 2 sibling is black and both children black
					{
						sibling.Color = Color.Red;
						x = x.Parent;

					}
					else if (sibling.Left.Color == Color.Black)
					{
						sibling.Left.Color = Color.Black;
						sibling.Color = Color.Red;
						RotateRight(sibling);
						sibling = x.Parent.Left;
					}
					else // case 4 sibling is black and its left children is red
					{
						sibling.Color = x.Parent.Color;
						x.Parent.Color = Color.Black;
						sibling.Left.Color = Color.Black;
						RotateRight(x.Parent);
						x = Root;
					}
				}
			}

			x.Color = Color.Black;
		}
		public RedBlackTreeNode Minimum(RedBlackTreeNode node)
		{
			var n = node;
			while (n.Left.Key != null)
			{
				n = n.Left;
			}

			return n;
		}

		private void Transplant(RedBlackTreeNode target, RedBlackTreeNode? newTarget)
		{
			if (target.Parent == null && newTarget != null)
			{
				Root = newTarget;
				Root.Parent = null;
				return;
			}

			if (target.Parent.Left == target)
			{
				target.Parent.Left = newTarget;
			}
			else
			{
				target.Parent.Right = newTarget;
			}
			if (newTarget != null)
			{
				newTarget.Parent = target.Parent;
			}

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
				p.Parent = null;
				
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
				if (newRoot != null)
				{
					Root = newRoot;
					Root.Parent = null;
					node.Right = newRoot.Left;
					newRoot.Left = node;
					node.Parent = newRoot;
				}
			}

			else
			{
				var childCopy = node?.Right;
				var parent = node?.Parent;
				if (parent != null)
				{
					if (parent.Left == node)
					{
						parent.Left = childCopy;
					}
					else
					{
						parent.Right = childCopy;
					}
				}
				if (childCopy != null)
				{
					childCopy.Parent = parent;
					node.Parent = childCopy;
					node.Right = childCopy.Left;
					childCopy.Left = node;
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
			if (parent.Parent == null)
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
		public int? Key { get; private set; }
		public RedBlackTreeNode Left { get; set; }
		public RedBlackTreeNode Right { get; set; }

		public RedBlackTreeNode(int? key)
		{
			Key = key;

			if (key == null)
			{
				Color = Color.Black;
			}
			else
			{
				Left = new RedBlackTreeNode(null);
				Right = new RedBlackTreeNode(null);
				Left.Parent = this;
				Right.Parent = this;
				Color = Color.Red;
			}
		}

		// SEE BINARY SEARCH TREE
		public void AddChild(RedBlackTreeNode node)
		{
			// go to left
			if (node.Key < Key)
			{
				if (Left.Key == null)
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
				if (Right.Key == null)
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
