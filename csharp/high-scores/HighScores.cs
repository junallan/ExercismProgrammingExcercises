using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private readonly List<int> _list;

    public HighScores(List<int> list)
    {
        _list = list;
    }

    public List<int> Scores()
    {
        return _list;
    }

    public int Latest()
    {
        return _list.Last();
    }

    public int PersonalBest()
    {
        return _list.OrderByDescending(x => x).First();
    }

    public List<int> PersonalTopThree()
    {
        return _list.Count > 3 ? _list.OrderBy(x => x).TakeLast(3).OrderByDescending(x => x).ToList() : _list.OrderBy(x => x).TakeLast(_list.Count).OrderByDescending(x => x).ToList();
    }
}