using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        List<int> multipleNumbers = new List<int>();

        foreach (var multiple in multiples.Where(m => m > 0))
        {   
            var maxMultipleIndex = max / multiple - (max % multiple == 0 ? 1 : 0);

            multipleNumbers.AddRange(Enumerable.Range(1, maxMultipleIndex).Select(i => multiple * i));
        }

        return multipleNumbers.Select(x => x).Distinct().Sum();
    }
}