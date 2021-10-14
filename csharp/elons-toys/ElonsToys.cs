using System;

class RemoteControlCar
{
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        throw new NotImplementedException("Please implement the RemoteControlCar.DistanceDisplay() method");
    }

    public string BatteryDisplay()
    {
        throw new NotImplementedException("Please implement the RemoteControlCar.BatteryDisplay() method");
    }

    public void Drive()
    {
        throw new NotImplementedException("Please implement the RemoteControlCar.Drive() method");
    }
}
