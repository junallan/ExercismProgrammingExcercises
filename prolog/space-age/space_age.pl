space_age(Planet, AgeSec, Years):-
    planet_seconds_per_earth_year(Planet, SecondsFactor),
    Years is AgeSec / SecondsFactor.

planet_seconds_per_earth_year("Earth", 31557600).
planet_seconds_per_earth_year("Mercury", 7600543.82).

    