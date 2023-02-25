using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int,int)>) Largest(int minFactor, int maxFactor)
    {
        int? largestPalindromeProduct = null;
        var palindromeProducts = new List<(int FirstNumber, int SecondNumber)>();

        for (int i = maxFactor; i >= minFactor; i--)
        {
            for (int j = maxFactor; j >= minFactor; j--)
            {
                if (IsPalindromProduct(j, i))
                {
                    if (!largestPalindromeProduct.HasValue) largestPalindromeProduct = i * j;
                    else if (largestPalindromeProduct.Value != i * j)
                    {
                        if (largestPalindromeProduct.Value > i * j) continue;
                        else
                        {
                            largestPalindromeProduct = i * j;
                            palindromeProducts.Clear();
                            palindromeProducts.Add((j, i));
                        }
                    }

                    if (!palindromeProducts.Any(n => (n.FirstNumber == i && n.SecondNumber == j) || (n.FirstNumber == j && n.SecondNumber == i)))
                        palindromeProducts.Add((j, i));
                }
            }
        }

        if (!largestPalindromeProduct.HasValue) throw new ArgumentException();
        return (largestPalindromeProduct.Value, palindromeProducts);
    }

    public static (int, IEnumerable<(int,int)>) Smallest(int minFactor, int maxFactor)
    {
        int? smallestPalindromeProduct = null;
        var palindromeProducts = new List<(int FirstNumber, int SecondNumber)>();

        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)
            {
                if (IsPalindromProduct(i, j))
                {
                    if (!smallestPalindromeProduct.HasValue) smallestPalindromeProduct = i * j;
                    else if(smallestPalindromeProduct.Value != i * j) return (smallestPalindromeProduct.Value, palindromeProducts);

                    if (!palindromeProducts.Any(n => (n.FirstNumber == i && n.SecondNumber == j) || (n.FirstNumber == j && n.SecondNumber == i)))
                        palindromeProducts.Add((j, i));
                }
            }
        }

        if (!smallestPalindromeProduct.HasValue) throw new ArgumentException();
        return (smallestPalindromeProduct.Value, palindromeProducts);
    }

    private static bool IsPalindromProduct(int firstNumber, int secondNumber)
    {
        var product = firstNumber * secondNumber;
        var parsedProduct = product.ToString().ToCharArray();
        Array.Reverse(parsedProduct);

        return product.ToString() == new String(parsedProduct);    
    }
}
