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

        var firstPalindromeMatch = range.Where(number => IsPalindrome(number) && number.DivisorsInRange(minFactor, maxFactor).Count() > 0).FirstOrDefault(-1);

        if (firstPalindromeMatch == -1) throw new ArgumentException();

        return (firstPalindromeMatch, firstPalindromeMatch.DivisorsInRange(minFactor, maxFactor));
    }

    public static IEnumerable<(int i, int j)> DivisorsInRange(this int number, int lowerRange, int upperRange)
    { 
        foreach (var (i, j) in GeneratePairs(number, lowerRange, upperRange))
        {
            if ((i * j) == number)  yield return (i, j);
        }
    }

    private static bool IsPalindrome(int number)
    {
        var numberFormatted = number.ToString();

        return numberFormatted == new String(numberFormatted.Reverse().ToArray());
    }

    private static IEnumerable<(int, int)> GeneratePairs(int number, int minFactor, int maxFactor)
    {
        var products = new HashSet<(int, int)>();

        for (int i = minFactor; i <= maxFactor; i++)
        {
            var remainder = number % i;
            var division = number / i;

            if (remainder == 0 && minFactor <= division && division <= maxFactor)
            {
                if (i < division)
                    products.Add((i, division));
                else
                    products.Add((division, i));
            }
        }

        return products.AsEnumerable();
    }
}
