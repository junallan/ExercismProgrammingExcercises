using System;
using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old) => old.SelectMany(x => x.Value, (scoreLetter, letter) => new { Score = scoreLetter.Key, Letter = letter }).ToDictionary(x => x.Letter.ToLower(), x => x.Score);
}