using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            const int SIZE = 10;
            var array = new int[SIZE];

            var rnd = new Random();
            for (int i = 0; i < SIZE; i++)
            {
                array[i] = rnd.Next(0, SIZE - 1);
            }
            array = array.InsertionSort();
            Console.WriteLine(String.Join(" ", array));
            return;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            array.RadixRightToLeft(2, 65536);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);


            //Console.WriteLine(string.Join(" ", array));
            for (int i = 1; i < array.Length; ++i)
            {
                if(array[i - 1] > array[i])
                {
                    Console.WriteLine("Error");
                    break;
                }
            }
        }
    }
}
