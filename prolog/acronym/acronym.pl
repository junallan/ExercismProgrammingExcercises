abbreviate(Sentence, Acronym) :-
    split_string(Sentence, " .,;:-_!?()[]{}", "", Words),
    maplist(string_chars, Words, CharsList),
    exclude(empty, CharsList, CharsListExcludingEmpty),
    maplist(nth0(0), CharsListExcludingEmpty, FirstChars),
    atomics_to_string(FirstChars,'',CharsAsAString),
    string_upper(CharsAsAString, Acronym).

empty(List) :- List = [].

    
