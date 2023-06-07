child(anna,bridget).
child(bridget,caroline).
child(caroline,donna).
dhild(donna,emily).

descend(X,Y):-child(X,Y).
descend(X,Y):-descend(Z,Y),child(X,Z).

