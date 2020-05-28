using System;
using System.Collections.Generic;

namespace Algoritmos_C_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1,2,3,4,5 };
            
            var mergeSort = new MergeSort();
            var heapSort = new HeapSort();
            
            
            heapSort.MaxHeapify(arr, 0);

            foreach (int n in arr)
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
