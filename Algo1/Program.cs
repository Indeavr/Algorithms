using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1
{
    class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> result = new List<int>(50);

            Queue<int> ses = new Queue<int>();

            ses.Enqueue(n);
            result.Add(n);

            for (int i = 0; i < 50 / 4; i++)
            {
                int s1 = ses.Dequeue();

                int s2 = s1 + 1;
                ses.Enqueue(s2);

                int s3 = 2 * s1 + 1;
                ses.Enqueue(s3);

                int s4 = s1 + 2;
                ses.Enqueue(s4);

                result.Add(s2);
                result.Add(s3);
                result.Add(s4);
            }
            Console.WriteLine(String.Join(" ",result));

        }
    }
}
