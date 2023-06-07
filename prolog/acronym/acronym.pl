abbreviate(Sentence, Acronym) :-
    split_string(Sentence, " .,;:-_!?()[]{}", "", Words),
    maplist(string_chars, Words, CharsList),
    convlist([X,Y]>>(X=[C|_], string_upper(C, Y)), CharsList, FirstChars),
    atomics_to_string(FirstChars,'',Acronym).