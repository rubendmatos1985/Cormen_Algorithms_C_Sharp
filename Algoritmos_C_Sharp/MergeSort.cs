using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos_C_Sharp
{
    public class MergeSort
    {
        void merge(int[] result, int start, int end)
        {
            int middle = (int)Math.Ceiling((double)(end - start + 1) / 2) + start;

            List<int> L = new List<int>();
            List<int> R = new List<int>();

            // INSERT VALUES TO LEFT ARRAY
            for (int i = start; i < middle; i++)
            {
                L.Add(result[i]);
            }


            // INSERT VALUES TO RIGHT ARRAY
            for (int j = middle; j <= end; j++)
            {
                R.Add(result[j]);
            }

            // INSERTING SENTINELS
            // TO DO -> USE DOUBLES TO INSERT INFINITY
            L.Add(int.MaxValue);
            R.Add(int.MaxValue);


            int indexLeft = 0;
            int indexRight = 0;


            // MERGE AND SORT ARRRAYS
            for (int k = start; k <= end; k++)
            {
                if (L[indexLeft] <= R[indexRight])
                {
                    result[k] = L[indexLeft];
                    indexLeft += 1;
                }
                else
                {
                    result[k] = R[indexRight];
                    indexRight += 1;
                }
            }
        }

        public void Sort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int middle = (int)Math.Floor((decimal)(start + end) / 2);
                Sort(arr, start, middle);
                Sort(arr, middle + 1, end);
                merge(arr, start, end);
            }
        }
    }
}
