convert(N, Numeral) :-
    roman_letter_value(N, Numeral).

roman_letter_value(0, '').

roman_letter_value(N, Result) :- 
    N > 0,
    N < 4,
    M is N - 1,
    roman_letter_value(M, Rest),
    string_concat("I", Rest, Result).

roman_letter_value(4, "IV").

roman_letter_value(N, Result) :-
    N > 4,
    N < 9,
    M is N - 5,
    roman_letter_value(M, Rest),
    string_concat("V", Rest, Result).

roman_letter_value(9, "IX").

roman_letter_value(N, Result) :-
    N > 9,
    N < 40,
    M is N - 10,
    roman_letter_value(M, Rest),
    string_concat("X", Rest, Result).

roman_letter_value(N, Result) :-
    N >= 40,
    N < 50,
    M is N - 40,
    roman_letter_value(M, Rest),
    string_concat("XL", Rest, Result).

roman_letter_value(N, Result) :-
    N > 50,
    N < 90,
    M is N - 50,
    roman_letter_value(M, Rest),
    string_concat("L", Rest, Result).

roman_letter_value(N, Result) :-
    N >= 90,
    N < 100,
    M is N - 90,
    roman_letter_value(M, Rest),
    string_concat("XC", Rest, Result).   

roman_letter_value(N, Result) :-
    N >= 100,
    N < 400,
    M is N - 100,
    roman_letter_value(M, Rest),
    string_concat("C", Rest, Result). 

roman_letter_value(N, Result) :-
    N >= 400,
    N < 500,
    M is N - 400,
    roman_letter_value(M, Rest),
    string_concat("CD", Rest, Result).    

roman_letter_value(N, Result) :-
    N >= 500,
    N < 900,
    M is N - 500,
    roman_letter_value(M, Rest),
    string_concat("D", Rest, Result).       

roman_letter_value(N, Result) :-
    N >= 900,
    N < 1000,
    M is N - 900,
    roman_letter_value(M, Rest),
    string_concat("CM", Rest, Result).        