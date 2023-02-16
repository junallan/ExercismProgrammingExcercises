module Hamming

let distance (strand1: string) (strand2: string): int option = 
  match strand1, strand2 with
  | s1, s2 when String.length s1 = 0 && String.length s2 = 0 -> Some 0
  | _ -> failwith "You need to implement this function."