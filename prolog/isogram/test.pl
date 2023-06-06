dog(fido). dog(rover). dog(jane). dog(tom). dog(fred). dog(henry).
cat(bill). cat(steve). cat(mary). cat(harry).
large(rover). large(william). large(martin).
large(tom). large(steve).
large(jim). large(mike).
large_animal(X):-large(X),dog(X).
large_animal(Z):-large(Z),cat(Z).