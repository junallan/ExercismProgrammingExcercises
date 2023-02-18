module Yacht

type Category = 
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | FullHouse
    | FourOfAKind
    | LittleStraight
    | BigStraight
    | Choice
    | Yacht

type Die =
    | One 
    | Two 
    | Three
    | Four 
    | Five 
    | Six

let mappedDice dice =
    match dice with
    | One -> 1
    | Two -> 2
    | Three -> 3
    | Four -> 4
    | Five -> 5
    | Six -> 6

let fullHouseScore dice =
    let distinctDiceRoles = List.distinct dice
    if distinctDiceRoles.Length <> 2 then
        0
    else
        let firstDistinctElement = distinctDiceRoles.[0]
        let secondDistinctElement = distinctDiceRoles.[1]
        let firstElementCount = dice |> List.filter ((=) firstDistinctElement) |> List.length
        let secondElementCount = dice |> List.filter((=) secondDistinctElement) |> List.length 
        if (firstElementCount = 2 && secondElementCount = 3) || (firstElementCount = 2 && secondElementCount = 3) then
            mappedDice firstDistinctElement * firstElementCount + mappedDice secondDistinctElement * secondElementCount
        else
            0
        


let score category dice =
    match (category, dice) with
    | _ when List.length dice <> 5 -> failwith "Incorrect number of dice roles"
    | _ when category = Ones -> dice |> List.filter((=) One) |> List.length 
    | _ when category = Twos -> dice |> List.filter((=) Two) |> (fun twosDiceRole -> List.length twosDiceRole * mappedDice Two)
    | _ when category = Threes -> dice |> List.filter((=) Three) |> (fun threesDiceRole -> List.length threesDiceRole * mappedDice Three)
    | _ when category = Fours -> dice |> List.filter((=) Four) |> (fun foursDiceRole -> List.length foursDiceRole * mappedDice Four)
    | _ when category = Fives -> dice |> List.filter((=) Five) |> (fun fivesDiceRole -> List.length fivesDiceRole * mappedDice Five)
    | _ when category = Sixes -> dice |> List.filter((=) Six) |> (fun sixesDiceRole -> List.length sixesDiceRole * mappedDice Six)
    | _ when category = FullHouse -> fullHouseScore dice
    | (_, dh::dt) when category = Yacht && dt |> List.forall ((=) dh) -> 50
    | _ -> 0