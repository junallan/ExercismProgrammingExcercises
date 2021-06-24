using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Acronym
{
    public static string Abbreviate(string phrase) => string.Join(string.Empty,
                                                                  Regex.Split(phrase, "[^a-zA-Z']+").Select(m => m.ElementAt(0))).ToUpper();
}