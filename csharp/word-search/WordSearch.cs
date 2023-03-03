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
    private Dictionary<string, ((int, int), (int, int))?> _wordCoordinates;

    public WordSearch(string grid)
    {
        _grid = grid.Split('\n');
        _rowSize = _grid.Length;
        _columnSize = _grid.ElementAt(0).Length;
        _wordCoordinates = new Dictionary<string, ((int, int), (int, int))?>();
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        foreach (var word in wordsToSearchFor)
        {
            _wordCoordinates.Add(word, null);

            for (var i = 0; i < _rowSize; i++)
            {
                if (_wordCoordinates[word] != null) break;

                for (var j = 0; j < _columnSize; j++)
                {
                    // left to right search
                    var result = WordToSearch(word, (i, j), Movement.Stay, Movement.Right);
                    if (result.IsMatch) AddWordCoordinates(word, j, i, result.endPoint.Value);

                    // right to left search
                    result = WordToSearch(word, (i, j), Movement.Stay, Movement.Left);
                    if (result.IsMatch) AddWordCoordinates(word, j, i, result.endPoint.Value);

                    // top to bottom search
                    result = WordToSearch(word, (i, j), Movement.Down, Movement.Stay);
                    if (result.IsMatch) AddWordCoordinates(word, j, i, result.endPoint.Value);

                    // bottom to top search
                    result = WordToSearch(word, (i, j), Movement.Up, Movement.Stay);
                    if (result.IsMatch) AddWordCoordinates(word, j, i, result.endPoint.Value);

                    // top left to bottom right search
                    result = WordToSearch(word, (i, j), Movement.Down, Movement.Right);
                    if (result.IsMatch) AddWordCoordinates(word, j, i, result.endPoint.Value);

                    // bottom right to top left search
                    result = WordToSearch(word, (i, j), Movement.Up, Movement.Left);
                    if (result.IsMatch) AddWordCoordinates(word, j, i, result.endPoint.Value);

                    // bottom left to top right search
                    result = WordToSearch(word, (i, j), Movement.Up, Movement.Right);
                    if (result.IsMatch) AddWordCoordinates(word, j, i, result.endPoint.Value);

                    // top right to bottom left search
                    result = WordToSearch(word, (i, j), Movement.Down, Movement.Left);
                    if (result.IsMatch) AddWordCoordinates(word, j, i, result.endPoint.Value);
                }
            }
        }

        return _wordCoordinates;
    }

    private void AddWordCoordinates(string word, int j, int i, (int X, int Y) endPoint) =>_wordCoordinates[word] = (((j+1), (i+1)), endPoint);

    private (bool IsMatch, (int X, int Y)? endPoint) WordToSearch(string word, (int X, int Y) startPoint, Movement xMove, Movement yMove)
    {
        var x = startPoint.X;
        var y = startPoint.Y;

        for (int i = 0; i < word.Length; i++)
        {
            if (0 > y || y == _columnSize || 0 > x || x == _rowSize) return (false, null); 
            if (word[i] != _grid[x][y]) return (false, null);
            
            x += (int)xMove;
            y += (int)yMove;
        }

        (x, y) = (xMove, yMove) switch
        {
            (Movement.Stay,Movement.Right) => (x+1,y),
            (Movement.Stay,Movement.Left) => (x+1, y+2),
            (Movement.Down, Movement.Stay) => (x, y+1),
            (Movement.Up, Movement.Stay) => (x+2, y+1),
            (Movement.Up,Movement.Left) => (x+2, y+2),
            (Movement.Up, Movement.Right) => (x+2, y),
            (Movement.Down, Movement.Left) => (x, y+2),
            _     => (x, y)
        };

        return (true, (y, x));
    }
}
