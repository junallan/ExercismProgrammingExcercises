using System;

static class AssemblyLine
{
    private const int CarsProductionForSpeedMeasurement = 221;

    public static double ProductionRatePerHour(int speed)
    {
        if (speed == 0) return 0;
        else if (speed < 5) return CarsProductionForSpeedMeasurement * speed;
        else return (CarsProductionForSpeedMeasurement * speed * 0.9);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        throw new NotImplementedException("Please implement the (static) AssemblyLine.WorkingItemsPerMinute() method");
    }
}
