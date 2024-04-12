using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erasmus24
{
    internal class Program
    {
        static bool isPrime(int n)
        {
            if(n == 0) return false;

            for (int i = 2; i < n;i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            int number = 0;
            number = int.Parse(Console.ReadLine());
            if (isPrime(number))
                Console.WriteLine(number + " is a prime number.");
            else
                Console.WriteLine(number + " is not a prime number.");

            Console.ReadLine();
        }
    }
}