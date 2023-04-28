using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;

public static class FoodChain
{
    public static string Recite(int verseNumber)
    {
        var song = new StringBuilder();

        // Store lookup of common sentence chunks
        var sentenceChunks = new List<string>
        {
            "I know an old lady who swallowed a",
            "It wriggled and jiggled and tickled inside her.",
            "She swallowed the",
            "to catch the",
            "I don't know why she swallowed the",
        };

        // Store lookup of common animal words
        var animals = new List<string>
        {
            "fly",
            "spider"
        };

        for (var index=0; index < verseNumber; index++)
        {
            song.Append($"{sentenceChunks[index]} {animals[index]}.\n");
         
        }

        song.Append($"{sentenceChunks[sentenceChunks.Count-1]} {animals[0]}. ");
        song.Append("Perhaps she'll die.");

        return song.ToString();

        // Find pattern and loop through assembling song with sentence
        // chunks and animal words


        //var firstPhrase = "I know an old lady who swallowed a";
        ////var lastTwoSentences = 
        //var animals = new List<string>() { "fly" };

        //var song = new StringBuilder();

        //for(var i=0; i< verseNumber; i++)
        //{
        //    song.Append($"I know an old lady who swallowed a {animals[i]}.\n");
        //    song.Append($"I don't know why she swallowed the {animals[i]}. ");
        //    song.Append("Perhaps she'll die.");

        //}


        //   "I know an old lady who swallowed a spider.\n" +
        //"It wriggled and jiggled and tickled inside her.\n" +
        //"She swallowed the spider to catch the fly.\n" +
        //"I don't know why she swallowed the fly. Perhaps she'll die.";
        // return song.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}