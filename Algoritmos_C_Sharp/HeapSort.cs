using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algoritmos_C_Sharp
{
    public class HeapSort
    {
        MaxHeap _heap;
        public HeapSort(MaxHeap h) => _heap = h;
        public List<int> Sort()
        {
            var result = new List<int>();
            var array = _heap.ToList();
            while(array.Count > 0)
            {
                result = result.Prepend(array[0]).ToList();
                Swap(array, 0, array.Count -1);
                _heap = new MaxHeap(array.GetRange(0, array.Count - 1).ToArray());
                array = _heap.ToList();
            }
            return result;
        }

        void Swap(List<int>arr, int index, int index1)
        {
            var temp = arr[index];
            arr[index] = arr[index1];
            arr[index1] = temp;
        }
    }

    public class MaxHeap
    {
        int[] _heap;
        int _heapSize = int.MinValue;
        public MaxHeap(int[] heap)
        {
            _heap = heap;
            Build();
            HeapSize = _heap.Length;
        }

        public void MaxHeapify(int[] arr, int index)
        {
            var left = Left(index + 1) - 1;
            var right = Right(index + 1) - 1;
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

        void Build()
        {
            var deepestFather = (int)Math.Floor((double)(_heap.Length / 2)) - 1;
            for (var i = deepestFather; i >= 0; i--)
            {
                MaxHeapify(_heap, i);
            }
        }
        public int First => _heap[0];

        public int Last => _heap[_heap.Length - 1];

        public int HeapSize { private set { _heapSize = value; } get => _heap.Length; }

        public List<int> ToList() => _heap.ToList();

    }
}
