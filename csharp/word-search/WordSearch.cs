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
                // row word search
                var startIndexOfWord = _grid[i].IndexOf(word);

                if (startIndexOfWord >= 0)
                {
                    wordCoordintates[word] = ((startIndexOfWord + 1, i + 1), (startIndexOfWord + word.Length, i + 1));
                    break;
                }

                // reverse row word search
                var reservedWord = new String(word.Reverse().ToArray());
                var startIndexOfReverseWord = _grid[i].IndexOf(reservedWord);

                if (startIndexOfReverseWord >= 0)
                {
                    wordCoordintates[word] = ((word.Length - startIndexOfReverseWord, i + 1), (startIndexOfReverseWord +1, i + 1));
                }

            }
        }

        return wordCoordintates;
    }

    
}