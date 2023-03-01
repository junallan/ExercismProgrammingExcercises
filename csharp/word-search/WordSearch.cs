using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private readonly string[] _grid;
    private readonly int _rowSize;
    private readonly int _columnSize;

    public WordSearch(string grid)
    {
        _grid = grid.Split('\n');
        _rowSize = _grid.Length;
        _columnSize = _grid.ElementAt(0).Length;
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var wordCoordinates = new Dictionary<string, ((int, int), (int, int))?>();

        foreach (var word in wordsToSearchFor)
        {
            wordCoordinates.Add(word, null);

            for (var i = 0; i < _rowSize; i++)
            {
                if (wordCoordinates[word] != null) break;

                for (var j = 0; j < _columnSize; j++)
                {
                    var result = WordToSearch(word, (i, j));
                    if (result.IsMatch)
                    {
                        wordCoordinates[word] = ((j + 1, i + 1), result.endPoint.Value);
                    }
                }
            }
        }

        return wordCoordinates;
    }

    private (bool IsMatch, (int X, int Y)? endPoint) WordToSearch(string word, (int X, int Y) point)
    {
        var x = point.X;
        var y = point.Y;

        var isDifference = false;

        var wordCounter = 0;
        for (int i = 0; i < word.Length; i++)
        {
            // Left to right search
            if (y == _columnSize)
            {
                isDifference = true;
                break;
            }

            if (word[wordCounter++] != _grid[x][y++])
            {
                isDifference = true;
                break;
            }
        }

        if(!isDifference) return (true, (y, x + 1));

        return (false, null);

    }
}
