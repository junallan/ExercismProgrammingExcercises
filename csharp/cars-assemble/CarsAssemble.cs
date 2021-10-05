using System;

static class AssemblyLine
{
    private const int CarsProductionForSpeedMeasurement = 221;
    private const int MinutesPerHour = 60;

    private static int RawProductionRate(int speed) => CarsProductionForSpeedMeasurement * speed;

    private static double SuccessRate(int speed)
    {
        if (speed > 0 && speed < 5) return 1.0;
        else if (speed < 9) return  0.9;
        else if (speed == 9) return 0.8;
        else if (speed == 10) return 0.77;
        else return 0;
    }

    public static double ProductionRatePerHour(int speed) => RawProductionRate(speed) * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) => (int)ProductionRatePerHour(speed) / MinutesPerHour;
}
