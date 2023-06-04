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
        atom_chars(PlingPlangPlongSound, SoundsAtom),
        string_chars(Sounds, SoundsAtom)
    ).

pling_sound(N,"Pling") :- S is N mod 3, S=:=0.
pling_sound(_, "").
plang_sound(N,"Plang") :- S is N mod 5, S=:=0.
plang_sound(_,"").
plong_sound(N,"Plong") :- S is N mod 7, S=:=0.
plong_sound(_,"").


