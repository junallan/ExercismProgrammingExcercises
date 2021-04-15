using System;
using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> tranformedData = new Dictionary<string, int>();
        
        foreach(KeyValuePair<int, string[]> entry in old)
        {
            entry.Value.ToList().ForEach(v => tranformedData.Add(v.ToLower(), entry.Key));
        }

        return tranformedData;
    }
}