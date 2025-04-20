using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    internal class Program
    {
        public static void Main()
        {
            Get12CharactersFromUser(out string userString);

            PrintIfPalindrome(userString);

            if (IsAllDigits(userString))
            {
                PrintIfDivisibleBy3(userString);
                return;
            }
            else if (IsAllLetters(userString))
            {
                PrintUpperCaseCount(userString);
                PrintIfOrderedAlphabetically(userString);
                return;
            }
        }

        private static void Get12CharactersFromUser(out string o_result)
        {
            Console.WriteLine("Please enter a string of exactly 12 characters:");
            o_result = Console.ReadLine();

            while (o_result == null || o_result.Length != 12)
            {
                Console.WriteLine("Invalid input. Please enter exactly 12 characters:");
                o_result = Console.ReadLine();
            }
        }

        private static bool IsPalindrome(string i_str)
        {
            for (int i = 0, j = i_str.Length - 1; i < j; i++, j--)
            {
                if (char.ToLower(i_str[i]) != char.ToLower(i_str[j]))
                {
                    return false;
                }
            }
            return true;
        }

        private static void PrintIfPalindrome(string i_str)
        {
            if (IsPalindrome(i_str))
            {
                Console.WriteLine("The string is a palindrome.");
            }
            else
            {
                Console.WriteLine("The string is not a palindrome.");
            }
        }

        private static bool IsAllDigits(string i_str)
        {
            foreach (char c in i_str)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsDigitSumDivisibleBy3(string i_str)
        {
            int digitSum = 0;

            foreach (char c in i_str)
            {
                digitSum += c - '0';
            }

            return digitSum % 3 == 0;
        }

        private static void PrintIfDivisibleBy3(string i_str)
        {
            if (IsDigitSumDivisibleBy3(i_str))
            {
                Console.WriteLine("The number is divisible by 3.");
            }
            else
            {
                Console.WriteLine("The number is not divisible by 3.");
            }
        }

        private static bool IsAllLetters(string i_str)
        {
            foreach (char c in i_str)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static int CountUpperCaseLetters(string i_str)
        {
            int count = 0;
            foreach (char c in i_str)
            {
                if (char.IsUpper(c))
                {
                    count++;
                }
            }
            return count;
        }

        private static void PrintUpperCaseCount(string i_str)
        {
            int numOfUpperCaseLetters = CountUpperCaseLetters(i_str);
            Console.WriteLine($"Number of uppercase letters: {numOfUpperCaseLetters}");
        }

        private static bool IsAlphabeticallyOrdered(string i_str)
        {
            for (int i = 0; i < i_str.Length - 1; i++)
            {
                if (char.ToLower(i_str[i]) > char.ToLower(i_str[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }

        private static void PrintIfOrderedAlphabetically(string i_str)
        {
            if (IsAlphabeticallyOrdered(i_str))
            {
                Console.WriteLine("The string is ordered alphabetically.");
            }
            else
            {
                Console.WriteLine("The string is not ordered alphabetically.");
            }
        }
    }
}
