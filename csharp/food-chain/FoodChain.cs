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
    public static string Recite(int verseNumber)
    {
        var song = new StringBuilder();


        // Store lookup of common animal words
        var animals = new List<string>
        {
            "fly",
            "spider",
            "bird",
            "cat",
            "dog",
            "goat",
            "cow",
            "horse"
        };

        // Store lookup of common sentence chunks
        var introVerse = $"I know an old lady who swallowed a {animals[verseNumber - 1]}.\n";
        var outroVerse = animals[verseNumber - 1] == "horse" ? "She's dead, of course!" : $"I don't know why she swallowed the {animals[0]}. Perhaps she'll die.";

        if (verseNumber == 1 || animals[verseNumber - 1] == "horse") return $"{introVerse}{outroVerse}";

        var spiderSubVerse = $"{(animals[verseNumber - 1] == "spider" ? "It" : "that")} " +
            $"wriggled and jiggled and tickled inside her.\n";

        var uniqueSecondVerse = animals[verseNumber - 1] switch
        {
            "spider" => spiderSubVerse,
            "bird" => "How absurd to swallow a bird!\n",
            "cat" => "Imagine that, to swallow a cat!\n",
            "dog" => "What a hog, to swallow a dog!\n",
            "goat" => "Just opened her throat and swallowed a goat!\n",
            "cow" => "I don't know how she swallowed a cow!\n",
            _ => throw new ArgumentException("Invalide animal")
        };

        // Common pattern for swallowed to catch verse
        var swallowedToCatchVerse = new StringBuilder();

        for (var index=verseNumber - 1; 1 <= index; index--)
        {
            var animalCatched = animals[index - 1];
            var catchedEndPhrase = $"{animalCatched}{(animalCatched == "spider" ? $" {spiderSubVerse}" : ".\n" )}";
            swallowedToCatchVerse.Append($"She swallowed the {animals[index]} to catch the {catchedEndPhrase}");

            //     "I know an old lady who swallowed a spider.\n" +
            //"It wriggled and jiggled and tickled inside her.\n" +
            //"She swallowed the spider to catch the fly.\n" +
            //"I don't know why she swallowed the fly. Perhaps she'll die.";
        }

        return $"{introVerse}{uniqueSecondVerse}{swallowedToCatchVerse}{outroVerse}";
        //var sentenceChunks = new List<string>
        //{
        //    "I know an old lady who swallowed a {animal1}.\n",
        //    "It wriggled and jiggled and tickled inside her.\n" +
        //    "She swallowed the {animal2} to catch the {animal1}.\n",
        //    "I don't know why she swallowed the {animal1}. Perhaps she'll die.",
        //};


        //// Find pattern and loop through assembling song with sentence
        //// chunks and animal words
        //for (var index=verseNumber-1; 0 <= index; index--)
        //{
        //    if(index == 0)
        //    {
        //        song.Insert(0, sentenceChunks[index]
        //        .Replace("{animal1}", animals[verseNumber-1]));
        //    }
        //    else
        //    {
        //        song.Insert(0, sentenceChunks[index]
        //        .Replace("{animal2}", animals[index])
        //        .Replace("{animal1}", (0 <= index - 1)
        //                            ? animals[index-1]
        //                            : animals[index]));
        //    }

        //}

        //song.Append(sentenceChunks[sentenceChunks.Count-1]
        //        .Replace("{animal1}", animals[0]));

        //"fly",
        //    "spider",
        //    "bird",
        //    "cat",
        //    "dog",
        //    "goat",
        //    "cow"

        //"I know an old lady who swallowed a

        //"It wriggled and jiggled and tickled inside her.\n" +
        //"How absurd to swallow a bird!\n" +
        //"Imagine that, to swallow a cat!\n"
        //"What a hog, to swallow a dog!\n" +
        //"Just opened her throat and swallowed a goat!\n" +
        //"I don't know how she swallowed a cow!\n"

        //        "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
        //        "She swallowed the spider to catch the fly.\n" +
        //        "I don't know why she swallowed the fly. Perhaps she'll die.";


        //[Fact(Skip = "Remove this Skip property to run this test")]
        //public void Cow()
        //{
        //    var expected =
        //        "I know an old lady who swallowed a cow.\n" +
        //        "I don't know how she swallowed a cow!\n" +
        //        "She swallowed the cow to catch the goat.\n" +
        //        "She swallowed the goat to catch the dog.\n" +
        //        "She swallowed the dog to catch the cat.\n" +
        //        "She swallowed the cat to catch the bird.\n" +
        //        "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
        //        "She swallowed the spider to catch the fly.\n" +
        //        "I don't know why she swallowed the fly. Perhaps she'll die.";

        //////////////////////////////////

        //    var expected =
        //       "I know an old lady who swallowed a fly.\n" +
        //       "I don't know why she swallowed the fly. Perhaps she'll die.";
        //    Assert.Equal(expected, FoodChain.Recite(1));
        //}

        //[Fact]
        //public void Spider()
        //{
        //    var expected =
        //        "I know an old lady who swallowed a spider.\n" +
        //        "It wriggled and jiggled and tickled inside her.\n" +
        //        "She swallowed the spider to catch the fly.\n" +
        //        "I don't know why she swallowed the fly. Perhaps she'll die.";
        //    Assert.Equal(expected, FoodChain.Recite(2));

        //[Fact]
        //public void Bird()
        //{
        //    var expected =
        //        "I know an old lady who swallowed a bird.\n" +
        //        "How absurd to swallow a bird!\n" +
        //        "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
        //        "She swallowed the spider to catch the fly.\n" +
        //        "I don't know why she swallowed the fly. Perhaps she'll die.";
        //    Assert.Equal(expected, FoodChain.Recite(3));
        //}

        //[Fact(Skip = "Remove this Skip property to run this test")]
        //public void Cat()
        //{
        //    var expected =
        //        "I know an old lady who swallowed a cat.\n" +
        //        "Imagine that, to swallow a cat!\n" +
        //        "She swallowed the cat to catch the bird.\n" +
        //        "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
        //        "She swallowed the spider to catch the fly.\n" +
        //        "I don't know why she swallowed the fly. Perhaps she'll die.";
        //    Assert.Equal(expected, FoodChain.Recite(4));
        //}

        //[Fact(Skip = "Remove this Skip property to run this test")]
        //public void Dog()
        //{
        //    var expected =
        //        "I know an old lady who swallowed a dog.\n" +
        //        "What a hog, to swallow a dog!\n" +
        //        "She swallowed the dog to catch the cat.\n" +
        //        "She swallowed the cat to catch the bird.\n" +
        //        "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
        //        "She swallowed the spider to catch the fly.\n" +
        //        "I don't know why she swallowed the fly. Perhaps she'll die.";
        //    Assert.Equal(expected, FoodChain.Recite(5));
        //}

        //[Fact(Skip = "Remove this Skip property to run this test")]
        //public void Goat()
        //{
        //    var expected =
        //        "I know an old lady who swallowed a goat.\n" +
        //        "Just opened her throat and swallowed a goat!\n" +
        //        "She swallowed the goat to catch the dog.\n" +
        //        "She swallowed the dog to catch the cat.\n" +
        //        "She swallowed the cat to catch the bird.\n" +
        //        "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
        //        "She swallowed the spider to catch the fly.\n" +
        //        "I don't know why she swallowed the fly. Perhaps she'll die.";
        //    Assert.Equal(expected, FoodChain.Recite(6));
        //}

        //[Fact(Skip = "Remove this Skip property to run this test")]
        //public void Cow()
        //{
        //    var expected =
        //        "I know an old lady who swallowed a cow.\n" +
        //        "I don't know how she swallowed a cow!\n" +
        //        "She swallowed the cow to catch the goat.\n" +
        //        "She swallowed the goat to catch the dog.\n" +
        //        "She swallowed the dog to catch the cat.\n" +
        //        "She swallowed the cat to catch the bird.\n" +
        //        "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
        //        "She swallowed the spider to catch the fly.\n" +
        //        "I don't know why she swallowed the fly. Perhaps she'll die.";

        return song.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}