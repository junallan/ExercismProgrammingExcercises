using System;
using System.Linq;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        var bracketValues = "[]{}()";
      
        var brackets = String.Concat(input.Where(character => bracketValues.Contains(character)));

        if (brackets.Length == 0) return true;
        if (brackets.Length % 2 != 0) return false;

        var startPosition = 0;
        var bracketsToProcess = brackets;

        do
        {
            var bracketSubset = FindBracketSubset(startPosition, bracketsToProcess);

            //inputHasBracketSubset = !;
            if (string.IsNullOrEmpty(bracketSubset)) return false;

      
                for(var i=0; i<bracketSubset.Length/2; i++)
                {
                    if (!isPair(String.Concat(bracketSubset[i], bracketSubset[bracketSubset.Length-i-1]))) return false;
                }
         
            bracketsToProcess = bracketsToProcess.Substring(bracketSubset.Length);

        } while (!string.IsNullOrEmpty(bracketsToProcess));


        return true;
    }

    private static bool isPair(string input) => input.Contains("[]") || input.Contains("{}") || input.Contains("()");

    private static string FindBracketSubset(int startPosition, string brackets)
    {
        var openBracketValues = "[{(";
        var closedBracketValues = "]})";
 
        var isOpenBracket = openBracketValues.Contains(brackets[startPosition]);
        if (!isOpenBracket) return string.Empty;

        for (var i = startPosition + 1; i < brackets.Length; i++)
        {
            if (closedBracketValues.Contains(brackets[i]))
            {
                var nestingLevels = i - startPosition; //- 1;

                if((i+nestingLevels) > brackets.Length) return string.Empty;

                return brackets.Substring(startPosition, i - startPosition + nestingLevels);
            }
        }

        return string.Empty;
    }
}

