using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class House
{
    public static string Recite(int verseNumber)
    {
        return Recite(1, verseNumber);
    }

    public static string Recite(int startVerse, int endVerse)
    {
        Dictionary<int, string> startSentence = new Dictionary<int, string>() { { 1, "house that Jack built." }, { 2, "malt" } };
        Dictionary<int, string> sentenceVerbs = new Dictionary<int, string>() { { 1, "lay" }/*, { 1, "malt" }*/ };

        Stack<string> sentences = new Stack<string>();

        if(startVerse == endVerse)
        {
            return $"This is the {startSentence[startVerse]}";       
        }

        return Recite(startVerse + 1, endVerse) + $" that {sentenceVerbs[startVerse]} in the {startSentence[startVerse]}";

        throw new NotImplementedException("You need to implement this function.");
    }
}