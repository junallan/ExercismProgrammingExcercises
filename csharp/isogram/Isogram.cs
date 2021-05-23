using System;
using System.Text.RegularExpressions;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        string parsedWord = Regex.Replace(word, "[-\\s]", string.Empty);
        Match match = Regex.Match(parsedWord, @"^.*(.).*\1.*$", RegexOptions.IgnoreCase);

        return !match.Success;
    }
}
