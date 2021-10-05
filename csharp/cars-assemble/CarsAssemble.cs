using System;

static class AssemblyLine
{
    private const int CarsProductionForSpeedMeasurement = 221;

    public static double ProductionRatePerHour(int speed)
    {
        if (speed == 0) return 0;
        else if (speed == 1) return CarsProductionForSpeedMeasurement;
        else return 100;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        throw new NotImplementedException("Please implement the (static) AssemblyLine.WorkingItemsPerMinute() method");
    }
}
