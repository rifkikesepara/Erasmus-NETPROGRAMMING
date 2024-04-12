using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Erasmus24
{
    enum ConvertType
    {
        Hexadecimal=0,Octal,Five,Decimal
    }
    class Converter
    {
        public static string ConvertTheNumber(string bin,ConvertType type)
        {
            switch (type)
            {
                case ConvertType.Hexadecimal:return ConvertToHexadecimal(bin);
                case ConvertType.Octal:return ConvertToOctal(bin);
                case ConvertType.Decimal:return ConvertToDecimal(bin);

            }

            return null;
        }

        private static string ConvertToHexadecimal(string bin)
        {
            string hexadecimal = "";
            string[] binaryToHexMap = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

            while (bin.Length % 4 != 0)
            {
                bin = '0' + bin;
            }

            for (int i = 0; i < bin.Length; i += 4)
            {
                string sub = bin.Substring(i, 4);
                int decimalValue = 0;

                for (int k = 0; k < 4; k++) 
                {
                    if (sub[k] != '0') decimalValue += (int)Math.Pow(2, 3 - k);
                }
                hexadecimal += binaryToHexMap[decimalValue];
            }
            return hexadecimal;
        }
        private static string ConvertToOctal(string bin)
        {
            string octal = "";
            while (bin.Length % 3 != 0) bin = "0" + bin;

            for (int i = 0; i < bin.Length; i += 3)
            {
                string sub = bin.Substring(i, 3);
                int decimalValue = 0;

                for(int k=0;k<3;k++)
                {
                    if (sub[k] != '0') decimalValue += (int)Math.Pow(2, 2 - k);
                }
                octal += decimalValue;
            }
            return octal;
        }

        private static string ConvertToDecimal(string bin)
        {
            int dec = 0;
            for(int i=0;i<bin.Length;i++)
            {
                if (bin[i] != '0') dec += (int)Math.Pow(2, bin.Length - i - 1);
            }
            
            return dec.ToString();
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a binary number: ");
            Console.WriteLine("Decimal: " + Converter.ConvertTheNumber("10101001011111111", ConvertType.Decimal));
            Console.WriteLine("Hecadecimal: " + Converter.ConvertTheNumber("10101001011111111", ConvertType.Hexadecimal));
            Console.WriteLine("Octal: " + Converter.ConvertTheNumber("10101001011111111", ConvertType.Octal));
            //Console.WriteLine("Five: " + Converter.ConvertTheNumber("10101001011111111", ConvertType.Five));

            Console.ReadLine();
        }
    }
}
