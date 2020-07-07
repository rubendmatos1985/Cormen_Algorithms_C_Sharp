using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Algoritmos_C_Sharp
{
    public static class FindThreeNumbers
    {
        static CSPVariable _a = new CSPVariable { Domain = new List<int> { 1, 2, 3 } };
        static CSPVariable _b = new CSPVariable { Domain = new List<int> { 1, 2, 3 } };
        static CSPVariable _c = new CSPVariable { Domain = new List<int> { 1, 2, 3 } };
        static List<CSPVariable> variables = new List<CSPVariable> { _a, _b, _c };


        // C { A > B, B != C, A!= C }
        // X { A,B,C }
        // D { 1,2,3 }
        // Solution -> { 2,1,3 }
        public static void Run(List<int> solution, int index = 0)
        {

            for (var i = 0; i < variables[index].Domain.Count; i++)
            {


                solution.Add(variables[index].Domain[i]);
                if (solution.Count == 0 || solution.Count == 1)
                {
                    Run(solution, index++);

                }

                if (Constraint(solution))
                {
                    if (solution.Count == 3)
                    {
                        break; // solution founded
                    }
                    else
                    {
                        // go down in the tree    
                        Run(solution, index++);
                        break;
                    }

                }
                // Backtracking
                solution.RemoveAt(solution.Count - 1);
            }
        }

        public static bool Constraint(List<int> values)
        {
            if (values.Count <= 1)
            {
                return false;
            }
            if (values.Count == 2)
            {
                return values[0] > values[1];
            }
            return values[0] > values[1] && values[1] != values[2] && values[0] != values[2];
        }

    }

    public class CSPVariable
    {
        public List<int> Domain { get; set; }


    }

}













