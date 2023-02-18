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
    | _ when category = Threes -> dice |> List.filter((=) Three) |> (fun threesDiceRole -> List.length threesDiceRole * 3)
    | _ when category = Fours -> dice |> List.filter((=) Four) |> (fun foursDiceRole -> List.length foursDiceRole * 4)
    | _ when category = Fives -> dice |> List.filter((=) Five) |> (fun fivesDiceRole -> List.length fivesDiceRole * 5)
    | _ when category = Sixes -> dice |> List.filter((=) Six) |> (fun sixesDiceRole -> List.length sixesDiceRole * 6)     
    | (_, dh::dt) when category = Yacht && dt |> List.forall ((=) dh) -> 50
    | _ -> 0