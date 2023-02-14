module ProteinTranslation

let matchFound = function   | "AUG" ->"Methionine"
                            | "UUU" | "UUC" -> "Phenylalanine"
                            | "UUA" | "UUG" -> "Leucine"
                            | "UCU" | "UCC" | "UCA" | "UCG" -> "Serine"
                            | "UAU" | "UAC" -> "Tyrosine"
                            | "UGU" | "UGC" -> "Cysteine"
                            | "UGG" -> "Tryptophan"
                            | _ -> ""

[<Literal>]
let LengthOfRNASequence = 3

let proteins (rna : string) = rna |> Seq.chunkBySize LengthOfRNASequence 
                                  |> Seq.map (fun element -> matchFound (new System.String(element)))
                                  |> Seq.takeWhile (fun element -> String.length element > 0)
                                  |> Seq.toList      
    