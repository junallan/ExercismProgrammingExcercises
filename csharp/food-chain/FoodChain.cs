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
        // Store lookup of common animal words
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

        // Store lookup of common sentence chunks
        var introVerse = $"I know an old lady who swallowed a {currentAnimal}.\n";
        var outroVerse =
            currentAnimal == Horse
            ? "She's dead, of course!"
            : $"I don't know why she swallowed the {animals[0]}. Perhaps she'll die.";

        if (verseNumber == 1 || currentAnimal == Horse)
            return $"{introVerse}{outroVerse}";

        var spiderSubVerse = $"{(currentAnimal == Spider ? "It" : "that")} " +
            $"wriggled and jiggled and tickled inside her.\n";

        var uniqueSecondVerse = currentAnimal switch
        {
            "bird" => "How absurd to swallow a bird!\n",
            "cat" => "Imagine that, to swallow a cat!\n",
            "dog" => "What a hog, to swallow a dog!\n",
            "goat" => "Just opened her throat and swallowed a goat!\n",
            "cow" => "I don't know how she swallowed a cow!\n",
            _ => spiderSubVerse,
        };

        // Common pattern for swallowed to catch verse
        var swallowedToCatchVerse = new StringBuilder();

        for (var index=verseNumber - 1; 1 <= index; index--)
        {
            var animalCatched = animals[index - 1];
            var catchedEndPhrase = $"{animalCatched}{(animalCatched == Spider ? $" {spiderSubVerse}" : ".\n" )}";
            swallowedToCatchVerse.Append($"She swallowed the {animals[index]} to catch the {catchedEndPhrase}");
        }

        return $"{introVerse}{uniqueSecondVerse}{swallowedToCatchVerse}{outroVerse}";
    }

    public static string Recite(int startVerse, int endVerse)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}