using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erasmus24
{
    internal class Program
    {
        static bool isTriangularNumber(int n)
        {
            int a = 1;
            for (int i = 1; ;i += a)
            {
                if(n==i)return true;
                if(i>n) return false;
                a++;
            }
        }
        static void Main(string[] args)
        {
            int number = 0;
            number = int.Parse(Console.ReadLine());
            if (isTriangularNumber(number)) Console.WriteLine(number + " is a triangular number.");
            else Console.WriteLine(number + " is not a triangular number");

            Console.ReadLine();
        }
    }
}