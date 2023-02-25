using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private readonly string[] _grid;
    private readonly string[] _transposedGrid;

    public WordSearch(string grid)
    {
        _grid = grid.Split('\n');
        _transposedGrid = TransposeGrid();
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var wordCoordintates = new Dictionary<string, ((int, int), (int, int))?>();

        // Row search
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
                    break;
                }
            }

            for (var i = 0; i < _transposedGrid.Length; i++)
            {
                // row word search
                var startIndexOfWord = _transposedGrid[i].IndexOf(word);

                if (startIndexOfWord >= 0)
                {
                    //wordCoordintates[word] = ((startIndexOfWord + 1, i + 1), (startIndexOfWord + word.Length, i + 1));
                    wordCoordintates[word] = ((i + 1, startIndexOfWord + 1), (i + 1, startIndexOfWord + word.Length));
                    break;
                }

                // reverse row word search
                var reservedWord = new String(word.Reverse().ToArray());
                var startIndexOfReverseWord = _transposedGrid[i].IndexOf(reservedWord);

                if (startIndexOfReverseWord >= 0)
                {
                    //wordCoordintates[word] = ((word.Length - startIndexOfReverseWord, i + 1), (startIndexOfReverseWord + 1, i + 1));
                    wordCoordintates[word] = ((i + 1, word.Length + startIndexOfReverseWord), (i + 1, startIndexOfReverseWord + 1));
                }
            }
        }

        return wordCoordintates;
    }

    private string[] TransposeGrid()
    {
        var transposedGrid = new string[_grid[0].Length];

        for (var i = 0; i < _grid.Length; i++)
        {
            for (var j = 0; j < _grid[i].Length; j++)
            {
                transposedGrid[j] += _grid[i][j];
            }
        }

        return transposedGrid;
    }
}