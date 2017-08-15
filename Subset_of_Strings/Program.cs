using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subset_of_Strings
{
    public class Program
    {
        private static string[] words;
        private static string[] currentWords;
        private static int combinations;

        public static void Main()
        {
            words = Console.ReadLine().Split();
            currentWords = new string[words.Length];
            combinations = 0;

            //IterativeAlgorithm();
            for (int i = 0; i <= words.Length; i++)
            {
                RecursiveSubsets(0, 0);
                combinations++;
            }
           
        }

        private static void RecursiveSubsets(int index, int currentDigit)
        {
            if (index >= combinations)
            {
                PrintWords(currentWords, combinations);
                return;
            }

            for (int i = currentDigit; i < words.Length; i++)
            {
                currentWords[index] = words[i];
                RecursiveSubsets(index + 1, currentDigit + 1);
                currentDigit++;
            }
        }

        private static void PrintWords(string[] strings, int combinations)
        {
            if (combinations == 0)
            {
                Console.Write("()");
            }
            for (int i = 0; i < combinations; i++)
            {
                Console.Write($"({strings[i]})");
                if (i != combinations - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }

        //private static void IterativeAlgorithm()
        //{
        //    int numberOrWords = 0;
        //    int index = 0;
        //    while (numberOrWords != words.Length)
        //    {
        //        for (int i = 0; i < numberOrWords; i++)
        //        {
        //            currentWords[index] = words


        //            for (int j = i; j < words.Length; j++)
        //            {

        //            }

        //            Console.WriteLine("), ");
        //        }
        //        numberOrWords++;
        //    }

        //}
    }
}
