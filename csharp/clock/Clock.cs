using System;

public class Clock
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public Clock(int hours, int minutes)
    {
        Hours = hours % 24;
        Minutes = minutes;
    }

    public override string ToString()
        => $"{Hours.ToString().PadLeft(2, '0')}:{Minutes.ToString().PadLeft(2, '0')}";

    public Clock Add(int minutesToAdd)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
