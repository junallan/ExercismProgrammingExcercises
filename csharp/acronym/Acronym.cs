using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        MatchCollection matches = Regex.Matches(phrase, @"\b[a-zA-Z]");

        return string.Join("", matches.Select(m => m.Value.ToUpper()));
    }
}