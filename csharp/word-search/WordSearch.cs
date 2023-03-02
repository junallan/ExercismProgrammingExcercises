using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    public enum Movement
    {
        Up = -1,
        Down = 1,
        Left = -1,
        Right = 1,
        Stay = 0
    }
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

                    // bottom to top search
                    result = WordToSearch(word, (i, j), -1, 0);
                    if (result.IsMatch) wordCoordinates[word] = ((j + 1, i + 1), result.endPoint.Value);

                    // top left to bottom right search
                    result = WordToSearch(word, (i, j), 1, 1);
                    if (result.IsMatch) wordCoordinates[word] = ((j + 1, i + 1), result.endPoint.Value);

                    // bottom right to top left search
                    result = WordToSearch(word, (i, j), -1, -1);
                    if (result.IsMatch) wordCoordinates[word] = ((j + 1, i + 1), result.endPoint.Value);

                    // bottom left to top right search
                    result = WordToSearch(word, (i, j), -1, 1);
                    if (result.IsMatch) wordCoordinates[word] = ((j + 1, i + 1), result.endPoint.Value);

                    // top right to bottom left search
                    result = WordToSearch(word, (i, j), 1, -1);
                    if (result.IsMatch) wordCoordinates[word] = ((j + 1, i + 1), result.endPoint.Value);
                }
            }
        }

        return wordCoordinates;
    }

    private (bool IsMatch, (int X, int Y)? endPoint) WordToSearch(string word, (int X, int Y) startPoint, int xMove, int yMove)
    {
        var x = startPoint.X;
        var y = startPoint.Y;

        for (int i = 0; i < word.Length; i++)
        {
            if (0 > y || y == _columnSize || 0 > x || x == _rowSize) return (false, null); 
            if (word[i] != _grid[x][y]) return (false, null);
            
            x += xMove;
            y += yMove;
        }

        (x, y) = (xMove, yMove) switch
        {
            (0,1) => (x+1,y),
            (0,-1) => (x+1, y+2),
            (1, 0) => (x, y+1),
            (-1, 0) => (x+2, y+1),
            (-1,-1) => (x+2, y+2),
            (-1, 1) => (x+2, y),
            (1, -1) => (x, y+2),
            _     => (x, y)
        };

        return (true, (y, x));
    }
}
