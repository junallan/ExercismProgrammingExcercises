using System;

public class Clock
{
    public const int HoursInADay = 24;
    public const int MinutesInAnHour = 60;

    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int TotalMinutes { get; set; }

    public Clock(int hours, int minutes)
    {
        TotalMinutes = (hours >= 0 ? hours : HoursInADay + (hours % HoursInADay)) * MinutesInAnHour + minutes;
        Hours = (TotalMinutes / MinutesInAnHour) % HoursInADay;
        Minutes = (minutes >= 0 ? minutes : MinutesInAnHour + minutes) % MinutesInAnHour;
    }

    public override string ToString()
        => $"{Hours.ToString().PadLeft(2, '0')}:{Minutes.ToString().PadLeft(2, '0')}";
    //=> $"{Hours.ToString().PadLeft(2, '0')}:{Minutes.ToString().PadLeft(2, '0')}";

    public Clock Add(int minutesToAdd)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
