space_age(Planet, AgeSec, Years):-
    earth_seconds(EarthSec),
    orbital_period(Planet, OrbitalPeriod),
    Years is AgeSec / (EarthSec * OrbitalPeriod).

earth_seconds(31557600).

orbital_period("Earth", 1).
orbital_period("Mercury", 0.2408467).
orbital_period("Venus", 0.61519726).
orbital_period("Mars", 1.8808158).
orbital_period("Jupiter", 11.862615).
orbital_period("Saturn", 29.447498).
orbital_period("Uranus", 84.016846).



    