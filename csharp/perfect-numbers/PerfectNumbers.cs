using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient=-1
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number < 1) { throw new ArgumentOutOfRangeException(); }

        return (Classification)(Enumerable.Range(1, number / 2)
                                       .Where(x => number % x == 0)
                                       .Sum()).CompareTo(number);
    }
}
