abbreviate(Sentence, Acronym) :-
    split_string(Sentence, " .,;:-_!?()[]{}", "", Words),
    maplist(string_chars, Words, CharsList),
    convlist([X,Y]>>(X=[C|_], Y=C), CharsList, FirstChars),
    atomics_to_string(FirstChars,'',CharsAsAString),
    string_upper(CharsAsAString, Acronym).