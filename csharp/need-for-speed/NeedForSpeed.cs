using System;

class RemoteControlCar
{
    private static int MaxBatteryCharge = 100;
    private int _batteryLevel = MaxBatteryCharge;
    private int _speed;
    private int _batteryDrain;
    private int _distance;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => _batteryLevel <= 0;

    public int DistanceDriven() => _distance;

    public void Drive()
    {
        if (BatteryDrained()) return;

        _batteryLevel -= _batteryDrain;
        _distance += _speed;
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(speed: 50, batteryDrain: 4);
}

class RaceTrack
{
    private int _distance;

    public RaceTrack(int distance) => _distance = distance;

    public bool CarCanFinish(RemoteControlCar car)
    { 
        do
        {
            car.Drive();     
        } while (!car.BatteryDrained());

        int maxDistanceCarCanDrive = car.DistanceDriven();

        return maxDistanceCarCanDrive >= _distance;
    }
}
