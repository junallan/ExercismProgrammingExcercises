convert(N, Sounds) :- 
    pling_sound(N, PlingSound),
    plang_sound(N, PlangSound),
    plong_sound(N, PlongSound),
    atom_concat(PlingSound, PlangSound, PlingPlangSound),
    atom_concat(PlingPlangSound, PlongSound, PlingPlangPlongSound),
    (atom_length(PlingPlangPlongSound, 0) -> 
        number_codes(N, Codes),
        string_codes(Sounds, Codes)
        ;
        Sounds = PlingPlangPlongSound
    ).

pling_sound(N,Sound) :- 
    S is N mod 3,
    (S=:=0 ->
        Sound = "Pling"
    ;
        Sound = "").

plang_sound(N,Sound) :- 
    S is N mod 5,
    (S=:=0 ->
        Sound = "Plang"
    ;
        Sound = "").

plong_sound(N,Sound) :- 
    S is N mod 7,
    (S=:=0 ->
        Sound = "Plong"
    ;
        Sound = "").


