module Hamming

let distance (strand1: string) (strand2: string): int option =
    let rec calculateDistance (strand1: char list) (strand2: char list) (distance: int): int option =
        match strand1, strand2 with
        | [], [] -> Some distance
        | fs, [] -> None
        | [], ss -> None
        | fsH::fsT, ssH::ssT when fsH <> ssH -> calculateDistance fsT ssT (distance+1)
        | _::fsT, _::ssT -> calculateDistance fsT ssT distance
    calculateDistance (Seq.toList strand1) (Seq.toList strand2) 0