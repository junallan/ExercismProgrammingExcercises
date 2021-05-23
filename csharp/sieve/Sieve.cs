using System;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        var smallestPrime = 2;

        if (limit < smallestPrime) { throw new ArgumentOutOfRangeException(); }

        var numbers = Enumerable.Range(smallestPrime, limit - 1).ToList();

        for(var i= smallestPrime; i<=Math.Sqrt(limit); i++)
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