using System;

public class Clock : IEquatable<Clock>
{
    private const int MinutesInADay = 1440;
    private const int MinutesInAnHour = 60;
    private const string PaddingFormatOf2 = "D2";

    private int _minutes;
    

    public Clock(int hours, int minutes)
    {
        _minutes = Normalize(hours * MinutesInAnHour + minutes);
    }


    public override string ToString()
        => $"{(_minutes / MinutesInAnHour).ToString(PaddingFormatOf2)}" +
        $":{(_minutes % MinutesInAnHour).ToString(PaddingFormatOf2)}";


    public Clock Add(int minutesToAdd)
        => new (0, _minutes + minutesToAdd);


    public Clock Subtract(int minutesToSubtract)
        => new (0, (_minutes - minutesToSubtract));
    

    public bool Equals(Clock other)
        => this._minutes == other._minutes;

    private static int Normalize(int minutes) =>
        minutes < 0 ?
        MinutesInADay + (minutes % MinutesInADay)
        : minutes % MinutesInADay;
}
