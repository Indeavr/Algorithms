using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remove_Negatives
{
    public static class Program
    {
        public static void Main()
        {
            List<string> sequence = Console.ReadLine().Split().ToList();
            sequence.RemoveNegativeNumbers();
            Console.WriteLine(string.Join(" ",sequence));
        }

        private static void RemoveNegativeNumbers(this List<string> stringSequence)
        {
            stringSequence.RemoveAll(x => x.StartsWith("-"));
        }
    }
}
