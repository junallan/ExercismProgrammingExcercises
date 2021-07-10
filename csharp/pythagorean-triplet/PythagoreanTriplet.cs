using System;
using System.Collections.Generic;
using System.Linq;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        return  Enumerable.Range(1, (sum / 3) - 1)
                        .Select(a => Enumerable.Range(a + 1, (sum / 2) - 1).Select(b => (a, b))
                                               .Where(x => (x.a * x.a + x.b * x.b) == (sum-x.a-x.b) * (sum-x.a-x.b))
                                               .Select(x => (x.a, x.b, sum - x.a - x.b)))
                        .SelectMany(x => x);
    }
}