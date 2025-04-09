using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declare a variable to hold the user's name
            string name;

            // Prompt the user for their name
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();

            // Display a greeting message
            Console.WriteLine($"Hello, {name}!");

            // Wait for user input before closing the console window
            Console.ReadKey();
        }
    }
}
