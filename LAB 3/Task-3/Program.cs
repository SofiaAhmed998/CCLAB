using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter a floating-point number:");
        string input = Console.ReadLine(); // Read user input

        string pattern = @"^(?:(?:\d{0,3}\.\d{1,3})|(?:\d{1,4})|(?:\d{0,2}\.\d{1,4})|(?:\.\d{1,5}))$";

        if (Regex.IsMatch(input, pattern))
        {
            Console.WriteLine("Valid floating-point number.");
        }
        else
        {
            Console.WriteLine("Invalid floating-point number.");
        }
    }
}
