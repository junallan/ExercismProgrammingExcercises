using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Raindrops
{
    public static string Convert(int number) 
        => new string(new[] {   (Factor: 3, Message: "Pling"),
                                (Factor: 5, Message: "Plang"),
                                (Factor: 7, Message: "Plong") }
                    .Where(x => number % x.Factor == 0)
                    .Select(x => x.Message)
                    .DefaultIfEmpty(number.ToString())
                    .SelectMany(x => x)
                    .ToArray());
}