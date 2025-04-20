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
            string input = Get12CharStringFromUser();
            PrintIfPalindrome(input);

            if (IsAllDigits(input))
            {
                PrintIfDivisibleBy3(input);
            }
            else if (IsAllLetters(input))
            {
                PrintUpperCaseCount(input);
                PrintIfOrderedAlphabetically(input);
            }
        }

        private static string Get12CharStringFromUser()
        {
            Console.WriteLine("Please enter a string of exactly 12 characters:");
            string input = Console.ReadLine();

            while (string.IsNullOrEmpty(input) || input.Length != 12)
            {
                Console.WriteLine("Invalid input. Please enter exactly 12 characters:");
                input = Console.ReadLine();
            }

            return input;
        }

        private static bool IsPalindrome(string input)
        {
            for (int i = 0, j = input.Length - 1; i < j; i++, j--)
            {
                if (Char.ToLower(input[i]) != Char.ToLower(input[j]))
                {
                    return false;
                }
            }
            return true;
        }

        private static void PrintIfPalindrome(string input)
        {
            Console.WriteLine(string.Format(
                "The string {0} a palindrome.", IsPalindrome(input) ? "is" : "is not"));
        }

        private static bool IsAllDigits(string input)
        {
            foreach (char c in input)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static void PrintIfDivisibleBy3(string input)
        {
            int sum = 0;
            foreach (char c in input)
            {
                sum += c - '0';
            }

            Console.WriteLine(string.Format(
                "The number {0} divisible by 3.",
                (sum % 3 == 0) ? "is" : "is not"));
        }

        private static bool IsAllLetters(string input)
        {
            foreach (char c in input)
            {
                if (!Char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static void PrintUpperCaseCount(string input)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (Char.IsUpper(c))
                {
                    count++;
                }
            }

            Console.WriteLine(string.Format("Number of uppercase letters: {0}", count));
        }

        private static bool IsAlphabeticallyOrdered(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (Char.ToLower(input[i]) > Char.ToLower(input[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }

        private static void PrintIfOrderedAlphabetically(string input)
        {
            Console.WriteLine(string.Format(
                "The string {0} in alphabetical order.",
                IsAlphabeticallyOrdered(input) ? "is" : "is not"));
        }
    }
}


