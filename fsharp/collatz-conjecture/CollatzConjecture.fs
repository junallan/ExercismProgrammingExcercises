module CollatzConjecture

let steps (number: int): int option =
    let rec computeSteps number steps =
        if number <= 0 then
            None
        elif number = 1 then
            Some steps
        elif (number % 2 = 0) then
            computeSteps (number / 2) (steps + 1)
        else
            computeSteps (3 * number + 1) (steps + 1)
    computeSteps number 0
