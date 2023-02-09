module ProteinTranslation

let proteins rna = match rna with
                   | "AUG" -> ["Methionine"]
                   | "UUU" | "UUC" -> ["Phenylalanine"]
                   | "UUA" | "UUG" -> ["Leucine"]
                   | "UCU" | "UCC" | "UCA" | "UCG" -> ["Serine"]
                   | "UAU" | "UAC" -> ["Tyrosine"]
                   | "UGU" | "UGC" -> ["Cysteine"]
                   | _ -> []