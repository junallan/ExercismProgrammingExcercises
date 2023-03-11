using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
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

    public static (int, IEnumerable<(int, int)>) LargestVariationBetweenSquareRangeV1(int minFactor, int maxFactor)
    //public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
    {
        if (minFactor > maxFactor) throw new ArgumentException();

        var smallestProduct = minFactor * minFactor;

        var largestProduct = maxFactor * maxFactor;

        var palindromeProducts = new List<(int FirstNumber, int SecondNumber)>();
        var palindromesInRange = PalindromesInRange(smallestProduct, largestProduct);

        int currentPalindrome = int.MinValue;

        foreach (var palindrome in palindromesInRange)
        { 
            for (int i = maxFactor; minFactor <= i; i--)
            {
                var remainder = palindrome / i;
                var carryover = palindrome % i;

                if (currentPalindrome > remainder * i) continue;

                if ((minFactor <= remainder && remainder <= maxFactor) && carryover == 0)
                {
                    if (currentPalindrome != palindrome) palindromeProducts.Clear();
                    currentPalindrome = palindrome;

                    if (palindromeProducts.Contains((i, remainder))) continue;

                    palindromeProducts.Add((remainder, i));
                }
            }

            //if (palindromeProducts.Any()) break;
        }

        if (!palindromeProducts.Any()) throw new ArgumentException();

        return (currentPalindrome, palindromeProducts);
    }

    public static (int, IEnumerable<(int, int)>) LargestVariationBetweenSquareRangeV2(int minFactor, int maxFactor)
    //public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
    {
        if (minFactor > maxFactor) throw new ArgumentException();

        var smallestProduct = minFactor * minFactor;

        var largestProduct = maxFactor * maxFactor;

        var palindromeProducts = new List<(int FirstNumber, int SecondNumber)>();
        var palindromesInRange = PalindromesInRange(smallestProduct, largestProduct).OrderByDescending(p => p);

        int currentPalindrome = int.MinValue;

        foreach (var palindrome in palindromesInRange)
        {
            var lowerFactorCurrent = minFactor;
           
            for (int i = maxFactor; lowerFactorCurrent <= i; i--)
            {
                var remainder = palindrome / i;
                var carryover = palindrome % i;

                if (currentPalindrome > remainder * i) continue;

                if ((minFactor <= remainder && remainder <= maxFactor) && carryover == 0)
                {
                    currentPalindrome = palindrome;

                    if (palindromeProducts.Contains((i, remainder))) break;

                    palindromeProducts.Add((remainder, i));
                }

                if(lowerFactorCurrent == i)
                {
                    lowerFactorCurrent++;
                    i = maxFactor;
                }
            }

            if (palindromeProducts.Any()) break;
        }

        if (!palindromeProducts.Any()) throw new ArgumentException();

        return (currentPalindrome, palindromeProducts);
    }

    //public static (int, IEnumerable<(int,int)>) Smallest(int minFactor, int maxFactor)
    //{
    //    var smallestPalindromeProduct = int.MaxValue;
    //    var palindromeProducts = new List<(int FirstNumber, int SecondNumber)>();

    //    foreach (var (i, j) in GeneratePairs(minFactor, maxFactor))
    //    {
    //        var product = i * j;

    //        if (!IsPalindrome(product)) continue;

    //        if (smallestPalindromeProduct < product) return (smallestPalindromeProduct, palindromeProducts);
    //        if (smallestPalindromeProduct == int.MaxValue) smallestPalindromeProduct = product;

    //        if (!palindromeProducts.Any(n => (n.FirstNumber == i && n.SecondNumber == j) || (n.FirstNumber == j && n.SecondNumber == i)))
    //            palindromeProducts.Add((j, i));
    //    }

    //    if (smallestPalindromeProduct == int.MaxValue) throw new ArgumentException();
    //    return (smallestPalindromeProduct, palindromeProducts);
    //}

    //public static (int, IEnumerable<(int,int)>) SmallestVariationBetweenSquareRange(int minFactor, int maxFactor)
    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)
    {
        if (minFactor > maxFactor) throw new ArgumentException();
      
        var smallestProduct = minFactor * minFactor;
        
        var largestProduct = maxFactor * maxFactor;
        
        var palindromeProducts = new List<(int FirstNumber, int SecondNumber)>();
        var palindromesInRange = PalindromesInRange(smallestProduct, largestProduct);
        
        int currentPalindrome = int.MaxValue;
        
        foreach (var palindrome in palindromesInRange)
        {
            for (int i = minFactor; i <= maxFactor; i++)
            {
                var remainder = palindrome / i;
                var carryover = palindrome % i;
        
                if (currentPalindrome < remainder * i) break;
        
                if ((minFactor <= remainder && remainder <= maxFactor) && carryover == 0)
                {
                    currentPalindrome = palindrome;
                    palindromeProducts.Add((remainder, i));
                }
            }
        
            if (palindromeProducts.Any()) break;
        }
        
        if (!palindromeProducts.Any()) throw new ArgumentException();
        
        return (currentPalindrome, palindromeProducts);
    }

    private static IEnumerable<int> PalindromesInRange(int lowerRange, int upperRange)
    {
        for (int i = lowerRange; i <= upperRange; i++) if (IsPalindrome(i)) yield return i;
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
