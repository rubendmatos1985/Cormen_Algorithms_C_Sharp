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

    
}
