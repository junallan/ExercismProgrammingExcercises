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
                        wordCoordinates[word] = ((i,j), result.endPoint.Value);
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

        // Left to right search
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] != _grid[x][y++]) return (false, null);
        }

        return (false, null);
    }
}
