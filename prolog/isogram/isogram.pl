isogram("").
isogram(Word) :-
    string_chars(Word, CharactersInWord),
    maplist(downcase_atom, CharactersInWord, LowercaseCharactersInWord),
    unique(LowercaseCharactersInWord).
unique([_]).
unique([]).
unique([A|Ls]) :- \+ member(A, Ls), isogram(Ls).
