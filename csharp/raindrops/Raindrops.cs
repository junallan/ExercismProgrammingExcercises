using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        List<(int Factor,string Message)> specicalDivisibleFactors = new List<(int Factor, string Message)> { (3, "Pling"), (5, "Plang"), (7, "Plong") };

        return  specicalDivisibleFactors.Aggregate(
                                            number.ToString(), 
                                            (accumulate, next)  => 
                                                {
                                                    if (number % next.Factor != 0) { return accumulate; }
                     
                                                    return int.TryParse(accumulate, out _) ? next.Message : string.Concat(accumulate, next.Message);
                                            });
    }
}