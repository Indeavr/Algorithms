using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Stack
{
    public class Program
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                stack.Push(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine("Reversed: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
