using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        var messages = new[] {  (Factor: 3, Message: "Pling"),
                                (Factor: 5, Message: "Plang"),
                                (Factor: 7, Message: "Plong") }
                        .Select(x => number % x.Factor == 0 ? x.Message : string.Empty)
                        .SelectMany(x => x).ToArray();

        return messages.Any() ? new string(messages) : number.ToString();
    }
}