using System;

class RemoteControlCar
{
    private int _speed;
    private int _batteryLevel = 100;
    private int _batteryDrain;
    private int _distance;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => _batteryLevel <= 0;

    public int DistanceDriven()
    {
        return _distance;
    }

    public void Drive()
    {
        if (BatteryDrained()) return;

        _batteryLevel -= _batteryDrain;
        _distance += _speed;
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(speed: 5, batteryDrain: 4);
    }
}

class RaceTrack
{
    private int _distance;

    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool CarCanFinish(RemoteControlCar car)
    {
        throw new NotImplementedException("Please implement the RaceTrack.CarCanFinish() method");
    }
}
