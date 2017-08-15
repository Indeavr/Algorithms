using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Sort
{
    public class Program
    {
        private static int[] subArray1;
        private static int[] subArray2;

        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new string[] {"\n"},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            MergeSort(numbers);
            Console.WriteLine(string.Join("\n", numbers));
        }

        private static void MergeSort(int[] numbers)
        {
            MergeSortR(numbers, 0, numbers.Length - 1);
        }

        private static void MergeSortR(int[] numbers, int low, int high)
        {
            if (low >= high)
            {
                return;
            }
            int mid = (low + high) / 2;
            MergeSortR(numbers, low, mid);
            MergeSortR(numbers, mid + 1, high);

            Merge(numbers, low, mid, high);
            //InternetMethod(numbers, low, mid, high); //not working
        }

        private static void Merge(int[] numbers, int low, int mid, int high)
        {
            int f = low; // start index of first half
            int s = mid + 1; // start index of second half

            int[] array = new int[high - low + 1];
            int k = 0; // index of array representing the single line

            for (int i = low; i <= high; i++)
            {
                if (f > mid)      // checks if the first part came to an end
                    array[k++] = numbers[s++];

                else if (s > high)   //checks if second part comes to an end or not
                    array[k++] = numbers[f++];

                else if (numbers[f] < numbers[s])     //makes the sorting, checking for the smaller element 
                    array[k++] = numbers[f++];

                else
                    array[k++] = numbers[s++];
            }

            for (int i = 0; i < k; i++)
            {
                // fills the initial array with the sorted elements
                numbers[low++] = array[i];
            }
        }

        private static void InternetMethod(int[] numbers, int low, int mid, int high)
        {

            int[] lowHalf = new int[mid + 1 - low];
            int[] highHalf = new int[high - mid];


            int i; // low half index
            int j; // high half index
            int k = low; // initial array index 

            for (i = 0; k <= mid; i++, k++) //fill arrays
            {
                lowHalf[i] = numbers[k];
            }

            for (j = 0; k <= high; j++, k++)
            {
                highHalf[j] = numbers[k];
            }

            i = 0;
            j = 0;
            k = 0;

            while (lowHalf.Length > i && highHalf.Length > j)
            {
                if (lowHalf[i] > highHalf[j])
                {
                    numbers[k] = highHalf[j++];
                }
                else
                {
                    numbers[k] = lowHalf[i++];
                }
                k++;
            }

            while (lowHalf.Length > i)
            {
                numbers[k++] = lowHalf[i++];
            }

            while (highHalf.Length > j)
            {
                numbers[k++] = highHalf[j++];
            }
        }
    }
}
