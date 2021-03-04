using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var numberLength = (double)$"{number}".Length;
        var result = $"{number}".Aggregate(0, (total, digit) => total + (int)Math.Pow(char.GetNumericValue(digit), numberLength));

        return result == (double)number;
    }
}