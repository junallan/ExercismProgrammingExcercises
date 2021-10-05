using System;

static class AssemblyLine
{
    private const int CarsProductionForSpeedMeasurement = 221;
    private const int MinutesPerHour = 60;

    public static double ProductionRatePerHour(int speed)
    {
        if (speed == 0) return 0;
        else if (speed < 5) return CarsProductionForSpeedMeasurement * speed;
        else if(speed < 9) return (CarsProductionForSpeedMeasurement * speed * 0.9);
        else if(speed < 10) return (CarsProductionForSpeedMeasurement * speed * 0.8);
        else return (CarsProductionForSpeedMeasurement * speed * 0.77);
    }

    public static int WorkingItemsPerMinute(int speed) => (int)ProductionRatePerHour(speed) / MinutesPerHour;
}
