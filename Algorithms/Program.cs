using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                numbers.Add(i);
            }

            Shuffle(numbers);
            Console.WriteLine(String.Join(" ", numbers));
            Console.WriteLine(new string('_', Console.BufferWidth));

            numbers = CountingSort(numbers);

            Console.WriteLine(String.Join(" ", numbers));

        }

        private static List<int> CountingSort(List<int> numbers)
        {
            int min = numbers.Min();
            int max = numbers.Max();

            return CountingSort(numbers, min, max);
        }

        private static List<int> CountingSort(List<int> numbers, int min, int max)
        { 
            int[] countArray = new int[max - min + 1];
            foreach (int number in numbers)
            {
                countArray[number - min]++;
            }

            List<int> result = new List<int>(numbers.Count);
            for (int i = 0; i < numbers.Count; i++)
            {
                int counter = countArray[i];
                while (counter > 0)
                {
                    result.Add(i);
                    counter--;
                }
            }
            return result;
        }

        private static List<int> MergeSort(List<int> numbers)
        {
            if (numbers.Count < 2)
            {
                return numbers;
            }
            int mid = numbers.Count / 2;

            List<int> low = numbers.Take(mid).ToList();
            List<int> high = numbers.Skip(mid).ToList();

            low = MergeSort(low);
            high = MergeSort(high);

            return MergeSortMerging(low, high);
        }

        private static List<int> MergeSortMerging(List<int> low, List<int> high)
        {
            int i = 0;
            int j = 0;
            List<int> result = new List<int>();

            while (i < low.Count && j < high.Count)
            {
                if (low[i] <= high[j])
                {
                    result.Add(low[i++]);
                }
                else
                {
                    result.Add(high[j++]);
                }
            }

            while (i < low.Count)
            {
                result.Add(low[i++]);
            }

            while (j < high.Count)
            {
                result.Add(high[j++]);
            }

            return result;
        }

        private static List<int> QuickSort(List<int> numbers)
        {
            if (numbers.Count < 2)
            {
                return numbers;
            }
            int min = 0;
            int max = numbers.Count - 1;
            int mid = max / 2;

            int pivotIndex = mid;
            if (numbers[min] <= numbers[max])
            {
                if (numbers[max] < numbers[mid])
                    pivotIndex = max;
            }
            else if (numbers[max] < numbers[min])
            {
                if (numbers[min] < numbers[mid])
                    pivotIndex = min;
            }
            else if (numbers[min] <= numbers[mid])
            {
                if (numbers[mid] < numbers[max])
                    pivotIndex = mid;
            }

            List<int> right = new List<int>();
            List<int> left = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == pivotIndex)
                {
                    continue;
                }
                if (numbers[i] <= numbers[pivotIndex])
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }

            List<int> result = new List<int>();

            result.AddRange(QuickSort(left));
            result.Add(numbers[pivotIndex]);
            result.AddRange(QuickSort(right));

            return result;
        }

        private static void InsertionSort(List<int> numbers)
        {
            for (int i = 1; i < numbers.Count; i++)
            {
                int b = i;
                while (b > 0 && numbers[b] < numbers[b - 1])
                {
                    int temp = numbers[b];
                    numbers[b] = numbers[b - 1];
                    numbers[b - 1] = temp;
                    b--;
                }
            }
        }

        private static void BubbleSort(List<int> numbers)
        {
            bool swapIsDone = true;
            while (swapIsDone)
            {
                swapIsDone = false;
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                        swapIsDone = true;
                    }
                }
            }
            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    for (int j = i + 1; j < numbers.Count; j++)
            //    {
            //        if (numbers[i] >= numbers[j])
            //        {
            //            int temp = numbers[i];
            //            numbers[i] = numbers[j];
            //            numbers[j] = temp;
            //        }
            //    }
            //}
        }

        private static void SelectionSort(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                int best = i;
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[j] < numbers[best])
                    {
                        best = j;
                    }
                }
                if (best != i)
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[best];
                    numbers[best] = temp;
                }
            }
        }

        private static void Shuffle(List<int> numbers)
        {
            Random random = new Random();
            for (int i = numbers.Count - 1; i > 0; i--)
            {
                int currentRandom = random.Next() % (i + 1);

                if (currentRandom != i)
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[currentRandom];
                    numbers[currentRandom] = temp;
                }
            }
        }
    }
}
