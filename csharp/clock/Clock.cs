using System;

public class Clock
{
    public const int HoursInADay = 24;
    public const int MinutesInAnHour = 60;

    private int _hours;
    private int _minutes;
    

    public Clock(int hours, int minutes)
    {
        var totalMinutes = (hours >= 0
            ? hours
            : HoursInADay + (hours % HoursInADay))
            * MinutesInAnHour + minutes;

        if (minutes >= -MinutesInAnHour)
            _hours = (totalMinutes / MinutesInAnHour) % HoursInADay;
        else    
        {
            _hours =
                HoursInADay
                + (hours + ((minutes / MinutesInAnHour) - 1) % HoursInADay);

            while (_hours < 0) _hours = HoursInADay + _hours;
        }
   
        _minutes = (minutes >= 0
            ? minutes
            : MinutesInAnHour + (minutes % MinutesInAnHour))
            % MinutesInAnHour;
    }


    public override string ToString()
        => $"{_hours.ToString().PadLeft(2, '0')}:{_minutes.ToString().PadLeft(2, '0')}";


    public Clock Add(int minutesToAdd) => new Clock(_hours, _minutes + minutesToAdd);
    

    public Clock Subtract(int minutesToSubtract) => new Clock(_hours, _minutes - minutesToSubtract);
}
