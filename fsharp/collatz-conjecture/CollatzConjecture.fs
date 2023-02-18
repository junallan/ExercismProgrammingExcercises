module CollatzConjecture

let steps (number: int): int option =
    if number = 1 then
        Some 0
    else
        number |> Seq.unfold(fun number ->
            match number with
            | _ when number <= 1 -> None
            | n when n % 2 = 0 -> Some (n, n / 2)
            | _ -> Some (number, 3 * number + 1))
        |> fun calculatedSteps ->
            let numberOfSteps = Seq.length calculatedSteps
            if numberOfSteps = 0 then
                None 
            else
                Some numberOfSteps
                         
    //let rec computeSteps number steps =
    //    match number with
    //    | _ when number <= 0 -> None
    //    | _ when number = 1 -> Some steps
    //    | n when n % 2 = 0 -> computeSteps (n / 2) (steps + 1)
    //    | _ -> computeSteps (3 * number + 1) (steps + 1)
    //computeSteps number 0
