using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms_Optimized
{
    class Program
    {
        static void Main()
        {
            int size = 100;
            int[] array = new int[size];

            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next() % size;
            }

            Console.WriteLine(String.Join(" ", array));
            Console.WriteLine();

            array = InsertionSort(array);

            Console.WriteLine(String.Join(" ", array));
        }

        private static int[] InsertionSort(int[] array)
        {
            int[] sorted = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int h;
                for (h = 0; h < i; h++)
                {
                    if (sorted[h] > array[i])
                    {
                        break;
                    }
                }

                for (int j = i; j > h; j--)
                {
                    sorted[j] = sorted[j - 1];
                }

                sorted[h] = array[i];
            }

            return sorted;
        }
    }
}
