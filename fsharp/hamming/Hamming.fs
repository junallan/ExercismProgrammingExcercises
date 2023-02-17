module Hamming

let accumulateDifferencs strandCombination =
    strandCombination |> Seq.sumBy (fun (a,b) -> match a, b with
                                                 | a, b when a <> b -> 1
                                                 | _ -> 0)

let distance (strand1: string) (strand2: string): int option = 
  match strand1, strand2 with
  | s1, s2 when String.length s1 = String.length s2 -> Some (accumulateDifferencs (Seq.zip s1 s2))
  | _ -> None                                                   
