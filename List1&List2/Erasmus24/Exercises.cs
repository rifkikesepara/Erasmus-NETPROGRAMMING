using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erasmus24
{
    internal class Exercises
    {
        public static bool isPalindrome(string word)
        {
            for(int i = 0; i < word.Length;)
            {
                for (int j = word.Length-1;j >= 0; j--,i++)
                {
                    if (word[i] != word[j])
                        return false;
                }
                break;
            }
            return true;
        }

        public static bool isPrime(int n)
        {
            if(n == 0) return false;

            for (int i = 2; i < n;i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public static bool isTriangularNumber(int n)
        {
            int a = 1;
            for (int i = 1; ;i += a)
            {
                if(n==i)return true;
                if(i>n) return false;
                a++;
            }
        }
    }
}
