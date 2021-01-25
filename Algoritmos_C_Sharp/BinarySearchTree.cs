using System;
using System.Collections.Generic;
using System.Text;
#nullable enable
namespace Algoritmos_C_Sharp
{
    class BinarySearchTree
    {
        private Node _tree;

        public BinarySearchTree(Node tree)
        {
            _tree = tree;
        }

        public void WalkTree(Node node)
        {
            if (node != null)
            {
                WalkTree(node.Left);
                Console.WriteLine($"Node->{node?.Key} Left->{node?.Left?.Key} Right->{node?.Right?.Key} | Parent->{node?.Parent?.Key}");
                WalkTree(node.Right);
            }

        }

        public void Transplant(Node u, Node v)
        {   
            if(u.Parent == null)
            {
                _tree = v;
            }
            if (u.Parent.Left.Equals(u))
            {
                u.Parent.Left = v;
            }
            else
            {
                u.Parent.Right = v;
            }

            if(v != null)
            {
                v.Parent = u.Parent;
            }
        }



        public Node Search(Node searchValue, Node currentNode)
        {
            // Base case returns null or value if founded
            if (currentNode == null || searchValue.Key == currentNode.Key)
            {
                return currentNode;
            }
            if (searchValue.Key < currentNode.Key)
            {
                return Search(currentNode.Left, searchValue);
            }
            else
            {
                return Search(currentNode.Right, searchValue);
            }
        }

        public Node Minimum()
        {
            var x = _tree;
            while (x.Left != null)
            {
                x = x.Left;
            }
            return x;
        }

        public Node Maximum()
        {
            var x = _tree;
            while (x.Right != null)
            {
                x = x.Right;
            }
            return x;
        }

        public void Inspect()
        {
            WalkTree(_tree);
        }

    }

    class Node
    {
        public int Key { get; set; }

        public Node Parent { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node(int v) => Key = v;


        public void Insert(Node value)
        {
            value.Parent = this; 

            if (Key > value.Key)
            {

                if (Left == null)
                {
                    Left = value;
                }
                else
                {
                    Left.Insert(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = value;
                }
                else
                {
                    Right.Insert(value);
                }
            }

        }

        public override bool Equals(object? obj)
        {
           
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            
            return (obj as Node).Key == Key;

        }

        public override int GetHashCode()
        {

            return (base.GetHashCode() << 2) ^ Key;
        }
    }
}
