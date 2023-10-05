using System;
using System.Collections.Generic;
using System.Linq;

class GrammarAnalyzer
{
    static Dictionary<string, List<string>> grammarRules = new Dictionary<string, List<string>>();

    static Dictionary<string, HashSet<string>> firstSets = new Dictionary<string, HashSet<string>>();
    static Dictionary<string, HashSet<string>> followSets = new Dictionary<string, HashSet<string>>();

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
        CalculateFollowSets();

        // Print the FIRST sets
        Console.WriteLine("\nFIRST Sets:");
        foreach (var nonTerminal in firstSets.Keys)
        {
            Console.WriteLine($"{nonTerminal}: {{{string.Join(", ", firstSets[nonTerminal])}}}");
        }

        // Print the FOLLOW sets
        Console.WriteLine("\nFOLLOW Sets:");
        foreach (var nonTerminal in followSets.Keys)
        {
            Console.WriteLine($"{nonTerminal}: {{{string.Join(", ", followSets[nonTerminal])}}}");
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
            if (string.IsNullOrEmpty(production))
            {
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

    static void CalculateFollowSets()
    {
        foreach (var nonTerminal in grammarRules.Keys)
        {
            CalculateFollowSet(nonTerminal);
        }
    }

    static void CalculateFollowSet(string nonTerminal)
    {
        if (!followSets.ContainsKey(nonTerminal))
            followSets[nonTerminal] = new HashSet<string>();

        if (nonTerminal == "S")
        {
            followSets[nonTerminal].Add("$"); // $ represents the end of input
        }

        foreach (var entry in grammarRules)
        {
            var nonTerm = entry.Key;
            var productions = entry.Value;

            foreach (var production in productions)
            {
                int index = production.IndexOf(nonTerminal);
                while (index != -1)
                {
                    if (index == production.Length - 1)
                    {
                        // If the non-terminal is at the end of the production, add follow(S) to follow(A)
                        if (nonTerminal != nonTerm)
                            followSets[nonTerminal].UnionWith(followSets[nonTerm]);
                    }
                    else
                    {
                        char nextSymbol = production[index + 1];
                        if (char.IsUpper(nextSymbol))
                        {
                            // If the next symbol is a non-terminal, add FIRST of that non-terminal to follow(A)
                            followSets[nonTerminal].UnionWith(firstSets[nextSymbol.ToString()]);

                            // If FIRST of that non-terminal contains epsilon, also add follow(S) to follow(A)
                            if (firstSets[nextSymbol.ToString()].Contains(""))
                            {
                                followSets[nonTerminal].UnionWith(followSets[nonTerm]);
                            }
                        }
                        else
                        {
                            // If the next symbol is a terminal, add it to follow(A)
                            followSets[nonTerminal].Add(nextSymbol.ToString());
                        }
                    }

                    index = production.IndexOf(nonTerminal, index + 1);
                }
            }
        }
    }
}

