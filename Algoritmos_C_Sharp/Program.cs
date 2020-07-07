using Algoritmos_C_Sharp.CSP;
namespace Algoritmos_C_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = new KnightsTourProblem();
            // create canvas with -1 values
            // as default meaning not visited position
            var canvas = new int[8][];
            for (int i = 0; i < 8; i++)
            {
                canvas[i] = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    canvas[i][j] = -1;
                }
            }
            n.SolveKnightTourProblem(canvas, currentPosition: new KnightsTourProblem.KnightMove { X = 0, Y=0 });
            n.Inspect(canvas);
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
