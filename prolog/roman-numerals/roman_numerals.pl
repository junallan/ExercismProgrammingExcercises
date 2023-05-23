convert(N, Numeral) :-
    roman_letter_value(N, Numeral).

roman_letter_value(0, '').

roman_letter_value(N, Result) :- 
    N > 0,
    N < 4,
    M is N - 1,
    roman_letter_value(M, Rest),
    string_concat("I", Rest, Result).