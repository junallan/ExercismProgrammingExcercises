using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        List<int> multipleNumbers = new List<int>();

        foreach(var multiple in multiples.Where(m => m > 0))
        {
            var i = 1;
            var accumulation = multiple * i;

            while(accumulation < max)
            {
                if (!multipleNumbers.Contains(accumulation)) 
                {
                    multipleNumbers.Add(accumulation);
                }
                
                i++;
                accumulation = multiple * i;
            }
        }

        return multipleNumbers.Sum();
    }
}