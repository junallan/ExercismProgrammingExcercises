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
        return _list.Count > 3 ? _list.OrderByDescending(x => x).ToList().GetRange(0,3) : _list.OrderByDescending(x => x).ToList().GetRange(0,_list.Count);
    }
}