using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class House
{
    public const int NumberOfVerses = 12;
     
    public static string Recite(int verseNumber)
    {
        string[] sentenceNouns ={ "house that Jack built.", "malt", "rat", "cat", "dog", "cow with the crumpled horn", "maiden all forlorn", 
                                   "man all tattered and torn", "priest all shaven and shorn", "rooster that crowed in the morn", 
                                   "farmer sowing his corn", "horse and the hound and the horn"};
    
        string[] sentenceVerbs = { "lay in", "ate", "killed", "worried", "tossed", "milked", "kissed", "married", "woke", "kept", "belonged to"  };

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
        //var entirePoem = string.Concat(Enumerable.Range(startVerse, endVerse).Select(i => $"{Recite(i)}\n"));

        //return entirePoem.Substring(0, entirePoem.Length - 1);
        StringBuilder nurseryRhyme = new StringBuilder();

        for (int i = startVerse; i <= endVerse; i++)
        {
            nurseryRhyme.Append($"{Recite(i)}\n");
        }

        return nurseryRhyme.ToString().Substring(0, nurseryRhyme.Length - 1);
    }
}
