﻿using System;
using System.Collections.Generic;

namespace Algoritmos_C_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
             int[] arr = new int[] {1,4,1,2,7,5,2};

            var quicksort = new Quicksort();
            //quicksort.Sort(arr, 0, arr.Length - 1);
            var countingSort = new CountingSort();
            var result = countingSort.Sort(arr, 9);

            foreach(var n in result)
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
