using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        bool isFactor(int number, int factor) => number % factor == 0;

        var specialFactors = new[] { (Factor: 3, Message: "Pling"),
                (Factor: 5, Message: "Plang"),
                (Factor: 7, Message: "Plong") };

       var messages = specialFactors
                        .Select(x => isFactor(number, x.Factor) ? x.Message : string.Empty)
                        .SelectMany(x => x).ToArray();

        return messages.Any() ? new string(messages) : number.ToString();
    }
}