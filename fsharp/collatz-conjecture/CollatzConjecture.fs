module CollatzConjecture

let steps (number: int): int option =
    if number = 1 then
        Some 0
    else
        None
