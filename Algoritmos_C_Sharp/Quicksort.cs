using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos_C_Sharp
{
    class Quicksort
    {
        public void Sort(int[]arr, int start, int end)
        {
            if(start < end)
            {
                var partition = Partition(arr, start, end);
                Sort(arr, start, partition-1);
                Sort(arr, partition+1, end);
            }
        }

        public void SortWithRandomizedPartition(int[] arr, int start, int end)
        {
            if (start < end)
            {
                var partition = RandomizedPartition(arr, start, end);
                SortWithRandomizedPartition(arr, start, partition - 1);
                SortWithRandomizedPartition(arr, partition + 1, end);
            }
        }
        
        // Takes number by number in the array 
        // and sort to the left the smaller numbers
        // returning the last sorted number index
        private int Partition(int[] arr, int start, int end)
        {
         
            var lastNumber = arr[end];
            var i = start - 1; // i starts in -1
            for (var j = start; j < end; j++)
            {
                var currentNumber = arr[j];    
                if(currentNumber <= lastNumber)
                {
                    i = i + 1;
                    Exchange(arr, i, j);
                }
            }
            Exchange(arr, i + 1, end);
            return i + 1;
        }

        private int RandomizedPartition(int[]arr, int start, int end)
        {
            var random = new Random();
            var number = random.Next(0, end);
            Exchange(arr, number, end);
            return Partition(arr, start, end);
        }

        private void Exchange(int[] arr, int index1, int index2)
        {
            var temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
    }
}
