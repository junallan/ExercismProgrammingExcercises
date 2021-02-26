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

    private double DetermineAge(int orbitalPeriod) => Math.Round(_seconds / SecondsTranslation(orbitalPeriod), 2);
    private double PlanteOrbitalPeriodInEarthDays(double orbitalPertiod) => orbitalPertiod * EARTH_ORBITAL_PERIOD_DAYS;
    private double SecondsTranslation(double days) => days * HOURS_IN_DAY * MINUTES_IN_HOUR * SECONDS_IN_MINUTE;
    

    public double OnEarth() => DetermineAge(SecondsTranslation(EARTH_ORBITAL_PERIOD_DAYS));
    public double OnMercury() => Math.Round(_seconds / SecondsTranslation(0.2408467 * EARTH_ORBITAL_PERIOD_DAYS),2);
    public double OnVenus() => Math.Round(_seconds / SecondsTranslation(0.61519726 * EARTH_ORBITAL_PERIOD_DAYS), 2);

    public double OnMars()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double OnJupiter()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double OnSaturn()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double OnUranus()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double OnNeptune()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}