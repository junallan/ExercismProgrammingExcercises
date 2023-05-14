isogram("").
isogram(Word) :-
    string_chars(Word, CharactersInWord),
    unique(CharactersInWord).
unique([_]).
unique([]).
unique([A|Ls]) :- \+ member(A, Ls), isogram(Ls).
