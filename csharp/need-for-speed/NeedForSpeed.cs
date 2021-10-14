using System;

class RemoteControlCar
{
    public static int MaxBatteryCharge = 100;

    public int Speed { get; }
    public int BatteryDrain { get; }

    private int _batteryLevel = MaxBatteryCharge;
 
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
  
    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    private float DrivesForDistance(RemoteControlCar car) => (float)_distance / car.Speed;

    private float BatteryDrainForDistance(RemoteControlCar car) => DrivesForDistance(car) * car.BatteryDrain;

    public bool CarCanFinish(RemoteControlCar car) => BatteryDrainForDistance(car) <= RemoteControlCar.MaxBatteryCharge; 
}
