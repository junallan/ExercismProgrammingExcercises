using System;
using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> transformedData = new Dictionary<string, int>();

        var transformation = old.Keys.Select(k => new { Letters = old[k], Score = k });

        transformation.ToList().ForEach(x => x.Letters.ToList().ForEach(l => transformedData.Add(l.ToLower(), x.Score)));
        //old.Keys.ToList().ForEach(k => old[k].ToList().ForEach(v => transformedData.Add(v.ToLower(), k)));

        return transformedData;
    }
}