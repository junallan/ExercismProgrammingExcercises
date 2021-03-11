using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> dnaStrands = new Dictionary<char, int> { ['A'] = 0, ['C'] = 0, ['G'] = 0, ['T'] = 0 };

        if (string.IsNullOrEmpty(sequence)){ return dnaStrands; }

        foreach(var strand in sequence)
        {
            if (!dnaStrands.ContainsKey(strand)) {  throw new ArgumentException(); }

            dnaStrands[strand]++;
        }

        return dnaStrands;
    }
}