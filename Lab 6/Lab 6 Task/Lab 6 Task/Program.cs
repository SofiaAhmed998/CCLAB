using System;
using System.Collections.Generic;

class GrammarParser
{
    static void Main()
    {
        // Define grammar rules as a dictionary of non-terminals and their production rules
        Dictionary<string, List<string>> grammarRules = new Dictionary<string, List<string>>
        {
            { "S", new List<string> { "AB", "BC" } },
            { "A", new List<string> { "a", "ε" } },
            { "B", new List<string> { "b", "ε" } },
            { "C", new List<string> { "c" } },
        };

        // Calculate and print the FIRST sets
        Dictionary<string, HashSet<string>> firstSets = CalculateFirstSets(grammarRules);
        foreach (var nonTerminal in firstSets.Keys)
        {
            Console.WriteLine($"FIRST({nonTerminal}) = {{{string.Join(", ", firstSets[nonTerminal])}}}");
        }
    }

    static Dictionary<string, HashSet<string>> CalculateFirstSets(Dictionary<string, List<string>> grammarRules)
    {
        var firstSets = new Dictionary<string, HashSet<string>>();

        foreach (var nonTerminal in grammarRules.Keys)
        {
            firstSets[nonTerminal] = new HashSet<string>();
        }

        bool changed;
        do
        {
            changed = false;

            foreach (var nonTerminal in grammarRules.Keys)
            {
                foreach (var production in grammarRules[nonTerminal])
                {
                    foreach (var symbol in production)
                    {
                        if (IsTerminal(symbol.ToString()))
                        {
                            if (firstSets[nonTerminal].Add(symbol.ToString()))
                            {
                                changed = true;
                            }
                            break;
                        }
                        else if (IsNonTerminal(symbol.ToString()))
                        {
                            bool hasEpsilon = true;
                            foreach (var s in grammarRules[symbol.ToString()])
                            {
                                foreach (var subSymbol in s)
                                {
                                    if (!firstSets[symbol.ToString()].Add(subSymbol.ToString()))
                                    {
                                        break;
                                    }
                                    if (!IsEpsilon(subSymbol.ToString()))
                                    {
                                        hasEpsilon = false;
                                        break;
                                    }
                                }
                                if (!hasEpsilon)
                                {
                                    break;
                                }
                            }
                            if (hasEpsilon)
                            {
                                if (firstSets[nonTerminal].Add("ε"))
                                {
                                    changed = true;
                                }
                            }
                        }
                    }
                }
            }
        } while (changed);

        return firstSets;
    }

    static bool IsTerminal(string symbol)
    {
        return char.IsLower(symbol[0]) || symbol == "ε";
    }

    static bool IsNonTerminal(string symbol)
    {
        return char.IsUpper(symbol[0]);
    }

    static bool IsEpsilon(string symbol)
    {
        return symbol == "ε";
    }
}


