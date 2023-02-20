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

let yachtScore diceTotals =
    if List.distinct diceTotals |> List.length <> 1 then
        0
    else
        50

let numberCategoryScore category dice = dice |> List.filter((=) category) |> List.length |> (*) (int category)

let fullHouseScore diceTotals =
    let secondDice = List.last diceTotals
    if List.distinct diceTotals |> List.length <> 2 then
        0
    elif snd diceTotals.Head > 3 then
        0
    else
        fst diceTotals.Head * snd diceTotals.Head + fst secondDice * snd secondDice

let fourOfAKindScore diceTotals  =
    if List.distinct diceTotals |> List.length > 2 then
        0
    elif snd diceTotals.Head < 4 then
        0
    else
        fst diceTotals.Head * 4

let straightScore (diceTotals : (int * int) list) (minDiceNumber : int) (maxDiceNumber) =
    let diceTotalsOrderedByDie = diceTotals |> List.sortBy fst
    
    if (List.distinct diceTotals |> List.length) <> 5 then
        0
    elif diceTotalsOrderedByDie |> List.head |> fst <> minDiceNumber || diceTotalsOrderedByDie |> List.last |> fst <> maxDiceNumber then
        0
    else
        30
        
let choiceScore diceTotals = diceTotals |> List.map (fun (diceNumber, total) -> diceNumber * total) |>  List.sum

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
        | LittleStraight -> straightScore diceTotals 1 5
        | BigStraight -> straightScore diceTotals 2 6
        | Yacht -> yachtScore diceTotals
        | Choice -> choiceScore diceTotals