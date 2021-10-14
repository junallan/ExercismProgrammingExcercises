using System;

class RemoteControlCar
{
    public int Speed { get; }
    public int BatteryDrain { get; }

    private int _batteryLevel = 100;
 
    private int _distance;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        Speed = speed;
        BatteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => _batteryLevel <= 0;

    public int DistanceDriven() => _distance;

    public void Drive()
    {
        if (BatteryDrained()) return;

        _batteryLevel -= BatteryDrain;
        _distance += Speed;
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(speed: 50, batteryDrain: 4);
}

class RaceTrack
{
    private int _distance;
    private const int MaxBatteryCharge = 100;

    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    private float DrivesForDistance(RemoteControlCar car) => (float)_distance / car.Speed;

    private float BatteryDrainForDistance(RemoteControlCar car) => DrivesForDistance(car) * car.BatteryDrain;

    public bool CarCanFinish(RemoteControlCar car) => BatteryDrainForDistance(car) <= MaxBatteryCharge; 
}
