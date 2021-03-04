using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos_C_Sharp
{
    public class Node
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
