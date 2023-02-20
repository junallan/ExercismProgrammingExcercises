module BirdWatcher

let lastWeek: int[] = [| 0; 2; 5; 3; 7; 8; 4 |]

let yesterday(counts: int[]): int = counts.[counts.Length - 2]

let total(counts: int[]): int = Array.sum counts

let dayWithoutBirds(counts: int[]): bool = counts |> Array.exists((=) 0)

let incrementTodaysCount(counts: int[]): int[] =
    let reversedCounts = Array.rev counts
    let todaysCountIncremented = Array.head reversedCounts + 1
    [| todaysCountIncremented; yield! Array.tail reversedCounts |] |> Array.rev

let oddWeek(counts: int[]): bool =
  failwith "Please implement the 'oddWeek' function"
