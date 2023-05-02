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

        if (minutes >= -MinutesInAnHour)
            Hours = (TotalMinutes / MinutesInAnHour) % HoursInADay;
        else    
        {
            Hours = HoursInADay + (hours + ((minutes / MinutesInAnHour) - 1) % HoursInADay);

            while (Hours < 0) Hours = HoursInADay + Hours;
        }
   
        Minutes = (minutes >= 0 ? minutes : MinutesInAnHour + (minutes % MinutesInAnHour)) % MinutesInAnHour;
    }


    public override string ToString()
        => $"{Hours.ToString().PadLeft(2, '0')}:{Minutes.ToString().PadLeft(2, '0')}";


    public Clock Add(int minutesToAdd)
    {
        return new Clock(this.Hours, this.Minutes + minutesToAdd);
    }


    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
