using System;
using System.Collections.Generic;
using System.Linq;

public static class ResistorColorDuo
{
    public static readonly Dictionary<string, string> ColorMappings
        = new Dictionary<string, string> {
            { "black", "0" },
            { "brown", "1" },
            { "red", "2" },
            { "orange", "3" },
            { "yellow", "4" },
            { "green", "5" },
            { "blue", "6" },
            { "violet", "7" },
            { "grey", "8" },
            { "white", "9" }
        };

    public static int Value(string[] colors) => int.Parse(string.Concat(ColorMappings[colors[0]], ColorMappings[colors[1]]));   
}