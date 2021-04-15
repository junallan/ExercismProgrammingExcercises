using System;
using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> transformedData = new Dictionary<string, int>();

        old.Keys.ToList().ForEach(k => old[k].ToList().ForEach(v => transformedData.Add(v.ToLower(), k)));

        //foreach (var key in old.Keys)
        //{
        //    old[key].ToList().ForEach(v => tranformedData.Add(v.ToLower(), key));
        //}

        //foreach(KeyValuePair<int, string[]> entry in old)
        //{
        //    entry.Value.ToList().ForEach(v => tranformedData.Add(v.ToLower(), entry.Key));
        //}

        return transformedData;
    }
}