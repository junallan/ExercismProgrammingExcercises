space_age(Planet, AgeSec, Years) :-
    planet_years(Planet, AgeSec, Years).

planet_years("Earth", AgeSec, Years) :-
    Years is AgeSec / 31557600.
    