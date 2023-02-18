module CollatzConjecture

let steps (number: int): int option =
    let rec computeSteps number steps =
        match number with
        | _ when number <= 0 -> None
        | _ when number = 1 -> Some steps
        | n when n % 2 = 0 -> computeSteps (n / 2) (steps + 1)
        | _ -> computeSteps (3 * number + 1) (steps + 1)
    computeSteps number 0
