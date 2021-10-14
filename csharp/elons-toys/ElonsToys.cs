using System;

class RemoteControlCar
{
    private int _batteryPercentage = 100;
    private int _metersDriven = 0;

    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {_metersDriven} meters";

    public string BatteryDisplay() => _batteryPercentage == 0 ? "Battery empty" : $"Battery at {_batteryPercentage}%";

    public void Drive()
    {
        if(_batteryPercentage != 0)
        {
            _batteryPercentage -= 1;
            _metersDriven += 20;
        }     
    }
}
