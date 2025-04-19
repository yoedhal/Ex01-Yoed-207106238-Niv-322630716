using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Program
    {
        public static void Main()
        { 
            int heightOfTheTree = getHeightOfTreeFromUser();
            char lastLetterInTree = numberToLetter(heightOfTheTree);
            char currentChar = 'A';
            printNumbersTreeRec(ref currentChar, lastLetterInTree, 1);
            Console.ReadLine();
        }

        private static int getHeightOfTreeFromUser()
        {
            Console.WriteLine("Please enter the height of the tree: ");
            int heightFromUser = int.Parse(Console.ReadLine());

            if(heightFromUser < 4 || heightFromUser > 15)
            {
                Console.WriteLine("The height is invalid!");
                getHeightOfTreeFromUser();
            } 

            return heightFromUser;
        }

        private static char numberToLetter(int i_Number)
        {
            return (char)('A' + i_Number - 1);
        }

        public static void printNumbersTreeRec(ref char io_currentChar, char i_lastLetterInTree, int io_currentNumber)
        {
            if (io_currentChar == (char)(i_lastLetterInTree + 1))
            {
                return;
            }
            else
            {
                if (i_lastLetterInTree - io_currentChar > 1)
                {
                    Console.WriteLine(io_currentChar + stringOfSpaces(io_currentChar, i_lastLetterInTree) + stringOfNumbersToPrint(io_currentChar, ref io_currentNumber));
                    Console.WriteLine();
                    io_currentChar = (char)(io_currentChar + 1);
                    printNumbersTreeRec(ref io_currentChar,i_lastLetterInTree, io_currentNumber);
                }
                else
                {
                    if(io_currentNumber > 9)
                    {
                        io_currentNumber = 1;
                    }
                    Console.WriteLine(io_currentChar + stringOfSpaces('B', i_lastLetterInTree) + " |" + io_currentNumber + "|");
                    Console.WriteLine();
                    io_currentChar = (char)(io_currentChar + 1);
                    printNumbersTreeRec(ref io_currentChar,i_lastLetterInTree, io_currentNumber);

                }

            }
        }
        public static string stringOfSpaces(char i_currentChar, char i_lastLetterInTree)
        {
            int distanceBetweenCurrentAndLastChar = (((char)(i_lastLetterInTree - 2)) - i_currentChar);
            string stringWithSpaces = " ";
            for (int i = 0; i < distanceBetweenCurrentAndLastChar; i++)
            {
                stringWithSpaces += "  ";
            }
            return stringWithSpaces;
        }

        public static string stringOfNumbersToPrint(char i_currentChar, ref int io_currentNumber)
        {
            if (io_currentNumber > 9)
            {
                io_currentNumber = 1;
            }
            string stringToPrint = Convert.ToString(io_currentNumber) + " ";
            io_currentNumber++;
            int numbersToPrint = (i_currentChar - 'A' + 1) * 2 - 1;
            for (int i = 1; i < numbersToPrint; i++)
            {
                if (io_currentNumber < 10)
                {
                    stringToPrint = stringToPrint + Convert.ToString(io_currentNumber) + " ";
                    io_currentNumber++;
                }
                else
                {
                    io_currentNumber = 1;
                    stringToPrint = stringToPrint + Convert.ToString(io_currentNumber) + " ";
                    io_currentNumber++;
                }

            }

            return stringToPrint;
        }

    }
}
