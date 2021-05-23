using System;
using System.Text.RegularExpressions;

public static class Isogram
{
    public static bool IsIsogram(string word) => !Regex.Match(word, @"^.*(\w).*\1.*$", RegexOptions.IgnoreCase).Success;
}
