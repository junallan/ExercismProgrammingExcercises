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
            "I know an old lady who swallowed a {animal1}.\n",
            "It wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the {animal2} to catch the {animal1}.\n",
            "I don't know why she swallowed the {animal1}. Perhaps she'll die.",
        };

        // Store lookup of common animal words
        var animals = new List<string>
        {
            "fly",
            "spider"
        };

        // Find pattern and loop through assembling song with sentence
        // chunks and animal words
        for (var index=verseNumber-1; 0 <= index; index--)
        {
            if(index == 0)
            {
                song.Insert(0, sentenceChunks[index]
                .Replace("{animal1}", animals[verseNumber-1]));
            }
            else
            {
                song.Insert(0, sentenceChunks[index]
                .Replace("{animal2}", animals[index])
                .Replace("{animal1}", (0 <= index - 1)
                                    ? animals[index-1]
                                    : animals[index]));
            }

        }

        song.Append(sentenceChunks[sentenceChunks.Count-1]
                .Replace("{animal1}", animals[0]));

        return song.ToString();


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