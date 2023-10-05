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
        // Add your grammar rules here
        grammarRules["S"] = new List<string> { "aABc", "BC" };
        grammarRules["A"] = new List<string> { "aA", "" };
        grammarRules["B"] = new List<string> { "bB", "" };
        grammarRules["C"] = new List<string> { "cC", "" };

        CalculateFirstSets();
        CalculateFollowSets();

        // Print the FIRST sets
        Console.WriteLine("FIRST Sets:");
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

