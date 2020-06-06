using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos_C_Sharp
{
    class CountingSort
    {
        public int[] Sort(int[] arr, int biggestNumber)
        {
            var storage = new int[biggestNumber + 1];
            var result = new int[arr.Length];

            // full storage with 0 values
            for(int i = 0; i < storage.Length; i++)
            {
                storage[i] = 0;
            }

            // store each number in its 
            // ordered position
            // and how many times is repeated in the sequence
            for(int j = 0; j < arr.Length; j++)
            {
                int currentNumber = arr[j];
                storage[currentNumber] = storage[currentNumber] + 1; 
            }

            // add the previus and current value
            // of the array 
            int firstIndex = 0;
            int secondIndex = 1;
            while(secondIndex < storage.Length)
            {
                storage[secondIndex] = storage[firstIndex] + storage[secondIndex];
                secondIndex += 1;
                firstIndex += 1;
            }

            for(var i = 0; i < arr.Length; i++)
            {
                var number = arr[i];
                var indexInResult = storage[number];
                result[indexInResult - 1] = number;
                storage[number] -= 1;
            }

            return result;
            
        }
    }
}
