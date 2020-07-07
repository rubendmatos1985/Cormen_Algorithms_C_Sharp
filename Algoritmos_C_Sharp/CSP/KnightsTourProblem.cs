using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Algoritmos_C_Sharp.CSP
{
    // CSP
    // D = { 1,2,3,4,5,6,7,8 }
    // x = { X, Y }
    // c = {  }
    public class KnightsTourProblem
    {

        private List<KnightMove> _knightMoves;
        int _tryNumber;
        public KnightsTourProblem()
        {

            _knightMoves = new List<KnightMove>();
            _knightMoves.Add(new KnightMove { X = 2, Y = 1 });
            _knightMoves.Add(new KnightMove { X = 1, Y = 2 });
            _knightMoves.Add(new KnightMove { X = -1, Y = 2 });
            _knightMoves.Add(new KnightMove { X = -2, Y = 1 });
            _knightMoves.Add(new KnightMove { X = -2, Y = -1 });
            _knightMoves.Add(new KnightMove { X = -1, Y = -2 });
            _knightMoves.Add(new KnightMove { X = 1, Y = -2 });
            _knightMoves.Add(new KnightMove { X = 2, Y = -1 });
            _tryNumber = 0;
        }

        public void SolveKnightTourProblem(int[][] canvas, KnightMove currentPosition)
        {

            canvas[currentPosition.Y][currentPosition.X] = _tryNumber;
            if (AllCellsAreVisited(canvas))
            {
                // SOLUTION FOUNDED
                // WILL START TO GO OUT FROM RECURSION
                return;
            }

            for (var i = 0; i < _knightMoves.Count; i++)
            {
                if (MoveIsValid(canvas, currentPosition, _knightMoves[i]))
                {
                    int newX = currentPosition.X + _knightMoves[i].X;
                    int newY = currentPosition.Y + _knightMoves[i].Y;
                    _tryNumber += 1;

                    SolveKnightTourProblem(canvas, new KnightMove { X = newX, Y = newY });
                }

                if (i == _knightMoves.Count - 1 && !AllCellsAreVisited(canvas))
                {
                    // backtracking
                    canvas[currentPosition.Y][currentPosition.X] = -1;
                    _tryNumber -= 1;
                }

            }

        }



        public bool AllCellsAreVisited(int[][] canvas)
        {
            foreach (var row in canvas)
            {
                foreach (var cell in row)
                {
                    if (cell == -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool MoveIsValid(int[][] canvas, KnightMove currentPos, KnightMove move)
        {
            if (currentPos.X + move.X >= 0 && currentPos.X + move.X <= canvas[0].Length - 1)
            {
                if (currentPos.Y + move.Y >= 0 && currentPos.Y + move.Y <= canvas.Length - 1)
                {
                    var nextY = currentPos.Y + move.Y;
                    var nextX = currentPos.X + move.X;
                    if (canvas[nextY][nextX] == -1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }



        public void Inspect(int[][] canvas)
        {
            int i = 0;
            foreach (int[] row in canvas)
            {
                foreach (int cell in row)
                {
                    Console.Write($" {cell} ");
                }

                i += 1;
                Console.Write("\n");
            }
        }

        public class KnightMove
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
