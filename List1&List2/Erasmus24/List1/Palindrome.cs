using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erasmus24
{
    internal class Program
    {
        static bool isPalindrome(string word)
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
        static void Main(string[] args)
        {
            string word;
            word = Console.ReadLine();
            if (isPalindrome(word))
            {
                Console.WriteLine(word + " is palindrome");
            }
            else
                Console.WriteLine(word + " is not palindrome");
            Console.ReadLine();
        }
    }
}