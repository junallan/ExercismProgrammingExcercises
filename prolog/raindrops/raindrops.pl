convert(N, Sounds) :- 
    pling_sound(N, PlingSound),
    plang_sound(N, PlangSound),
    plong_sound(N, PlongSound),
    string_concat(PlingSound, PlangSound, PlingPlangSound),
    string_concat(PlingPlangSound, PlongSound, PlingPlangPlongSound),
    (string_length(PlingPlangPlongSound, 0) -> 
        number_codes(N, Codes),
        string_codes(Sounds, Codes)
        ;
        string_chars(Sounds, PlingPlangPlongSound)
    ).

pling_sound(N,"Pling") :- S is N mod 3, S=:=0.
pling_sound(_, "").
plang_sound(N,"Plang") :- S is N mod 5, S=:=0.
plang_sound(_,"").
plong_sound(N,"Plong") :- S is N mod 7, S=:=0.
plong_sound(_,"").


