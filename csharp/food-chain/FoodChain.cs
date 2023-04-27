using System;
using System.Collections.Generic;
using System.Text;

public static class FoodChain
{
    public static string Recite(int verseNumber)
    {
        var animals = new List<string>() { "fly" };

        var song = new StringBuilder();

        for(var i=0; i< verseNumber; i++)
        {
            song.Append($"I know an old lady who swallowed a {animals[i]}.\n");
            song.Append($"I don't know why she swallowed the {animals[i]}. ");
            song.Append("Perhaps she'll die.");

        }
        //        "I know an old lady who swallowed a fly.\n" +
        //        "I don't know why she swallowed the fly. Perhaps she'll die.";

        return song.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}