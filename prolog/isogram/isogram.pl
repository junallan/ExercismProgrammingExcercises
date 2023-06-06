isogram(Word) :-
    string_chars(Word, CharactersInWord),
    maplist(downcase_atom, CharactersInWord, LowercaseCharactersInWord),
    isogram_chars(LowercaseCharactersInWord).

isogram_chars([]).
isogram_chars([' ']).
isogram_chars([-]).
isogram_chars([E|Ls]) :-
    \+ (char_type(E, alpha), member(E, Ls)),
    isogram_chars(Ls).