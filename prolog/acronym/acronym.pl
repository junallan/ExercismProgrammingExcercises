abbreviate(Sentence, Acronym) :-
    split_string(Sentence, " .,;:-_!?()[]{}", "", Words),
    maplist(string_chars, Words, CharsList),
    convlist(nth0(0), CharsList, FirstChars),
    atomics_to_string(FirstChars,'',CharsAsAString),
    string_upper(CharsAsAString, Acronym).