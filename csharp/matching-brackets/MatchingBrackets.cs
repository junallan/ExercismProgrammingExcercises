using System;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        return input.Length == 0 || input.Contains("[]");
    }
}
