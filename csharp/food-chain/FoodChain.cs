using System.Collections.Generic;
using System.Text;


public static class FoodChain
{
    private struct Animal
    {
        public string Name;
        public string UniquePhrase;
    }

    private enum AnimalType
    {
        fly,
        spider,
        bird,
        cat,
        dog,
        goat,
        cow,
        horse
    }

    private static readonly List<Animal> Animals = new List<Animal>
    {
        new Animal { Name = nameof(AnimalType.fly) },
        new Animal { Name = nameof(AnimalType.spider) },
        new Animal
        {
            Name = nameof(AnimalType.bird),
            UniquePhrase = "How absurd to swallow a bird!\n"
        },
        new Animal
        {
            Name = nameof(AnimalType.cat),
            UniquePhrase = "Imagine that, to swallow a cat!\n"
        },
        new Animal
        {
            Name = nameof(AnimalType.dog),
            UniquePhrase = "What a hog, to swallow a dog!\n"
        },
        new Animal
        {
            Name = nameof(AnimalType.goat),
            UniquePhrase = "Just opened her throat and swallowed a goat!\n"
        },
        new Animal
        {
            Name = nameof(AnimalType.cow),
            UniquePhrase = "I don't know how she swallowed a cow!\n"
        },
        new Animal
        {
            Name = nameof(AnimalType.horse),
            UniquePhrase = "She's dead, of course!"
        }
    };


    public static string Recite(int verseNumber)
    {    
        var currentAnimal = Animals[verseNumber - 1];

        var introLyric = $"I know an old lady who swallowed a {currentAnimal.Name}.\n";
        var outroLyric =
            currentAnimal.Name == nameof(AnimalType.horse)
            ? "She's dead, of course!"
            : $"I don't know why she swallowed the {Animals[0].Name}. Perhaps she'll die.";

        if (currentAnimal.Name == nameof(AnimalType.fly)
            || currentAnimal.Name == nameof(AnimalType.horse))
            return $"{introLyric}{outroLyric}";
    
        var spiderLyric = $"{(currentAnimal.Name == nameof(AnimalType.spider) ? "It" : "that")} " +
            $"wriggled and jiggled and tickled inside her.\n";
        
        var swallowedToCatchLyric = SwallowedToCatchLyrics(verseNumber, spiderLyric);

        return $"{introLyric}{(currentAnimal.Name == nameof(AnimalType.spider)
            ? spiderLyric : currentAnimal.UniquePhrase)}{swallowedToCatchLyric}{outroLyric}";
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


    private static StringBuilder SwallowedToCatchLyrics(int verseNumber, string spiderLyric)
    {
        var swallowedToCatchLyric = new StringBuilder();

        for (var index = verseNumber - 1; 1 <= index; index--)
        {
            var animalCatched = Animals[index - 1];
            var catchedEndPhrase = $"{animalCatched.Name}{(animalCatched.Name == nameof(AnimalType.spider) ? $" {spiderLyric}" : ".\n")}";
            swallowedToCatchLyric.Append($"She swallowed the {Animals[index].Name} to catch the {catchedEndPhrase}");
        }

        return swallowedToCatchLyric;
    }
}