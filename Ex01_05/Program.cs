using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_05
{
    internal class Program
    {
        public static void Main()
        {
            string numberStr = Get8DigitNumberFromUser();

            PrintDigitsSmallerThanFirst(numberStr);
            PrintDigitsDivisibleBy3(numberStr);
            PrintMaxMinDifference(numberStr);
            PrintMostFrequentDigit(numberStr);
        }

        private static string Get8DigitNumberFromUser()
        {
            Console.WriteLine("Please enter a number with exactly 8 digits:");
            string input = Console.ReadLine();

            while (!IsValid8DigitNumber(input))
            {
                Console.WriteLine("Invalid input. Please enter exactly 8 digits:");
                input = Console.ReadLine();
            }

            return input;
        }

        private static bool IsValid8DigitNumber(string i_str)
        {
            if (i_str.Length != 8)
            {
                return false;
            }

            foreach (char c in i_str)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        private static void GetDigitsSmallerThanFirst(string i_numberStr, out string o_smallerDigits, out int o_count)
        {
            char firstDigit = i_numberStr[0];
            StringBuilder builder = new StringBuilder();
            o_count = 0;

            for (int i = 1; i < i_numberStr.Length; i++)
            {
                if (i_numberStr[i] < firstDigit)
                {
                    builder.Append(i_numberStr[i]);
                    builder.Append(' ');
                    o_count++;
                }
            }

            o_smallerDigits = builder.ToString().Trim();
        }

        private static void PrintDigitsSmallerThanFirst(string i_numberStr)
        {
            GetDigitsSmallerThanFirst(i_numberStr, out string smallerDigits, out int count);
            Console.WriteLine($"There are {count} digit(s) smaller than the first digit ({i_numberStr[0]}): {smallerDigits}");
        }

        private static void GetDigitsDivisibleBy3(string i_numberStr, out string o_digits, out int o_count)
        {
            StringBuilder builder = new StringBuilder();
            o_count = 0;

            for (int i = 0; i < i_numberStr.Length; i++)
            {
                int digit = i_numberStr[i] - '0';

                if (digit % 3 == 0)
                {
                    builder.Append(digit);
                    builder.Append(' ');
                    o_count++;
                }
            }

            o_digits = builder.ToString().Trim();
        }

        private static void PrintDigitsDivisibleBy3(string i_numberStr)
        {
            GetDigitsDivisibleBy3(i_numberStr, out string divisibleDigits, out int count);
            Console.WriteLine($"There are {count} digit(s) divisible by 3: {divisibleDigits}");
        }

        private static void GetMinMaxDigits(string i_numberStr, out int o_min, out int o_max)
        {
            o_min = 9;
            o_max = 0;

            foreach (char c in i_numberStr)
            {
                int digit = c - '0';
                if (digit < o_min)
                {
                    o_min = digit;
                }

                if (digit > o_max)
                {
                    o_max = digit;
                }
            }
        }

        private static void PrintMaxMinDifference(string i_numberStr)
        {
            GetMinMaxDigits(i_numberStr, out int min, out int max);
            int diff = max - min;
            Console.WriteLine($"The largest digit is {max}, the smallest is {min}, difference is {diff}.");
        }

        private static void GetMostFrequentDigit(string i_numberStr, out int o_digit, out int o_count)
        {
            int[] digitCounts = new int[10]; // index = digit

            foreach (char c in i_numberStr)
            {
                int digit = c - '0';
                digitCounts[digit]++;
            }

            o_digit = 0;
            o_count = digitCounts[0];

            for (int i = 1; i < 10; i++)
            {
                if (digitCounts[i] > o_count)
                {
                    o_count = digitCounts[i];
                    o_digit = i;
                }
            }
        }

        private static void PrintMostFrequentDigit(string i_numberStr)
        {
            GetMostFrequentDigit(i_numberStr, out int mostCommon, out int count);
            Console.WriteLine($"The most frequent digit is {mostCommon}, and it appears {count} time(s).");
        }
    }
}



