using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_SubSequence
{
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCounter = 0;
            Stack<int> startIndexes = new Stack<int>();

            int currentCounter = 0;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    currentCounter++;
                    if (currentCounter >= maxCounter)
                    {
                        maxCounter = currentCounter;
                        startIndexes.Push(Math.Abs(maxCounter - 1 - i));
                    }
                }
                else
                {
                    currentCounter = 0;
                }
            }
            List<int> longestSubSequence = numbers.Skip(startIndexes.Pop()).Take(maxCounter + 1).ToList();
            Console.WriteLine(String.Join(" ",longestSubSequence));
        }

        private static void ReadNumbers(List<int> numbers)
        {
           
        }
    }
}
