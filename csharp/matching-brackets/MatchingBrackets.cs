using System;
using System.Linq;

public static class MatchingBrackets
{
    private const string BracketsPair = "[]";
    private const string BracesPair = "{}";
    private const string ParenthesesPair = "()";

    private static bool UnevenBrackets(string brackets) => brackets.Length % 2 != 0;
    private static bool NoBrackets(string brackets) => brackets.Length == 0;

    public static bool IsPaired(string input)
    {
        var bracketValues = string.Concat(BracketsPair, BracesPair, ParenthesesPair);

        var brackets = String.Concat(input.Where(character => bracketValues.Contains(character)));

        if (NoBrackets(brackets)) return true;
        if (UnevenBrackets(brackets)) return false;

        var bracketsLeftToProcess = brackets.Replace(BracketsPair, string.Empty).Replace(BracesPair, string.Empty).Replace(ParenthesesPair, string.Empty);

        if (bracketsLeftToProcess.Length == brackets.Length) return false;

        return IsPaired(bracketsLeftToProcess);
    }

}

