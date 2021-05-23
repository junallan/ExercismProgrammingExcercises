using System;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2) { throw new ArgumentOutOfRangeException(); }

        var numbers = Enumerable.Range(2, limit - 1).ToList();

        for(var i=2; i<=Math.Sqrt(limit); i++)
        {
            var j = i*i;
            while(j <= limit)
            {
                numbers.Remove(j);
                j += i;
            }
        }

        return numbers.ToArray();
    }
}