module ProteinTranslation

let matchFound = function   | "AUG" ->"Methionine"
                            | "UUU" | "UUC" -> "Phenylalanine"
                            | "UUA" | "UUG" -> "Leucine"
                            | "UCU" | "UCC" | "UCA" | "UCG" -> "Serine"
                            | "UAU" | "UAC" -> "Tyrosine"
                            | "UGU" | "UGC" -> "Cysteine"
                            | "UGG" -> "Tryptophan"
                            | _ -> ""



let proteins (rna : string) = 
    let rnaChunks = rna |> Seq.chunkBySize 3 |> Seq.map(fun element -> new System.String(element)) 
    let result = Seq.takeWhile (fun element -> 
                        String.length (matchFound element) > 0
                         ) rnaChunks
    result |> Seq.map(fun result -> matchFound result) |> Seq.toList
    