using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos_C_Sharp
{
    class HeapSort
    {
        public void MaxHeapify(int[] arr, int index)
        {
            var left = Left(index+1) - 1;
            var right = Right(index+1) - 1;
            var largest = index;
            if (left < arr.Length && arr[left] > arr[index])
            {
                largest = left;
            }
            else
            {
                largest = index;
            }
            if (right < arr.Length && arr[right] > arr[largest])
            {
                largest = right;
            }
            if (largest != index)
            {
                Swap(arr, index, largest);
                MaxHeapify(arr, largest);
            }
        }

        void Swap(int[] arr, int index, int largest)
        {
            var temp = arr[index];
            arr[index] = arr[largest];
            arr[largest] = temp;
        }

        int Left(int index) => 2 * index;


        int Right(int index) => 2 * index + 1;

    }
}
