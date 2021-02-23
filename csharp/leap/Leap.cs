using System;

public static class Leap
{
     private static bool IsDivisibleBy(int year, int n)
    {
        return (year % n) == 0;
    }

    public static bool IsLeapYear(int year) => IsDivisibleBy(year, 4) && (!IsDivisibleBy(year, 100) || IsDivisibleBy(year, 400));
    
}