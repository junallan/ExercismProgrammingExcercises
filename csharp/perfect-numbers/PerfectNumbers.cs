using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number < 1) { throw new ArgumentOutOfRangeException(); }

        var summation = Enumerable.Range(1, number / 2)
                                       .Where(x => number % x == 0)
                                       .Distinct()
                                       .Sum();

        if (summation == number) { return Classification.Perfect; }
        else if (summation > number) { return Classification.Abundant; }
        else { return Classification.Deficient; };
    }
}
