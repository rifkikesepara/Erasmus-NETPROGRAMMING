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
            int a, b, c;
            double root1, root2, delta;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());

            delta = Math.Pow(b, 2) - 4 * a * c;
            root1 = (-b + Math.Sqrt(delta)) / (2 * a);
            root2 = (-b - Math.Sqrt(delta)) / (2 * a);

            Console.WriteLine("The quadratic equation " + a + "x^2+" + b + "x+" + c + " root's are " + root1 + " and " + root2);
            Console.ReadLine();
        }
    }
}