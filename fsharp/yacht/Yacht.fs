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

let mappedNumberCategory category =
    match category with
    | Ones -> 1
    | Twos -> 2
    | Threes -> 3
    | Fours -> 4
    | Fives -> 5
    | Sixes -> 6
    | _ -> failwith "Not a category number"

let mappedCategoryNumberToDice category =
    match category with
    | Ones -> One
    | Twos -> Two
    | Threes -> Three
    | Fours -> Four
    | Fives -> Five
    | Sixes -> Six
    | _ -> failwith "Not a category number"

let numberCategoryScore category dice = dice |> List.filter((=) (mappedCategoryNumberToDice category)) |> (fun x -> List.length x * mappedNumberCategory category)

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

let fourOfAKindScore dice =
    let distinctDiceRoles = List.distinct dice

    if distinctDiceRoles.Length > 2 then
        0
    elif distinctDiceRoles.Length = 1 then
        mappedDice distinctDiceRoles.Head * 4
    else
        let firstDistinctElement = distinctDiceRoles.[0]
        let secondDistinctElement = distinctDiceRoles.[1]
        let firstElementCount = dice |> List.filter ((=) firstDistinctElement) |> List.length
        let secondElementCount = dice |> List.filter((=) secondDistinctElement) |> List.length 
        let fourOfAKindElement = if firstElementCount > secondElementCount then firstDistinctElement else secondDistinctElement

        if (firstElementCount = 4 && secondElementCount = 1) || (firstElementCount = 1 && secondElementCount = 4) then
            mappedDice fourOfAKindElement * 4
        else
            0

let score category dice =
    match (category, dice) with
    | _ when List.length dice <> 5 -> failwith "Incorrect number of dice roles"
    | _ when category = Ones || category = Twos || category = Threes || category = Fours || category = Fives || category = Sixes -> numberCategoryScore category dice
    | _ when category = FullHouse -> fullHouseScore dice
    | _ when category = FourOfAKind -> fourOfAKindScore dice
    | (_, dh::dt) when category = Yacht && dt |> List.forall ((=) dh) -> 50
    | _ -> 0