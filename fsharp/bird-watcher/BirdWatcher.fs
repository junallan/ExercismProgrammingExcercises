module BirdWatcher

let lastWeek: int[] = [| 0; 2; 5; 3; 7; 8; 4 |]

let yesterday(counts: int[]): int = counts.[counts.Length - 2]

let total(counts: int[]): int = Array.sum counts

let dayWithoutBirds(counts: int[]): bool = counts |> Array.exists((=) 0)

let incrementTodaysCount(counts: int[]): int[] =
 failwith "Please implement the 'incrementTodaysCount' function"

let oddWeek(counts: int[]): bool =
  failwith "Please implement the 'oddWeek' function"
