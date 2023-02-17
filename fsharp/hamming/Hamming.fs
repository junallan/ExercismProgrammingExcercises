module Hamming

let accumulateDifferencs firstStrand secondStrand =
    (0, firstStrand, secondStrand) |||> Seq.fold2 (fun acc a b ->
        match (a, b) with
        | a, b when a <> b -> acc + 1
        | _ -> acc)

let distance (strand1: string) (strand2: string): int option = 
  match strand1, strand2 with
  | s1, s2 when s1 = s2 -> Some 0
  | s1, s2 when String.length s1 <> String.length s2 -> None
  | s1, s2 when String.length s1 = String.length s2 -> let s1Elements = Seq.toList s1
                                                       let s2Elements = Seq.toList s2
                                                       Some (accumulateDifferencs s1Elements s2Elements)
  | _ -> None                                                   
