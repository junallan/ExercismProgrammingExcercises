using System;

public class SpaceAge
{
    private int _seconds;
    private const int HOURS_IN_DAY = 24;
    private const int MINUTES_IN_HOUR = 60;
    private const int SECONDS_IN_MINUTE = 60;
    private const double EARTH_ORBITAL_PERIOD_DAYS = 365.25;

    public SpaceAge(int seconds)
    {
        _seconds = seconds;
    }

    private struct OrbitalPeriodRelativeToEarthYears
    {
        public const double Earth = 1;
        public const double Mercury = 0.2408467;
        public const double Venus = 0.61519726;
        public const double Mars = 1.8808158;
        public const double Jupiter = 11.862615;
        public const double Saturn = 29.447498;
        public const double Uranus = 84.016846;
        public const double Neptune =164.79132;
    }

    private double DetermineAge(double orbitalPeriodDays) => Math.Round(_seconds / orbitalPeriodDays, 2);
    private double PlanteOrbitalPeriodInEarthDays(double orbitalPertiod) => orbitalPertiod * EARTH_ORBITAL_PERIOD_DAYS;
    private double SecondsTranslation(double days) => days * HOURS_IN_DAY * MINUTES_IN_HOUR * SECONDS_IN_MINUTE;
    
    public double OnEarth() => DetermineAge(SecondsTranslation(OrbitalPeriodRelativeToEarthYears.Earth * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnMercury() => DetermineAge(SecondsTranslation(OrbitalPeriodRelativeToEarthYears.Mercury * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnVenus() => DetermineAge(SecondsTranslation(OrbitalPeriodRelativeToEarthYears.Venus * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnMars() => DetermineAge(SecondsTranslation(OrbitalPeriodRelativeToEarthYears.Mars * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnJupiter() => DetermineAge(SecondsTranslation(OrbitalPeriodRelativeToEarthYears.Jupiter * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnSaturn() => DetermineAge(SecondsTranslation(OrbitalPeriodRelativeToEarthYears.Saturn * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnUranus() => DetermineAge(SecondsTranslation(OrbitalPeriodRelativeToEarthYears.Uranus * EARTH_ORBITAL_PERIOD_DAYS));
    public double OnNeptune() => DetermineAge(SecondsTranslation(OrbitalPeriodRelativeToEarthYears.Neptune * EARTH_ORBITAL_PERIOD_DAYS));
}