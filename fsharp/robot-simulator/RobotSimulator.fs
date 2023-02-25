module RobotSimulator

type Direction = North | East | South | West
type Position = int * int

let create direction position = (direction, position)

let move instructions (robot:Direction*(int*int))  = 
    match instructions, robot with
    | ("R", (Direction.North,p)) -> (Direction.East, p)
    | ("R", (Direction.East,p)) -> (Direction.South, p)
    | ("R", (Direction.South,p)) -> (Direction.West, p)
    | ("R", (Direction.West,p)) -> (Direction.North, p)
    | ("L", (Direction.North,p)) -> (Direction.West, p)
    | ("L", (Direction.East,p)) -> (Direction.North, p)
    | ("L", (Direction.South,p)) -> (Direction.East, p)
    | ("L", (Direction.West,p)) -> (Direction.South, p)
    | ("A", (Direction.North,(x,y))) -> (Direction.North, (x, y+1))
    | ("A", (Direction.South,(x,y))) -> (Direction.South, (x, y-1))
    | ("A", (Direction.East,(x,y))) -> (Direction.East, (x+1, y))
    | ("A", (Direction.West,(x,y))) -> (Direction.West, (x-1, y))
    | _ -> robot

