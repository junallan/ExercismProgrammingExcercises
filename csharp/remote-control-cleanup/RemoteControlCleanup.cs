public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }
    internal TelemetryControl Telemetry => new TelemetryControl(this);

    private Speed currentSpeed;
   
    public class TelemetryControl
    {
        RemoteControlCar _remoteControlCar;

        public TelemetryControl(RemoteControlCar remoteControlCar)
        {
            _remoteControlCar = remoteControlCar;
        }

        public void Calibrate()
        {

        }

        public bool SelfTest() => true;
        

        public void ShowSponsor(string sponsorName)
        {
            _remoteControlCar.SetSponsor(sponsorName);
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = unitsString == "cps" ? SpeedUnits.CentimetersPerSecond : SpeedUnits.MetersPerSecond;

            _remoteControlCar.SetSpeed(new Speed(amount, speedUnits));
        }

    }
   
    public string GetSpeed()
    {
        return currentSpeed.ToString();
    }

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;

    }

    private void SetSpeed(Speed speed)
    {
        currentSpeed = speed;
    }

    protected struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }
}

public enum SpeedUnits
{
    MetersPerSecond,
    CentimetersPerSecond
}




