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
        if(number == 1) { return Classification.Deficient; }
        if (number < 1) { throw new ArgumentOutOfRangeException(); }

        List<int> factors = new List<int>() {1};
     
        for(int checkNumber = 2; checkNumber < number; checkNumber++)
        {
            if (IsFactor(number, checkNumber))
            {
                if (factors.Contains(checkNumber)) { break; }

                factors.Add(checkNumber);

                var otherFactor = number / checkNumber;
                if (otherFactor == checkNumber) { break; }

                factors.Add(otherFactor);
            }
        }

        var summation = factors.Sum();

        if (summation == number) { return Classification.Perfect; }
        else if (summation > number) { return Classification.Abundant; }
        else { return Classification.Deficient; };
    }

    private static bool IsFactor(int number, int startFactor) =>  number % startFactor == 0;
}
