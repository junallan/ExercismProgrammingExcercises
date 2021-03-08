using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> dnaStrands = new Dictionary<char, int> { ['A'] = 0, ['C'] = 0, ['G'] = 0, ['T'] = 0 };
        
        var invalidStrands = sequence.AsEnumerable().Where(strand => !dnaStrands.ContainsKey(strand));
        if (invalidStrands.Any()) { throw new ArgumentException(); }

        sequence.ToList().ForEach(strand => dnaStrands[strand]++);

        return dnaStrands;
    }
}