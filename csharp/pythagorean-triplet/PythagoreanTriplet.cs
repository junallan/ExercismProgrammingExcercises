using System;
using System.Collections.Generic;
using System.Linq;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        Func<int, int, int, bool> isPythagoreanTriplet = (a, b, c) => (Math.Pow(a, 2) + Math.Pow(b, 2)) == Math.Pow(c, 2);

        return  Enumerable.Range(1, (sum / 3) - 1)
                        .Select(a => Enumerable.Range(a + 1, (sum / 2) - 1).Select(b => (a, b))
                                               .Where(x => isPythagoreanTriplet(x.a, x.b, sum - x.a - x.b))
                                               .Select(x => (x.a, x.b, sum - x.a - x.b)))
                        .SelectMany(x => x);
    }
}