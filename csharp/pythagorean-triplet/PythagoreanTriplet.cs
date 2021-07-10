using System;
using System.Collections.Generic;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        Func<int, int, int, bool> isPythagoreanTriplet = (a, b, c) => (Math.Pow(a, 2) + Math.Pow(b, 2)) == Math.Pow(c, 2);

        for(int a = 1; a <sum / 3; a++)
        {
            for(int b = a + 1; b < sum - a; b++)
            {
                int c = sum - b - a;

                if (c < b) break;

                if (isPythagoreanTriplet(a, b, c)) yield return (a, b, c);
            }
        }
    }
}