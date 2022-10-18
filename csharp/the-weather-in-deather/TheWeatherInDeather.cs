using System;
using System.Collections.Generic;

public class WeatherStation
{
    private Reading _reading;
    private List<DateTime> _recordDates = new List<DateTime>();
    private List<decimal> temperatures = new List<decimal>();

    public void AcceptReading(Reading reading)
    {
        _reading = reading;
        _recordDates.Add(DateTime.Now);
        temperatures.Add(reading.Temperature);
    }

    public void ClearAll()
    {
        _reading = new Reading();
        _recordDates.Clear();
        temperatures.Clear();
    }

    public decimal LatestTemperature => _reading.Temperature;
  
    public decimal LatestPressure => _reading.Pressure;

    public decimal LatestRainfall=> _reading.Rainfall;

    public bool HasHistory => _recordDates.Count > 1;

    public Outlook ShortTermOutlook =>
        _reading switch
        {  
            { 
                Pressure: decimal pressure, 
                Temperature: decimal temperature, 
                Rainfall: decimal rainfall, 
                WindDirection: WindDirection windDirection
            } 
            when pressure == default(decimal) 
                    && temperature == default(decimal)
                    && rainfall == default(decimal)
                    && windDirection == WindDirection.Unknown   
            => throw new ArgumentException(),
            { 
                Pressure: var pressure, 
                Temperature: var temperature 
            } 
            when pressure < 10m && temperature < 30m           
            => Outlook.Cool,
            { 
                Temperature: var temperature 
            } 
            when temperature > 50m                              
            => Outlook.Good,
            _                                                   
            => Outlook.Warm
        };
              
    

    public Outlook LongTermOutlook =>
        _reading switch {
            { 
                WindDirection: WindDirection windDirection, 
                Temperature: decimal temperature 
            } 
            when windDirection == WindDirection.Southerly 
                    || windDirection == WindDirection.Easterly
                    && temperature > 20
            => Outlook.Good,
            { 
                WindDirection: WindDirection windDirection 
            }
            when windDirection == WindDirection.Northerly
            => Outlook.Cool,
            { 
                WindDirection: WindDirection windDirection, 
                Temperature: decimal temperature 
            }
            when windDirection == WindDirection.Easterly 
                    && _reading.Temperature <= 20
            => Outlook.Warm,
            { 
                WindDirection: WindDirection windDirection 
            }
            when windDirection == WindDirection.Westerly
            => Outlook.Rainy,
            _ 
            => throw new ArgumentException()
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
