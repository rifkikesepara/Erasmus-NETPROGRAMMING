using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erasmus24
{
    class Numbers
    {
        public Numbers(int v) {
            value = v;
            if (v % 2 == 0) isEven = true;
            absoluteValue = Math.Abs(v);
        }

        public int value;
        public int absoluteValue;
        public bool isEven = false; 
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many numbers will be initialized ?: ");
            Random rnd = new Random();
            int n = 0;
            n = int.Parse(Console.ReadLine());
            HashSet<Numbers> numbers = new HashSet<Numbers>(n);

            for(int i = 0; i < n; i++)
                numbers.Add(new Numbers(rnd.Next(-100, 100)));

            for (int i = 0; i < numbers.Count; i++)
            {
                var element = numbers.ElementAt(i);
                string parity;
                if (element.isEven) parity = "Even"; else parity = "Odd";
                Console.WriteLine("Value: " + element.value + "\t| Absolute Value: " + element.absoluteValue + "\t| Parity: " + parity);
            }

            Console.ReadLine();
        }
    }
}
