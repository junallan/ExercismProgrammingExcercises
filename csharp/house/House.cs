using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class House
{
    public const int NumberOfVerses = 12;
     
    public static string Recite(int verseNumber)
    {
        Dictionary<int, string> sentenceNouns = new Dictionary<int, string>() { {0, "house that Jack built." }, { 1, "malt" }, { 2, "rat" }, { 3, "cat" }, { 4, "dog"}, { 5, "cow with the crumpled horn"}, { 6, "maiden all forlorn" }, { 7, "man all tattered and torn"}, { 8, "priest all shaven and shorn" }, { 9, "rooster that crowed in the morn" }, { 10, "farmer sowing his corn" }, { 11, "horse and the hound and the horn" } };
        Dictionary<int, string> sentenceVerbs = new Dictionary<int, string>() { { 0, "lay in" }, { 1, "ate" }, { 2, "killed" }, { 3, "worried"}, { 4, "tossed"}, { 5, "milked" }, { 6, "kissed" }, { 7, "married" }, { 8, "woke"}, { 9, "kept" }, { 10, "belonged to" } };
        
        int indexEnd = (verseNumber + (NumberOfVerses - 1)) % NumberOfVerses;

        List<string> sentences = new List<string>();

        sentences.Add($"This is the {sentenceNouns[indexEnd]}");
   
        for (var i = indexEnd-1; 0 <= i; i--)
        {
            sentences.Add($"that {sentenceVerbs[i]} the {sentenceNouns[i]}");
        }
    
        return string.Join(" ", sentences);
    }

    public static string Recite(int startVerse, int endVerse)
    {
        return string.Empty;
    }
}

