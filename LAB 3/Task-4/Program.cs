using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a number in the XeY format (e.g., 8e4, 5e-2, 6e9):");
        string input = Console.ReadLine();

        string pattern = @"^[+-]?\d+(\.\d+)?[eE][+-]?\d+$";

        if (Regex.IsMatch(input, pattern))
        {
            Console.WriteLine("Valid number format.");
        }
        else
        {
            Console.WriteLine("Invalid number format. Please use XeY format.");
        }
    }
}
