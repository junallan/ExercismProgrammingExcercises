using System;

class RemoteControlCar
{
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return "Driven 0 meters";
    }

    public string BatteryDisplay()
    {
        return "Battery at 100%";
    }

    public void Drive()
    {
        throw new NotImplementedException("Please implement the RemoteControlCar.Drive() method");
    }
}
