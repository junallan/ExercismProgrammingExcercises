module ProteinTranslation

let matchFound = function   | "AUG" ->"Methionine"
                            | "UUU" | "UUC" -> "Phenylalanine"
                            | "UUA" | "UUG" -> "Leucine"
                            | "UCU" | "UCC" | "UCA" | "UCG" -> "Serine"
                            | "UAU" | "UAC" -> "Tyrosine"
                            | "UGU" | "UGC" -> "Cysteine"
                            | "UGG" -> "Tryptophan"
                            | _ -> ""

let proteins (rna : string) = rna |> Seq.chunkBySize 3 
                                  |> Seq.map (fun element -> matchFound (new System.String(element)))
                                  |> Seq.takeWhile (fun element -> String.length element > 0)
                                  |> Seq.toList      
    