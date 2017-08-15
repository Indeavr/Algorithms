using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations_with_Duplicates
{
    public class Program
    {
        static int nElements;
        static int kCombinations;
        static int[] currentCombination;

        public static void Main()
        {
            nElements = int.Parse(Console.ReadLine());
            kCombinations = int.Parse(Console.ReadLine());

            //IterativeAlgorithm(nElements, kCombinations);

            currentCombination = new int[kCombinations];
            NestedLoopsRecursion(0, 1);
        }

        private static void IterativeAlgorithm(int n, int k)
        {
            int[] array = new int[k];
            for (int i = 1; i <= n; i++)
            {
                array[0] = i;
                for (int j = i + 1; j <= n; j++)
                {
                    array[1] = j;
                    Console.WriteLine(array[0] + " " + array[1]);
                }
            }
        }

        private static void NestedLoopsRecursion(int index, int currentDigit)
        {
            if (index >= kCombinations)
            {
                Console.WriteLine(string.Join(" ", currentCombination));
                return;
            }

            for (int i = currentDigit; i <= nElements; i++)
            {
                currentCombination[index] = i;
                NestedLoopsRecursion(index + 1, currentDigit + 1);
                currentDigit++;
            }
        }
    }
}
