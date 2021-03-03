using System;
using System.Collections.Generic;

public class SpaceAge
{
    private int _seconds;
    private Dictionary<Planets, double> _orbitalPeriodsRelativeToEarthYears;
    private const int HOURS_IN_DAY = 24;
    private const int MINUTES_IN_HOUR = 60;
    private const int SECONDS_IN_MINUTE = 60;
    private const double EARTH_ORBITAL_PERIOD_DAYS = 365.25;

    public SpaceAge(int seconds)
    {
        _seconds = seconds;
        _orbitalPeriodsRelativeToEarthYears = new Dictionary<Planets, double>{ {Planets.Earth, 1}, {Planets.Mercury, 0.2408467}, {Planets.Venus, 0.61519726}, {Planets.Mars, 1.8808158}, {Planets.Jupiter, 11.862615}, {Planets.Saturn, 29.447498}, {Planets.Uranus, 84.016846}, {Planets.Neptue, 164.79132}};
    }

    private enum Planets
    {
        Earth,
        Mercury,
        Venus,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptue
    }

    private double DetermineAge(double orbitalPeriodDays) => Math.Round(_seconds / orbitalPeriodDays, 2);
    private double PlanteOrbitalPeriodInEarthDays(double orbitalPertiod) => orbitalPertiod * EARTH_ORBITAL_PERIOD_DAYS;
    private double SecondsTranslation(double days) => days * HOURS_IN_DAY * MINUTES_IN_HOUR * SECONDS_IN_MINUTE;
    
    public double OnEarth() => DetermineAge(SecondsTranslation(_orbitalPeriodsRelativeToEarthYears[Planets.Earth] * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnMercury() => DetermineAge(SecondsTranslation(_orbitalPeriodsRelativeToEarthYears[Planets.Mercury] * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnVenus() => DetermineAge(SecondsTranslation(_orbitalPeriodsRelativeToEarthYears[Planets.Venus] * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnMars() => DetermineAge(SecondsTranslation(_orbitalPeriodsRelativeToEarthYears[Planets.Mars] * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnJupiter() => DetermineAge(SecondsTranslation(_orbitalPeriodsRelativeToEarthYears[Planets.Jupiter] * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnSaturn() => DetermineAge(SecondsTranslation(_orbitalPeriodsRelativeToEarthYears[Planets.Saturn] * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnUranus() => DetermineAge(SecondsTranslation(_orbitalPeriodsRelativeToEarthYears[Planets.Uranus] * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnNeptune() => DetermineAge(SecondsTranslation(_orbitalPeriodsRelativeToEarthYears[Planets.Neptue] * EARTH_ORBITAL_PERIOD_DAYS));
}