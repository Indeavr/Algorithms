using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Nested_Loops
{
    class Program
    {
        static int n;

        static int[] line;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            line = new int[n];

            RecursiveLoops(0);
        }

        private static void RecursiveLoops(int current)
        {
            if (current >= n)
            {
                Console.WriteLine(String.Join(" ", line));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                line[current] = i;
                RecursiveLoops(current + 1);
            }
        }
    }
}
