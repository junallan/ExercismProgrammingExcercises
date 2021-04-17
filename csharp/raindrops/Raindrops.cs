using System;
using System.Collections.Generic;
using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        List<(int Factor,string Message)> specicalDivisibleFactors = new List<(int Factor, string Message)> { (3, "Pling"), (5, "Plang"), (7, "Plong") };

        Func<int, int, bool> isFactor = (input, divisbleFactor) => input % divisbleFactor == 0;

        StringBuilder output = new StringBuilder();

        foreach (var factorElement in specicalDivisibleFactors)
        {
            if (isFactor(number, factorElement.Factor)) { output.Append(factorElement.Message); }
        }

        return output.Length == 0 ? number.ToString() : output.ToString();
    }
}