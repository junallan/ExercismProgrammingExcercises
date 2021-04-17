using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Raindrops
{
    public static string Convert(int number) => 
        new[] { (Factor: 3, Message: "Pling"), (Factor: 5, Message: "Plang"), (Factor: 7, Message: "Plong"), }
            .Aggregate(number.ToString(),
                        (accumulate, next) =>
                        {
                            if (number % next.Factor != 0) { return accumulate; }

                            return int.TryParse(accumulate, out _) ? next.Message : string.Concat(accumulate, next.Message);
                        });
}