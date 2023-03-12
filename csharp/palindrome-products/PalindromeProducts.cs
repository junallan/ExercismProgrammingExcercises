using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor) => FirstPalindromeMatch(minFactor, maxFactor, isDescending: true);
    
    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)=> FirstPalindromeMatch(minFactor, maxFactor);
    
    public static (int, IEnumerable<(int, int)>) FirstPalindromeMatch(int minFactor, int maxFactor, bool isDescending = false)
    {
        if (minFactor > maxFactor) throw new ArgumentException();

        var range = Enumerable.Range(minFactor * minFactor, maxFactor * maxFactor);

        if (isDescending) range = range.Reverse();

        var firstPalindromeMatch = range.Where(IsPalindrome).Where(number => number.DivisorsInRange(minFactor, maxFactor).Count() > 0).FirstOrDefault(-1);

        if (firstPalindromeMatch == -1) throw new ArgumentException();

        return (firstPalindromeMatch, firstPalindromeMatch.DivisorsInRange(minFactor, maxFactor));
    }

    public static IEnumerable<(int i, int j)> DivisorsInRange(this int number, int lowerRange, int upperRange)
    { 
        foreach (var (i, j) in GeneratePairs(lowerRange, upperRange))
        {
            if ((i * j) == number)  yield return (i, j);
        }
    }

    private static bool IsPalindrome(int number)
    {
        var numberFormatted = number.ToString();

        return numberFormatted == new String(numberFormatted.Reverse().ToArray());
    }

    private static IEnumerable<(int, int)> GeneratePairs(int minFactor, int maxFactor)
    {
        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)
            {
                yield return (i, j);
            }
        }
    }
}
