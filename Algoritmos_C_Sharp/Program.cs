using System;
using System.Collections.Generic;

namespace Algoritmos_C_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
             int[] arr = new int[] {10,9,8,7,6,5,4,3,2,1};
            
            var mergeSort = new MergeSort();
            var heap = new MaxHeap(arr);
            var heapSort = new HeapSort(heap);

            foreach (int n in heapSort.Sort())
            {
                Console.WriteLine(n);
            }
        }

        static int[] InsertionSort(int[] arr)
        {
            for (int j = 1; j < arr.Length; j++)
            {
                int numberToInsert = arr[j];
                int i = j - 1;
                while (i > -1 && arr[i] > numberToInsert)
                {
                    arr[i + 1] = arr[i];

                    i -= 1;
                }
                arr[i + 1] = numberToInsert;
            }
            return arr;
        }



    }
}
