using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        const string StopSequence = "STOP";
        const int CodonSize = 3;

        Dictionary<string, string> proteinMapping = new Dictionary<string, string>()
        {
            { "AUG", "Methionine" },
            { "UUU", "Phenylalanine"},
            { "UUC", "Phenylalanine"},
            { "UUA", "Leucine"},
            { "UUG", "Leucine"},
            { "UCU", "Serine"},
            { "UCC", "Serine"},
            { "UCA", "Serine"},
            { "UCG", "Serine"},
            { "UAU", "Tyrosine"},
            { "UAC", "Tyrosine"},
            { "UGU", "Cysteine"},
            { "UGC", "Cysteine"},
            { "UGG", "Tryptophan"},
            { "UAA", StopSequence},
            { "UAG", StopSequence},
            { "UGA", StopSequence},
        };

        return Enumerable.Range(0, strand.Length / CodonSize)
                               .Select(i => proteinMapping[strand.Substring(i * CodonSize, CodonSize)])
                               .TakeWhile(c => c != StopSequence)
                               .ToArray();
    }
}