using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int,int)>) Largest(int minFactor, int maxFactor)
    {
        var largestPalindromeProduct = int.MinValue;
        var palindromeProducts = new List<(int FirstNumber, int SecondNumber)>();

        foreach (var (i, j) in GeneratePairs(minFactor, maxFactor))
        {
            var product = i * j;

            if (!IsPalindrome(product)) continue;

            if (largestPalindromeProduct < product)
            {
                largestPalindromeProduct = product;
                palindromeProducts.Clear();
                palindromeProducts.Add((i, j));
            }
            else if (largestPalindromeProduct == product)
            {
                if (!palindromeProducts.Any(n => (n.FirstNumber == i && n.SecondNumber == j) || (n.FirstNumber == j && n.SecondNumber == i)))
                    palindromeProducts.Add((j, i));
            }
        }

        if (largestPalindromeProduct == int.MinValue) throw new ArgumentException();

        return (largestPalindromeProduct, palindromeProducts);
    }

    public static (int, IEnumerable<(int,int)>) Smallest(int minFactor, int maxFactor)
    {
        var smallestPalindromeProduct = int.MaxValue;
        var palindromeProducts = new List<(int FirstNumber, int SecondNumber)>();

        foreach (var (i, j) in GeneratePairs(minFactor, maxFactor))
        {
            var product = i * j;

            if (!IsPalindrome(product)) continue;

            if (smallestPalindromeProduct < product) return (smallestPalindromeProduct, palindromeProducts);
            if (smallestPalindromeProduct == int.MaxValue) smallestPalindromeProduct = product;

            if (!palindromeProducts.Any(n => (n.FirstNumber == i && n.SecondNumber == j) || (n.FirstNumber == j && n.SecondNumber == i)))
                palindromeProducts.Add((j, i));
        }

        if (smallestPalindromeProduct == int.MaxValue) throw new ArgumentException();
        return (smallestPalindromeProduct, palindromeProducts);
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
