using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02
{
    internal class Program
    {
        public static void Main()
        {
            char currentChar = 'A';
            printNumbersTreeRec(ref currentChar, 1);
            Console.ReadLine();
        }
        
        public static void printNumbersTreeRec(ref char io_currentChar, int io_currentNumber)
        {
            if(io_currentChar == 'H')
            {
                return;
            }
            else
            {
                if('G'- io_currentChar > 1)
                {
                    Console.WriteLine(io_currentChar + stringOfSpaces(io_currentChar) + stringOfNumbersToPrint(io_currentChar, ref io_currentNumber));
                    Console.WriteLine();
                    io_currentChar = (char)(io_currentChar + 1);
                    printNumbersTreeRec(ref io_currentChar, io_currentNumber);
                }
                else
                {
                    Console.WriteLine(io_currentChar + stringOfSpaces('B') + " |" +  io_currentNumber + "|");
                    Console.WriteLine();
                    io_currentChar = (char)(io_currentChar + 1);
                    printNumbersTreeRec(ref io_currentChar, io_currentNumber);

                }
                
            }
        }
        public static string stringOfSpaces(char i_currentChar)
        {
            int distanceBetweenCurrentAndLastChar = ('E' - i_currentChar);
            string stringWithSpaces = " ";
            for (int i = 0; i < distanceBetweenCurrentAndLastChar; i++)
            {
                stringWithSpaces += "  ";
            }
            return stringWithSpaces;
        }

        public static string stringOfNumbersToPrint(char i_currentChar, ref int io_currentNumber)
        {
            if(io_currentNumber > 9)
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
                    stringToPrint = stringToPrint + Convert.ToString(io_currentNumber)+ " ";
                    io_currentNumber++;
                }
                
            }

            return stringToPrint;
        }

    }
}
