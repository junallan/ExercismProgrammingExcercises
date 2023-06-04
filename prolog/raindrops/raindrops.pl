convert(N, Sounds) :-
    integer(N),
    pling_sound(N, PlingSound),
    plang_sound(N, PlangSound),
    plong_sound(N, PlongSound),
    foldl(concat_sound, [PlingSound, PlangSound, PlongSound], "", PlingPlangPlongSound),
    (PlingPlangPlongSound = "" ->
        number_codes(N, Codes),
        string_codes(Sounds, Codes)
    ;
        Sounds = PlingPlangPlongSound
    ),!.

concat_sound(Sound, Acc, Result) :- string_concat(Acc, Sound, Result).

pling_sound(N, "Pling") :- S is N mod 3, S =:= 0.
pling_sound(_, "").

plang_sound(N, "Plang") :- S is N mod 5, S =:= 0.
plang_sound(_, "").

plong_sound(N, "Plong") :- S is N mod 7, S =:= 0.
plong_sound(_, "").