using System;
using System.Collections.Generic;

namespace Algoritmos_C_Sharp
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] arr = new int[] { 4, 3, 2, 1 };

      MergeSort(arr, 0, arr.Length - 1);

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

    static void merge(int[] result, int start, int end)
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
    static void MergeSort(int[] arr, int start, int end)
    {
      if (start < end)
      {
        int middle = (int)Math.Floor((decimal)(start + end) / 2);
        MergeSort(arr, start, middle);
        MergeSort(arr, middle + 1, end);
        merge(arr, start, end);
      }
    }

  }
}
