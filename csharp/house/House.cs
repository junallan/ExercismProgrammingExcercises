using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class House
{
    public const int NumberOfVerses = 12;
     
    public static string Recite(int verseNumber)
    {
        Dictionary<int, string> sentenceNouns = new Dictionary<int, string>() { { 1, "malt" }, { 2, "rat" }, { 3, "cat" }, { 4, "dog"}, { 5, "cow with the crumpled horn"}, { 6, "maiden all forlorn" } };
        Dictionary<int, string> sentenceVerbs = new Dictionary<int, string>() { { 1, "ate" }, { 2, "killed" }, { 3, "worried"}, { 4, "tossed"}, { 5, "milked" } };
        
        int indexEnd = (verseNumber + (NumberOfVerses - 1)) % NumberOfVerses;

        if (indexEnd == 0)
        {
            return "This is the house that Jack built.";
        }

        List<string> sentences = new List<string>();

        sentences.Add($"This is the {sentenceNouns[indexEnd]}");


        if (indexEnd > 1)
        {
            for (var i = indexEnd-1; 0 < i; i--)
            {
                sentences.Add($"that {sentenceVerbs[i]} the {sentenceNouns[i]}");
            }
        }

        sentences.Add("that lay in the house that Jack built.");

        return string.Join(" ", sentences);
    }

    public static string Recite(int startVerse, int endVerse)
    {
        return string.Empty;
    }
}

