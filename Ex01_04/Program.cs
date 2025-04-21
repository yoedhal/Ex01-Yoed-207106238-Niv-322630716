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
            get12CharactersFromUser(out string userString);
            printIfPalindrome(userString);
            if (isAllDigits(userString))
            {
                printIfDivisibleBy3(userString);
            }
            else if (isAllLetters(userString))
            {
                printUpperCaseCount(userString);
                printIfOrderedAlphabetically(userString);
            }
        }
        private static void get12CharactersFromUser(out string o_userString)
        {
            Console.WriteLine("Please enter a string of exactly 12 characters:");
            o_userString = Console.ReadLine();

            while (string.IsNullOrEmpty(o_userString) || o_userString.Length != 12)
            {
                Console.WriteLine("Invalid input. Please enter exactly 12 characters:");
                o_userString = Console.ReadLine();
            }
        }
        private static bool isPalindrome(string i_userString)
        {
            bool isPalindrome = true;
            for (int i = 0, j = i_userString.Length - 1; i < j; i++, j--)
            {
                if (char.ToLower(i_userString[i]) != char.ToLower(i_userString[j]))
                {
                    isPalindrome = false;
                }
            }
            return isPalindrome;
        }
        private static void printIfPalindrome(string i_userString)
        {
            string resultPolindromeForPrint = "is";
            if (isPalindrome(i_userString) == false)
            {
                resultPolindromeForPrint = "is not";
            }
            Console.WriteLine(string.Format("The string {0} a palindrome.", resultPolindromeForPrint));
        }
        private static bool isAllDigits(string i_userString)
        {
            bool isAllDigits = true;
            foreach (char c in i_userString)
            {
                if (!char.IsDigit(c))
                {
                    isAllDigits = false;
                }
            }
            return isAllDigits;
        }
        private static bool isDigitSumDivisibleBy3(string i_userString)
        {
            int sumOfDigits = 0;
            bool isValidCheck = true;

            foreach (char c in i_userString)
            {
                if (int.TryParse(c.ToString(), out int digit))
                {
                    sumOfDigits += digit;
                }
                else
                {
                    isValidCheck = false;
                }
            }
            bool isDivisibleBy3 = sumOfDigits % 3 == 0;
            return isValidCheck && isDivisibleBy3;
        }

        private static void printIfDivisibleBy3(string i_userString)
        {
            string resultDevidedBy3ForPrint = "is";
            if (isDigitSumDivisibleBy3(i_userString) == false)
            {
                resultDevidedBy3ForPrint = "is not";
            }
            Console.WriteLine(string.Format("The number {0} divisible by 3.", resultDevidedBy3ForPrint));
        }
        private static bool isAllLetters(string i_userString)
        {
            bool isAllLetters = true;
            foreach (char c in i_userString)
            {
                if (!char.IsLetter(c))
                {
                    isAllLetters = false;
                }
            }
            return isAllLetters;
        }
        private static int countUpperCaseLetters(string i_userString)
        {
            int countOfUpperCaseLetters = 0;
            foreach (char c in i_userString)
            {
                if (char.IsUpper(c))
                {
                    countOfUpperCaseLetters++;
                }
            }
            return countOfUpperCaseLetters;
        }
        private static void printUpperCaseCount(string i_userString)
        {
            Console.WriteLine(string.Format("Number of uppercase letters: {0}", countUpperCaseLetters(i_userString)));
        }
        private static bool isAlphabeticallyOrdered(string i_userString)
        {
            bool isAlphabeticallyOrdered = true;
            for (int i = 0; i < i_userString.Length - 1; i++)
            {
                if (char.ToLower(i_userString[i]) > char.ToLower(i_userString[i + 1]))
                {
                    isAlphabeticallyOrdered = false;
                }
            }
            return isAlphabeticallyOrdered;
        }
        private static void printIfOrderedAlphabetically(string i_userString)
        {
            string resultAlphabeticallyForPrint = "is";
            if(isAlphabeticallyOrdered(i_userString) == false)
            {
                resultAlphabeticallyForPrint = "is not";
            }
            Console.WriteLine(string.Format("The string {0} in alphabetical order.", resultAlphabeticallyForPrint));
        }
    }
}

