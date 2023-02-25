using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int,int)>) Largest(int minFactor, int maxFactor)
    {
        var largestPalindromeProduct = int.MinValue;
        var palindromeProducts = new List<(int FirstNumber, int SecondNumber)>();

        for (int i = maxFactor; i >= minFactor; i--)
        {
            for (int j = maxFactor; j >= minFactor; j--)
            {
                if (!IsPalindromProduct(j, i)) continue;

                if (largestPalindromeProduct < i * j)
                { 
                    largestPalindromeProduct = i * j;
                    palindromeProducts.Clear();
                    palindromeProducts.Add((j, i));
                }
                else if (largestPalindromeProduct == i * j)
                {
                    if (!palindromeProducts.Any(n => (n.FirstNumber == i && n.SecondNumber == j) || (n.FirstNumber == j && n.SecondNumber == i)))
                        palindromeProducts.Add((j, i));
                }
            }
        }

        if (largestPalindromeProduct == int.MinValue) throw new ArgumentException();

        return (largestPalindromeProduct, palindromeProducts);
    }

    public static (int, IEnumerable<(int,int)>) Smallest(int minFactor, int maxFactor)
    {
        var smallestPalindromeProduct = int.MaxValue;
        var palindromeProducts = new List<(int FirstNumber, int SecondNumber)>();

        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)
            {
                if (!IsPalindromProduct(i, j)) continue;
                if (smallestPalindromeProduct < i * j) return (smallestPalindromeProduct, palindromeProducts);
                if (smallestPalindromeProduct == int.MaxValue) smallestPalindromeProduct = i * j;
   
                if (!palindromeProducts.Any(n => (n.FirstNumber == i && n.SecondNumber == j) || (n.FirstNumber == j && n.SecondNumber == i)))
                    palindromeProducts.Add((j, i));           
            }
        }

        if (smallestPalindromeProduct == int.MaxValue) throw new ArgumentException();
        return (smallestPalindromeProduct, palindromeProducts);
    }

    private static bool IsPalindromProduct(int firstNumber, int secondNumber)
    {
        var product = (firstNumber * secondNumber).ToString();
        var parsedProduct = product.ToCharArray();
        Array.Reverse(parsedProduct);

        return product == new String(parsedProduct);    
    }
}
