using System;

class RemoteControlCar
{
    private int _speed;
    private int _batteryDrain;
    private int _distance;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        throw new NotImplementedException("Please implement the RemoteControlCar.BatteryDrained() method");
    }

    public int DistanceDriven()
    {
        return _distance;
    }

    public void Drive()
    {
        _distance += _speed;
    }

    public static RemoteControlCar Nitro()
    {
        throw new NotImplementedException("Please implement the (static) RemoteControlCar.Nitro() method");
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
