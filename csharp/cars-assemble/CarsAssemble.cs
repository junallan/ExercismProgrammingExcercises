using System;

static class AssemblyLine
{
    public static double ProductionRatePerHour(int speed)
    {
        if (speed == 0) return 0;
        return 100;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        throw new NotImplementedException("Please implement the (static) AssemblyLine.WorkingItemsPerMinute() method");
    }
}
