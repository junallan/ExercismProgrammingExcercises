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
    | _ when category = Ones -> dice |> List.filter((=) One) |> List.length 
    | _ when category = Twos -> dice |> List.filter((=) Two) |> (fun twosDiceRole -> List.length twosDiceRole * 2) 
    | (_, dh::dt) when category = Yacht && dt |> List.forall ((=) dh) -> 50
    | _ -> 0