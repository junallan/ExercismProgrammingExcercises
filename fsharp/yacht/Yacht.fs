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

let score category dice =
    match (category, dice) with
    | _ when List.length dice <> 5 -> failwith "Incorrect number of dice roles"
    | (c, dh::dt) when c = Yacht && dt |> List.forall ((=) dh) -> 50
    | _ -> 0