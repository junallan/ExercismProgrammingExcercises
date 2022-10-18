using System;
using System.Collections.Generic;

public class WeatherStation
{
    private Reading _reading;
    private List<DateTime> _recordDates = new List<DateTime>();
    private List<decimal> _temperatures = new List<decimal>();

    public void AcceptReading(Reading reading)
    {
        _reading = reading;
        _recordDates.Add(DateTime.Now);
        _temperatures.Add(reading.Temperature);
    }

    public void ClearAll()
    {
        _reading = new Reading();
        _recordDates.Clear();
        _temperatures.Clear();
    }

    public decimal LatestTemperature => _reading.Temperature;
  
    public decimal LatestPressure => _reading.Pressure;

    public decimal LatestRainfall=> _reading.Rainfall;

    public bool HasHistory => _recordDates.Count > 1;

    public Outlook ShortTermOutlook 
    {
        get 
        {
            if (_reading.Equals(new Reading())) throw new ArgumentException();

            return _reading switch
            {  
                Reading r when r.Pressure < 10m && r.Temperature < 30m  => Outlook.Cool,
                Reading r when r.Temperature > 50m                      => Outlook.Good,
                _                                                       => Outlook.Warm
            };
        }
    }
        
              
    

    public Outlook LongTermOutlook =>
        _reading switch 
        {
            Reading r when r.WindDirection == WindDirection.Southerly 
                            || r.WindDirection == WindDirection.Easterly 
                            && r.Temperature > 20                           => Outlook.Good,
            Reading r when r.WindDirection == WindDirection.Northerly       => Outlook.Cool,
            Reading r when r.WindDirection == WindDirection.Easterly 
                            && r.Temperature <= 20                          => Outlook.Warm,
            Reading r when r.WindDirection == WindDirection.Westerly        => Outlook.Rainy,
            _                                                               => throw new ArgumentException()
        };

    public State RunSelfTest() => _reading.Equals(new Reading()) ? State.Bad :  State.Good;
}

/*** Please do not modify this struct ***/
public struct Reading
{
    public decimal Temperature { get; }
    public decimal Pressure { get; }
    public decimal Rainfall { get; }
    public WindDirection WindDirection { get; }

    public Reading(decimal temperature, decimal pressure,
        decimal rainfall, WindDirection windDirection)
    {
        Temperature = temperature;
        Pressure = pressure;
        Rainfall = rainfall;
        WindDirection = windDirection;
    }
}

/*** Please do not modify this enum ***/
public enum State
{
    Good,
    Bad
}

/*** Please do not modify this enum ***/
public enum Outlook
{
    Cool,
    Rainy,
    Warm,
    Good
}

/*** Please do not modify this enum ***/
public enum WindDirection
{
    Unknown, // default
    Northerly,
    Easterly,
    Southerly,
    Westerly
}
