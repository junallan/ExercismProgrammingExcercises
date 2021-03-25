using System;
using System.Collections.Generic;
using System.Linq;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        Dictionary<char, char> dnaToRna = new Dictionary<char, char> {
                                                    { 'G', 'C' },
                                                    { 'C', 'G' },
                                                    { 'T', 'A' },
                                                    { 'A', 'U' }
        };
        
        return string.Concat(nucleotide.Select(n => dnaToRna[n]));
    }
}