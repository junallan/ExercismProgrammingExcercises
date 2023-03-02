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
                    // left to right search
                    var result = WordToSearch(word, (i, j), 0, 1);
                    if (result.IsMatch) wordCoordinates[word] = ((j + 1, i + 1), result.endPoint.Value);

                    // right to left search
                    result = WordToSearch(word, (i, j), 0, -1);
                    if (result.IsMatch) wordCoordinates[word] = ((j + 1, i + 1), result.endPoint.Value);

                    // top to bottom search
                    result = WordToSearch(word, (i, j), 1, 0);
                    if (result.IsMatch) wordCoordinates[word] = ((j + 1, i + 1), result.endPoint.Value);
                }
            }
        }

        return wordCoordinates;
    }

    private (bool IsMatch, (int X, int Y)? endPoint) WordToSearch(string word, (int X, int Y) point, int xMove, int yMove)
    {
        var x = point.X;
        var y = point.Y;

        var isDifference = false;

        var wordCounter = 0;
        for (int i = 0; i < word.Length; i++)
        {
            // Left to right search
            if (0 > y || y == _columnSize || 0 > x || x == _rowSize)
            {
                isDifference = true;
                break;
            }
            
            if (word[wordCounter++] != _grid[x][y])
            {
                isDifference = true;
                break;
            }

            x += xMove;
            y += yMove;
        }

        if (xMove == 0 && yMove == 1) x += 1;
        else if (xMove == 0 && yMove == -1)
        {
            x += 1;
            y += 2;
        }
        else if (xMove == 1 && yMove == 0)
        {
            y += 1;
        }

        if (!isDifference) return (true, (y, x));

        return (false, null);

    }
/*
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

        x = point.X;
        y = point.Y;

        isDifference = false;

        wordCounter = 0;

        for (int i = 0; i < word.Length; i++)
        {
            // Right to left search
            if (0 > y)
            {
                isDifference = true;
                break;
            }

            if (word[wordCounter++] != _grid[x][y--])
            {
                isDifference = true;
                break;
            }
        }

        if (!isDifference) return (true, (y+2, x + 1));

        x = point.X;
        y = point.Y;

        isDifference = false;

        wordCounter = 0;

        for (int i = 0; i < word.Length; i++)
        {
            // Top to bottom search
            if (x == _rowSize)
            {
                isDifference = true;
                break;
            }

            if (word[wordCounter++] != _grid[x++][y])
            {
                isDifference = true;
                break;
            }
        }

        if (!isDifference) return (true, (y + 1, x));

        return (false, null);

    }
*/
}
