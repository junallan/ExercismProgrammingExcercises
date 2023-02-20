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
    let secondDice = List.last dice
    if List.distinct dice |> List.length <> 2 then
        0
    elif snd dice.Head > 3 then
        0
    else
        fst dice.Head * snd dice.Head + fst secondDice * snd secondDice

let fourOfAKindScore dice  =
    if List.distinct dice |> List.length > 2 then
        0
    elif snd dice.Head < 4 then
        0
    else
        fst dice.Head * 4


let straightScore dice minDice maxDice =
    if List.length dice = List.length (List.distinct dice) && List.min dice = minDice && List.max dice = maxDice then
        30
    else 0

let choiceScore (dice) = dice |> List.map (fun d -> int d) |> List.sum

let score category dice =
    if List.length dice <> 5 then
       failwith "Incorrect number of dice roles"
    else
        let diceTotals = dice |> List.countBy int |> List.sortByDescending snd

        match category with
        | Ones -> numberCategoryScore Die.One dice
        | Twos -> numberCategoryScore Die.Two dice
        | Threes -> numberCategoryScore Die.Three dice
        | Fours -> numberCategoryScore Die.Four dice
        | Fives -> numberCategoryScore Die.Five dice
        | Sixes -> numberCategoryScore Die.Six dice
        | FullHouse -> fullHouseScore diceTotals
        | FourOfAKind -> fourOfAKindScore diceTotals
        | LittleStraight -> straightScore dice Die.One Die.Five
        | BigStraight -> straightScore dice Die.Two Die.Six
        | Yacht -> yachtScore dice
        | Choice -> choiceScore dice