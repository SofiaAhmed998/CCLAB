using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string document = "The quick brown fox jumps over the lazy dog. Mangoes are tasty, and tigers are fast.";

        string pattern = @"\b[tmTm]\w*\b";

        MatchCollection matches = Regex.Matches(document, pattern, RegexOptions.IgnoreCase);

        Console.WriteLine("Words starting with 't' and 'm':");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
