using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class House
{
    public const int NumberOfVerses = 12;
     
    public static string Recite(int verseNumber)
    {
        return Recite(1, verseNumber);
    }

    public static string Recite(int startVerse, int endVerse)
    {
        Dictionary<int, string> sentenceNouns = new Dictionary<int, string>() { { 1, "malt" } };
        Dictionary<int, string> sentenceVerbs = new Dictionary<int, string>() { };

        int indexStart = (startVerse + (NumberOfVerses - 1)) % NumberOfVerses;
        int indexEnd = (endVerse + (NumberOfVerses - 1)) % NumberOfVerses;
       
        if (indexStart == 0 && indexStart == indexEnd)
        {
            return "This is the house that Jack built.";
        }


        List<string> sentences = new List<string>();

        sentences.Add($"This is the {sentenceNouns[indexEnd]}");
        sentences.Add("that lay in the house that Jack built.");

        return string.Join(" ", sentences);
    }
}