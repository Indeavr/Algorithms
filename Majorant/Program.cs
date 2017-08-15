using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Majorant
{
    class Program
    {
        static void Main()
        {
            // 2 2 3 3 2 3 4 3 3 2 2 2 2 2 2 

            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            Dictionary<int, int> countEachElement = new Dictionary<int, int>();

            int n = list.Count;
            for (int i = 0; i < n; i++)
            {
                int element = list[i];
                if (!countEachElement.ContainsKey(element))
                {
                    countEachElement[element] = 0;
                }
                countEachElement[element]++;
            }

            Dictionary<int, int> majorant = countEachElement.Where(x => x.Value >= n / 2 + 1).ToDictionary(k => k.Key, v => v.Value);
            int max = 0;
            int result = 0;
            foreach (var num in majorant)
            {
                if (num.Value >= max)
                {
                    max = num.Value;
                    result = num.Key;
                }
            }

            Console.WriteLine(result);

        }
    }
}
