module Hamming

let accumulateDifferencs strandCombination =
    (0, strandCombination) ||> Seq.fold (fun acc (a, b) ->
        match (a, b) with
        | a, b when a <> b -> acc + 1
        | _ -> acc)

let distance (strand1: string) (strand2: string): int option = 
  match strand1, strand2 with
  | s1, s2 when String.length s1 = String.length s2 -> Some (accumulateDifferencs (Seq.zip s1 s2))
  | _ -> None                                                   
