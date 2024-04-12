using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erasmus24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n, k;
            Console.Write("nth root: ");
            n = int.Parse(Console.ReadLine());
            Console.Write("The number that is gonna be taken the root of: ");
            k = int.Parse(Console.ReadLine());
            Console.WriteLine(n + "th root of number " + k + " is " + Math.Pow(k, 1.0 / n));


            Console.ReadLine();
        }
    }
}
