using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class Program
    {
        public static void Main()
        {
            Getbinarynum(out string[] o_binaryNumberArray);

        }

        private static void Getbinarynum(out string[] o_binaryNumbersArray)
        {
            o_binaryNumbersArray = new string[4];
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Enter a number");
                string currentNumberFromUser = (Console.ReadLine());
                if (isBinaryNumbersIsvalid(currentNumberFromUser) == true)
                {
                    o_binaryNumbersArray[i] = currentNumberFromUser;
                }
                else
                {
                    i--;
                    Console.WriteLine("Your binary number is invalid! Enter a number");
                }
            }
        
        }

        private static bool isBinaryNumbersIsvalid(string i_binaryNumber)
        {
            if (i_binaryNumber == null || i_binaryNumber.Length != 7)
            {
                return false;
            }

            foreach (char c in i_binaryNumber)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }

            return true;
        }

    }
}
