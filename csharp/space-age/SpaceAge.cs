using System;
using System.Collections.Generic;

public class SpaceAge
{
    private int _seconds;
    private static Dictionary<Planets, double> _orbitalPeriodsRelativeToEarthYears= new Dictionary<Planets, double>{ 
                                                        {Planets.Earth, 1}, 
                                                        {Planets.Mercury, 0.2408467}, 
                                                        {Planets.Venus, 0.61519726}, 
                                                        {Planets.Mars, 1.8808158}, 
                                                        {Planets.Jupiter, 11.862615}, 
                                                        {Planets.Saturn, 29.447498}, 
                                                        {Planets.Uranus, 84.016846}, 
                                                        {Planets.Neptue, 164.79132}};
    private const double EarthOrbitalPeriod = 31_557_660d;

    public SpaceAge(int seconds)
    {
        _seconds = seconds;
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
    
    public double OnEarth() => DetermineAge(EarthOrbitalPeriod);
    public double OnMercury() => DetermineAge(EarthOrbitalPeriod * _orbitalPeriodsRelativeToEarthYears[Planets.Mercury]);
    public double OnVenus() => DetermineAge(EarthOrbitalPeriod * _orbitalPeriodsRelativeToEarthYears[Planets.Venus]);
    public double OnMars() => DetermineAge(EarthOrbitalPeriod * _orbitalPeriodsRelativeToEarthYears[Planets.Mars]);
    public double OnJupiter() => DetermineAge(EarthOrbitalPeriod * _orbitalPeriodsRelativeToEarthYears[Planets.Jupiter]);
    public double OnSaturn() => DetermineAge(EarthOrbitalPeriod * _orbitalPeriodsRelativeToEarthYears[Planets.Saturn]);
    public double OnUranus() => DetermineAge(EarthOrbitalPeriod * _orbitalPeriodsRelativeToEarthYears[Planets.Uranus]);
    public double OnNeptune() => DetermineAge(EarthOrbitalPeriod * _orbitalPeriodsRelativeToEarthYears[Planets.Neptue]);
}