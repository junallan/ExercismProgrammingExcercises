using System;

public class Clock : IEquatable<Clock>
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
        {
            _hours = (totalMinutes / MinutesInAnHour) % HoursInADay;
        }
        else
        {
            _hours =
                (HoursInADay
                + (hours + ((minutes / MinutesInAnHour) - 1) % HoursInADay))
                % HoursInADay;

            while (_hours < 0) _hours = HoursInADay + _hours;
        }
   
        _minutes = (minutes >= 0
            ? minutes
            : MinutesInAnHour + (minutes % MinutesInAnHour))
            % MinutesInAnHour;

        if (minutes < 0 && hours == 0) _hours = HoursInADay - 1;
    }


    public override string ToString()
        => $"{_hours.ToString().PadLeft(2, '0')}:{_minutes.ToString().PadLeft(2, '0')}";


    public Clock Add(int minutesToAdd) => new Clock(_hours, _minutes + minutesToAdd);


    public Clock Subtract(int minutesToSubtract)
    {
        var hoursToSubtract = 0;

        if (minutesToSubtract > MinutesInAnHour)
        {
            hoursToSubtract = minutesToSubtract / MinutesInAnHour;
            minutesToSubtract = minutesToSubtract % MinutesInAnHour;
        }

        return new Clock(_hours - hoursToSubtract, _minutes - minutesToSubtract);
    }

    public bool Equals(Clock other)
        => this._hours == other._hours
        && this._minutes == other._minutes;
}
