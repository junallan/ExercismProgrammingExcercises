using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private readonly string[] _grid;

    public WordSearch(string grid)
    {
        _grid = grid.Split('\n');
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var wordCoordintates = new Dictionary<string, ((int, int), (int, int))?>();

        foreach (var word in wordsToSearchFor)
        {
            wordCoordintates.Add(word, null);
            for (var i = 0; i < _grid.Length; i++)
            {
                var startIndexOfWord = _grid[i].IndexOf(word);

                if (startIndexOfWord >= 0)
                {
                    wordCoordintates[word] = ((startIndexOfWord + 1, i + 1), (startIndexOfWord + word.Length, i + 1));
                }
            }
        }

        return wordCoordintates;
    }
}