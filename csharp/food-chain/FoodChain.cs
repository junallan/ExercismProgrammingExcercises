using System.Collections.Generic;
using System.Text;


public static class FoodChain
{
    private static readonly List<IAnimal> Animals = new List<IAnimal>
    {
        new Fly(),
        new Spider(),
        new Bird(),
        new Cat(),
        new Dog(),
        new Goat(),
        new Cow(),
        new Horse()
    };

    private interface IAnimal
    {
        public string Name { get; }
        public string UniquePhrase { get; }
    }

    private struct Fly : IAnimal
    {
        public string Name => "fly";
        public string UniquePhrase => string.Empty;
    }

    private struct Spider : IAnimal
    {
        public string Name => "spider";
        public string UniquePhrase => string.Empty;
    }

    private struct Bird : IAnimal
    {
        public string Name => "bird";
        public string UniquePhrase => "How absurd to swallow a bird!\n";
    }

    private struct Cat : IAnimal
    {
        public string Name => "cat";
        public string UniquePhrase => "Imagine that, to swallow a cat!\n";
    }

    private struct Dog : IAnimal
    {
        public string Name => "dog";
        public string UniquePhrase => "What a hog, to swallow a dog!\n";
    }

    private struct Goat : IAnimal
    {
        public string Name => "goat";
        public string UniquePhrase => "Just opened her throat and swallowed a goat!\n";
    }

    private struct Cow : IAnimal
    {
        public string Name => "cow";
        public string UniquePhrase => "I don't know how she swallowed a cow!\n";
    }

    private struct Horse : IAnimal
    {
        public string Name => "horse";
        public string UniquePhrase => "She's dead, of course!";
    }


    public static string Recite(int verseNumber)
    {    
        var currentAnimal = Animals[verseNumber - 1];

        var introLyric = $"I know an old lady who swallowed a {currentAnimal.Name}.\n";
        var outroLyric =
            currentAnimal.GetType() == typeof(Horse)
            ? "She's dead, of course!"
            : $"I don't know why she swallowed the {Animals[0].Name}. Perhaps she'll die.";

        if (currentAnimal.GetType() == typeof(Fly) || currentAnimal.GetType() == typeof(Horse))
            return $"{introLyric}{outroLyric}";
    
        var spiderLyric = $"{(currentAnimal.GetType() == typeof(Spider) ? "It" : "that")} " +
            $"wriggled and jiggled and tickled inside her.\n";
        
        var swallowedToCatchLyric = SwallowedToCatchLyrics(verseNumber, spiderLyric);

        return $"{introLyric}{(currentAnimal.GetType() == typeof(Spider)
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
            var catchedEndPhrase = $"{animalCatched.Name}{(animalCatched.GetType() == typeof(Spider) ? $" {spiderLyric}" : ".\n")}";
            swallowedToCatchLyric.Append($"She swallowed the {Animals[index].Name} to catch the {catchedEndPhrase}");
        }

        return swallowedToCatchLyric;
    }
}