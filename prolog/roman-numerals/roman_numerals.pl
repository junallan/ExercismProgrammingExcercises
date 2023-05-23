convert(N, Numeral) :-
    roman_letter_value(N, Numeral).

roman_letter_value(1, "I").
