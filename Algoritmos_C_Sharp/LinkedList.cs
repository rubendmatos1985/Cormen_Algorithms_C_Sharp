using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos_C_Sharp
{
    class LinkedList
    {
        public Object Head { get; set; }

        public Object Search(Object value)
        {
            var x = Head;
            while (x != null && x.Key != value.Key)
            {
                x = x.Next;
            }
            return x;
        }

        public void Inspect()
        {
            var temp = Head;
            while (temp != null)
            {
                Console.WriteLine(temp.Key);
                temp = temp.Next;
            }
        }

        public void Insert(Object value)
        {
            value.Next = Head;
            if (Head != null)
            {
                Head.Prev = value;
            }
            Head = value;
        }

        public void Delete(Object value)
        {
            if(value.Prev != null)
            {
                value.Prev.Next = value.Next;
            }
            else
            {
                Head = value.Next;
            }
            if(value.Next != null)
            {
                value.Next.Prev = value.Prev;
            }
        }
    }

    class Object
    {
        public Object(int val) => Key = val;
        public int Key { get; set; }
        public Object Next { get; set; }

        public Object Prev { get; set; }

    }
}
