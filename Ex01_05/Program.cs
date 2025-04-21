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
            get8DigitNumberFromUser(out string userNum);
            printDigitsSmallerThanFirst(userNum);
            printDigitsDivisibleBy3(userNum);
            printMaxMinDifference(userNum);
            printMostFrequentDigit(userNum);
        }

        private static void get8DigitNumberFromUser(out string o_userNum)
        {
            Console.WriteLine("Please enter a number with exactly 8 digits:");
            o_userNum = Console.ReadLine();

            while (isValid8DigitNumber(o_userNum)==false)
            {
                Console.WriteLine("Invalid input. Please enter exactly 8 digits:");
                o_userNum = Console.ReadLine();
            }
        }

        private static bool isValid8DigitNumber(string i_str)
        {
            bool isValid = true;

            if (i_str.Length != 8)
            {
                isValid = false;
            }

            foreach (char c in i_str)
            {
                if (!char.IsDigit(c))
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        private static void getDigitsSmallerThanFirst(string i_userNum, out StringBuilder o_smallerDigits, out int o_countOfNumBiggerThanFirstDig)
        {
            char firstDigit = i_userNum[0];
            o_smallerDigits = new StringBuilder();
            o_countOfNumBiggerThanFirstDig = 0;

            for (int i = 1; i < i_userNum.Length; i++)
            {
                if (i_userNum[i] < firstDigit)
                {
                    o_smallerDigits.Append(i_userNum[i]);
                    o_smallerDigits.Append(' ');
                    o_countOfNumBiggerThanFirstDig++;
                }
            }
        }

        private static void printDigitsSmallerThanFirst(string i_userNum)
        {
            getDigitsSmallerThanFirst(i_userNum, out StringBuilder o_smallerDigits, out int o_countOfNumBiggerThanFirstDig);
            Console.WriteLine($"There are {o_countOfNumBiggerThanFirstDig} digit(s) smaller than the first digit ({i_userNum[0]}): {o_smallerDigits}");
        }

        private static void getDigitsDivisibleBy3(string i_userNum, out StringBuilder o_digitsdevidedby3, out int o_countOfDigsDevidedBy3)
        {
            o_digitsdevidedby3 = new StringBuilder();
            o_countOfDigsDevidedBy3 = 0;

            for (int i = 0; i < i_userNum.Length; i++)
            {
                int currentDigitInNum = i_userNum[i] - '0';

                if (currentDigitInNum % 3 == 0)
                {
                    o_digitsdevidedby3.Append(currentDigitInNum);
                    o_digitsdevidedby3.Append(' ');
                    o_countOfDigsDevidedBy3++;
                }
            }
        }

        private static void printDigitsDivisibleBy3(string i_userNum)
        {
            getDigitsDivisibleBy3(i_userNum, out StringBuilder o_digitsdevidedby3, out int o_countOfDigsDevidedBy3);
            Console.WriteLine($"There are {o_countOfDigsDevidedBy3} digit(s) divisible by 3: {o_digitsdevidedby3}");
        }

        private static void getMinMaxDigits(string i_userNum, out int o_minDigit, out int o_maxDigit)
        {
            o_minDigit = 9;
            o_maxDigit = 0;

            foreach (char c in i_userNum)
            {
                int currentDigitInNum = c - '0';
                o_minDigit = Math.Min(o_minDigit, currentDigitInNum);
                o_maxDigit = Math.Max(o_maxDigit, currentDigitInNum);
            }
        }

        private static void printMaxMinDifference(string i_userNum)
        {
            getMinMaxDigits(i_userNum, out int o_minDigit, out int o_maxDigit);
            int maxDifference = o_maxDigit - o_minDigit;
            Console.WriteLine($"The largest digit is {o_maxDigit}, the smallest is {o_minDigit}, difference is {maxDifference}.");
        }

        private static void getMostFrequentDigit(string i_userNum, out int o_mostFrequentDigit, out int o_countOfMostFrequentDigit)
        {
            int[] digitCountsForEach = new int[10];

            foreach (char c in i_userNum)
            {
                int digit = c - '0';
                digitCountsForEach[digit]++;
            }

            o_mostFrequentDigit = 0;
            o_countOfMostFrequentDigit = digitCountsForEach[0];

            for (int i = 1; i < 10; i++)
            {
                if (digitCountsForEach[i] > o_countOfMostFrequentDigit)
                {
                    o_countOfMostFrequentDigit = digitCountsForEach[i];
                    o_mostFrequentDigit = i;
                }
            }
        }

        private static void printMostFrequentDigit(string i_userNum)
        {
            getMostFrequentDigit(i_userNum, out int o_mostFrequentDigit, out int o_countOfMostFrequentDigit);
            Console.WriteLine($"The most frequent digit is {o_mostFrequentDigit}, and it appears {o_countOfMostFrequentDigit} time(s).");
        }
    }
}



