using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class Program
    {
        public static void Main()
        {
            getBinaryNumbersFromUser(out string[] binaryNumberArray);
            int[] decimalArray = convertBinaryArrayToDecimalArray(binaryNumberArray);
            sortDecimalArray(ref decimalArray);
            printDecimalArray(decimalArray, decimalArray.Length);

            float averageDecimalNumbers = getAverageDecimalNumbers(decimalArray);
            int theLongestSequenceOfOnes = getLongestSequenceOfOnes(binaryNumberArray, out string longestSequenceOfOnesNumber);
            
            object[] values = new object[3];
            values[0] = averageDecimalNumbers;
            values[1] = theLongestSequenceOfOnes;
            values[2] = longestSequenceOfOnesNumber;

            string formatted = string.Format(
@"The avaerage of the decimal numbers is: {0}
The longest sequence of ones is: {1} from {2}", values);
            Console.WriteLine(formatted);

            printFlipsCount(binaryNumberArray);
            PrintBinaryNumberWithMostOnes(binaryNumberArray);
            PrintTotalNumberOfOneBits(binaryNumberArray);
        }

        private static void getBinaryNumbersFromUser(out string[] o_BinaryNumbersArray)
        {
            o_BinaryNumbersArray = new string[4];
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Please enter a binary number");
                string currentNumberFromUser = (Console.ReadLine());
                if (isBinaryNumbersIsValid(currentNumberFromUser) == true)
                {
                    o_BinaryNumbersArray[i] = currentNumberFromUser;
                }
                else
                {
                    i--;
                    Console.WriteLine("Your binary number is invalid!");
                }
            }
        }
        private static bool isBinaryNumbersIsValid(string i_binaryNumber)
        {
            bool chechValidation = true;
            if (i_binaryNumber == null || i_binaryNumber.Length != 7)
            {
                chechValidation = false;
            }
            else
            {
                foreach (char c in i_binaryNumber)
                {
                    if (c != '0' && c != '1')
                    {
                        chechValidation = false;
                    }
                }

            }
            return chechValidation;
        }

       
        private static int[] convertBinaryArrayToDecimalArray(string[] binaryNumberArray)
        {
            int[] decimalResultArray = new int[binaryNumberArray.Length];

            for (int i = 0; i < binaryNumberArray.Length; i++)
            {
                string binary = binaryNumberArray[i];

                int decimalValue = 0;
                for (int j = 0; j < 7; j++)
                {
                    if (binary[j] == '1')
                    {
                        decimalValue += (int)Math.Pow(2, 6 - j);
                    }
                }
                decimalResultArray[i] = decimalValue;
            }
            return decimalResultArray;
        }

        private static void sortDecimalArray(ref int[] io_DecimalArray)
        {
            Array.Sort(io_DecimalArray);      
            Array.Reverse(io_DecimalArray);   
                                              
        }
        private static void printDecimalArray(int[] io_DecimalArray, int i_DecimalArrayLength)
        {
            Console.WriteLine("\nDecimal numbers in descending order:");
            for (int i = 0;i < io_DecimalArray.Length;i++)
            {
                Console.WriteLine(io_DecimalArray[i]);
            }
        }
        private static float getAverageDecimalNumbers(int[] i_DecimalArray)
        {
            int sumOfDecimalsNumbers = 0;
            for(int i = 0; i<i_DecimalArray.Length; i++)
            {
                sumOfDecimalsNumbers += i_DecimalArray[i];
            }

            float averageDecimalNumbers = (float)sumOfDecimalsNumbers / i_DecimalArray.Length;
            
            return averageDecimalNumbers;
        }

        private static int getLongestSequenceOfOnes(string [] i_binaryNumberArray, out string io_longestSequenceOfOnesNumber)
        {
                int maxSequence = 0;
                io_longestSequenceOfOnesNumber = i_binaryNumberArray[0]; // מאותחל לאיבר הראשון

                for (int i = 0; i < i_binaryNumberArray.Length; i++)
                {
                    int currentCount = 0;
                    int maxCountForCurrent = 0;

                    for (int j = 0; j < i_binaryNumberArray[i].Length; j++)
                    {
                        if (i_binaryNumberArray[i][j] == '1')
                        {
                            currentCount++;
                            if (currentCount > maxCountForCurrent)
                            {
                                maxCountForCurrent = currentCount;
                            }
                        }
                        else
                        {
                            currentCount = 0;
                        }
                    }
                    if (maxCountForCurrent > maxSequence)
                    {
                        maxSequence = maxCountForCurrent;
                        io_longestSequenceOfOnesNumber = i_binaryNumberArray[i];
                    }
                }
                return maxSequence; 
        }

        private static void printFlipsCount(string[] i_BinaryNumbers)
        {
            string resultMessage = "Numbers of flips: ";

            for (int i = 0; i < i_BinaryNumbers.Length; i++)
            {
                string binaryNumber = i_BinaryNumbers[i];
                int flipsCount = 0;

                for (int j = 1; j < binaryNumber.Length; j++)
                {
                    if (binaryNumber[j] != binaryNumber[j - 1])
                    {
                        flipsCount++;
                    }
                }

                resultMessage += string.Format("({0}) {1}", binaryNumber, flipsCount);

                if (i < i_BinaryNumbers.Length - 1)
                {
                    resultMessage += ", ";
                }
            }
            Console.WriteLine(resultMessage);
        }

        private static void PrintBinaryNumberWithMostOnes(string[] i_BinaryNumberArray)
        {
            string binaryNumberWithMostOnes = i_BinaryNumberArray[0];
            int maxOnesCount = CountOnes(i_BinaryNumberArray[0]);

            for (int i = 1; i < i_BinaryNumberArray.Length; i++)
            {
                int currentOnesCount = CountOnes(i_BinaryNumberArray[i]);
                if (currentOnesCount > maxOnesCount)
                {
                    maxOnesCount = currentOnesCount;
                    binaryNumberWithMostOnes = i_BinaryNumberArray[i];
                }
            }
            int decimalValue = ConvertBinaryToDecimal(binaryNumberWithMostOnes);
            Console.WriteLine(string.Format("The number with the most 1s is: {0} (binary: {1})", decimalValue, binaryNumberWithMostOnes));
        }

        private static int CountOnes(string i_BinaryNumber)
        {
            int onesCount = 0;
            for (int i = 0; i < i_BinaryNumber.Length; i++)
            {
                if (i_BinaryNumber[i] == '1')
                {
                    onesCount++;
                }
            }
            return onesCount;
        }

        private static int ConvertBinaryToDecimal(string i_BinaryNumber)
        {
            int decimalValue = 0;
            for (int i = 0; i < i_BinaryNumber.Length; i++)
            {
                if (i_BinaryNumber[i] == '1')
                {
                    decimalValue += (int)Math.Pow(2, i_BinaryNumber.Length - 1 - i);
                }
            }
            return decimalValue;
        }

        private static void PrintTotalNumberOfOneBits(string[] i_BinaryNumbersArray)
        {
            int totalOnesCount = 0;

            for (int i = 0; i < i_BinaryNumbersArray.Length; i++)
            {
                string currentBinaryNumber = i_BinaryNumbersArray[i];

                for (int j = 0; j < currentBinaryNumber.Length; j++)
                {
                    if (currentBinaryNumber[j] == '1')
                    {
                        totalOnesCount++;
                    }
                }
            }
            Console.WriteLine(string.Format("Total number of '1' bits that appeared in all four inputs together: {0}", totalOnesCount));
        }
    }
}
