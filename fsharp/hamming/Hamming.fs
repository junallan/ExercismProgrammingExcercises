module Hamming

let accumulateDifferencs strandCombination =
    strandCombination |> Seq.sumBy (fun (a,b) -> if a <> b then 1 else 0)

let distance (strand1: string) (strand2: string): int option =
   if strand1.Length = strand2.Length then
     Some (Seq.zip strand1 strand2 |> accumulateDifferencs)
   else
     None                                                   