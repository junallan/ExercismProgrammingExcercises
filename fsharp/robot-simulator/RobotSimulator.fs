module RobotSimulator

type Direction = North | East | South | West
type Position = int * int

let create direction position = (direction, position)

let move instructions robot = failwith "You need to implement this function."
