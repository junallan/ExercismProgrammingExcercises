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
    | One = 1
    | Two = 2
    | Three = 3
    | Four = 4 
    | Five = 5
    | Six = 6

let yachtScore dice =
    let firstDice = List.head dice
    let isYachtScore = List.tail dice |> List.forall ((=) firstDice);

    if isYachtScore then 50 else 0

let numberCategoryScore category dice = dice |> List.filter((=) category) |> List.length |> (*) (int category)

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
           int firstDistinctElement * firstElementCount + int secondDistinctElement * secondElementCount
        else
            0        

let fourOfAKindScore dice =
    let distinctDiceRoles = List.distinct dice

    if distinctDiceRoles.Length > 2 then
        0
    elif distinctDiceRoles.Length = 1 then
        int distinctDiceRoles.Head * 4
    else
        let firstDistinctElement = distinctDiceRoles.[0]
        let secondDistinctElement = distinctDiceRoles.[1]
        let firstElementCount = dice |> List.filter ((=) firstDistinctElement) |> List.length
        let secondElementCount = dice |> List.filter((=) secondDistinctElement) |> List.length 

        if (firstElementCount = 4 && secondElementCount = 1) || (firstElementCount = 1 && secondElementCount = 4) then
            let fourOfAKindElement = if firstElementCount > secondElementCount then firstDistinctElement else secondDistinctElement

            int fourOfAKindElement * 4
        else
            0

let straightScore dice minDice maxDice =
    if List.length dice = List.length (List.distinct dice) && List.min dice = minDice && List.max dice = maxDice then
        30
    else 0

let choiceScore (dice) = dice |> List.map (fun d -> int d) |> List.sum

let score category dice =
    if List.length dice <> 5 then
       failwith "Incorrect number of dice roles"
    else
        match category with
        | Ones -> numberCategoryScore Die.One dice
        | Twos -> numberCategoryScore Die.Two dice
        | Threes -> numberCategoryScore Die.Three dice
        | Fours -> numberCategoryScore Die.Four dice
        | Fives -> numberCategoryScore Die.Five dice
        | Sixes -> numberCategoryScore Die.Six dice
        | FullHouse -> fullHouseScore dice
        | FourOfAKind -> fourOfAKindScore dice
        | LittleStraight -> straightScore dice Die.One Die.Five
        | BigStraight -> straightScore dice Die.Two Die.Six
        | Yacht -> yachtScore dice
        | Choice -> choiceScore dice