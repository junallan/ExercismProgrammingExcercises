module ProteinTranslation

let matchFound = function   | "AUG" -> ["Methionine"]
                            | "UUU" | "UUC" -> ["Phenylalanine"]
                            | "UUA" | "UUG" -> ["Leucine"]
                            | "UCU" | "UCC" | "UCA" | "UCG" -> ["Serine"]
                            | "UAU" | "UAC" -> ["Tyrosine"]
                            | "UGU" | "UGC" -> ["Cysteine"]
                            | "UGG" -> ["Tryptophan"]
                            | _ -> []

let rec proteins (rna : string) =
    if rna.Equals("") then
        []
    else        
        let startElement = rna.[..2]
        let endElements = rna.[3..]
        let proteinResult = matchFound startElement
        if List.isEmpty proteinResult then
            []
        else
            proteinResult @ proteins endElements

