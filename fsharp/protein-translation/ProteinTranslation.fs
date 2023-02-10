module ProteinTranslation

let matchFound rna = match rna with | "AUG" -> ["Methionine"]
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
        let protienResult = matchFound startElement
        if List.isEmpty protienResult then
            []
        else
            protienResult @ proteins endElements

