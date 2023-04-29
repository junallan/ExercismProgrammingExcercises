using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;

using Xunit;

public static class FoodChain
{
    public static readonly string Horse = "horse";
    public static readonly string Spider = "spider";

    public static string Recite(int verseNumber)
    {
        // Animals in the song
        var animals = new List<string>
        {
            "fly",
            Spider,
            "bird",
            "cat",
            "dog",
            "goat",
            "cow",
            Horse
        };

        var currentAnimal = animals[verseNumber - 1];

        // Verse construction consisting of beginning lyrics, unique second lyric,
        // common lyrics in between, and ending lyrics
        var introLyric = $"I know an old lady who swallowed a {currentAnimal}.\n";
        var outroLyric =
            currentAnimal == Horse
            ? "She's dead, of course!"
            : $"I don't know why she swallowed the {animals[0]}. Perhaps she'll die.";

        // Just and intro and outro for initial and ending verse, nothing in between
        if (verseNumber == 1 || currentAnimal == Horse)
            return $"{introLyric}{outroLyric}";

        var spiderLyric = $"{(currentAnimal == Spider ? "It" : "that")} " +
            $"wriggled and jiggled and tickled inside her.\n";

        var uniqueAnimalLyric = currentAnimal switch
        {
            "bird" => "How absurd to swallow a bird!\n",
            "cat" => "Imagine that, to swallow a cat!\n",
            "dog" => "What a hog, to swallow a dog!\n",
            "goat" => "Just opened her throat and swallowed a goat!\n",
            "cow" => "I don't know how she swallowed a cow!\n",
            _ => spiderLyric,
        };

        // Common pattern for swallowed to catch lyric
        var swallowedToCatchLyric = new StringBuilder();

        for (var index=verseNumber - 1; 1 <= index; index--)
        {
            var animalCatched = animals[index - 1];
            var catchedEndPhrase = $"{animalCatched}{(animalCatched == Spider ? $" {spiderLyric}" : ".\n" )}";
            swallowedToCatchLyric.Append($"She swallowed the {animals[index]} to catch the {catchedEndPhrase}");
        }

        return $"{introLyric}{uniqueAnimalLyric}{swallowedToCatchLyric}{outroLyric}";
    }


    public static string Recite(int startVerse, int endVerse)
    {
        var songVerses = new StringBuilder(Recite(startVerse));

        for(int currentVerse=startVerse+1; currentVerse<=endVerse; currentVerse++)
        {
            songVerses.Append($"\n\n{Recite(currentVerse)}");
        }

        return songVerses.ToString();
    }
}