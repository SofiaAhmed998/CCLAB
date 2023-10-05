using System;
using System.Collections.Generic;
using System.Linq;

class GrammarAnalyzer
{
    static Dictionary<string, List<string>> grammarRules = new Dictionary<string, List<string>>();
    static Dictionary<string, HashSet<string>> firstSets = new Dictionary<string, HashSet<string>>();

    static void Main()
    {
        Console.WriteLine("Enter the grammar rules (one rule per line, non-terminal followed by '->' and its productions separated by '|'):");
        Console.WriteLine("Example: S -> aABc | BC");
        Console.WriteLine("Enter 'q' to quit.");

        while (true)
        {
            Console.Write("Enter a rule (or 'q' to quit): ");
            string rule = Console.ReadLine().Trim();

            if (rule.ToLower() == "q")
                break;

            ParseGrammarRule(rule);
        }

        CalculateFirstSets();

        // Print the FIRST sets
        Console.WriteLine("\nFIRST Sets:");
        foreach (var nonTerminal in firstSets.Keys)
        {
            Console.WriteLine($"{nonTerminal}: {{{string.Join(", ", firstSets[nonTerminal])}}}");
        }
    }

    static void ParseGrammarRule(string rule)
    {
        string[] parts = rule.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 2)
        {
            Console.WriteLine("Invalid input. Please enter a valid grammar rule.");
            return;
        }

        string nonTerminal = parts[0].Trim();
        string[] productions = parts[1].Split('|').Select(p => p.Trim()).ToArray();

        if (!grammarRules.ContainsKey(nonTerminal))
        {
            grammarRules[nonTerminal] = new List<string>();
        }

        grammarRules[nonTerminal].AddRange(productions);
    }

    static void CalculateFirstSets()
    {
        foreach (var nonTerminal in grammarRules.Keys)
        {
            CalculateFirstSet(nonTerminal);
        }
    }

    static void CalculateFirstSet(string nonTerminal)
    {
        if (!firstSets.ContainsKey(nonTerminal))
            firstSets[nonTerminal] = new HashSet<string>();

        foreach (var production in grammarRules[nonTerminal])
        {
            CalculateFirstSetForProduction(nonTerminal, production);
        }
    }

    static void CalculateFirstSetForProduction(string nonTerminal, string production)
    {
        if (string.IsNullOrEmpty(production))
        {
            // If the production is empty, add epsilon to FIRST(nonTerminal)
            firstSets[nonTerminal].Add("");
        }
        else if (char.IsUpper(production[0]))
        {
            // First symbol is a non-terminal
            string firstSymbol = production[0].ToString();
            CalculateFirstSet(firstSymbol);
            firstSets[nonTerminal].UnionWith(firstSets[firstSymbol]);
        }
        else
        {
            // First symbol is a terminal
            firstSets[nonTerminal].Add(production[0].ToString());
        }
    }
}
