using System;

public static class ResistorColor
{
    public static string[] ColorMap => new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };

    public static int ColorCode(string color) =>  Array.FindIndex(ColorMap, x => x.Equals(color));
    public static string[] Colors() => ColorMap;
}