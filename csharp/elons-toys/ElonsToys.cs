using System;

class RemoteControlCar
{
    private int _batteryPercentage = 100;
    private int _metersDriven = 0;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_metersDriven} meters";
    }

    public string BatteryDisplay()
    {
        return $"Battery at {_batteryPercentage}%";
    }

    public void Drive()
    {
        _metersDriven += 20;
        _batteryPercentage -= 1;
    }
}
