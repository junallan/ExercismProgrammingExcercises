module Hamming

let accumulateDifferencs firstStrand secondStrand =
    seq {
          for i in 0..List.length firstStrand - 1 do
            let elementOfFirstStrand = List.item i firstStrand
            let elementOfSecondStrand = List.item i secondStrand
            if (elementOfFirstStrand <> elementOfSecondStrand) then yield (elementOfFirstStrand, elementOfSecondStrand)
    }

let distance (strand1: string) (strand2: string): int option = 
  match strand1, strand2 with
  | s1, s2 when s1 = s2 -> Some 0
  | s1, s2 when String.length s1 <> String.length s2 -> None
  | s1, s2 when String.length s1 = String.length s2 -> let s1Elements = Seq.toList s1
                                                       let s2Elements = Seq.toList s2
                                                       Some (Seq.length (accumulateDifferencs s1Elements s2Elements))
  | _ -> None                                                   
