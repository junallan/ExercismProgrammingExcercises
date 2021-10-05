using System;

static class AssemblyLine
{
    private const int CarsProductionForSpeedMeasurement = 221;
    private const int MinutesPerHour = 60;

    private const double FiveToEightCarSuccessRate = 0.9;
    private const double NineCarSuccessRate = 0.8;
    private const double TenCarSuccessRate = 0.77;

    private static int RawProductionRate(int speed) => CarsProductionForSpeedMeasurement * speed;

    public static double ProductionRatePerHour(int speed)
    {
        if (speed == 0) return 0;
        else if (speed < 5) return RawProductionRate(speed);
        else if(speed < 9) return RawProductionRate(speed) * FiveToEightCarSuccessRate;
        else if(speed < 10) return RawProductionRate(speed) * NineCarSuccessRate;
        else return RawProductionRate(speed) * TenCarSuccessRate;
    }

    public static int WorkingItemsPerMinute(int speed) => (int)ProductionRatePerHour(speed) / MinutesPerHour;
}
