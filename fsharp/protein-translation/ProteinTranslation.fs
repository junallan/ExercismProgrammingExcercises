module ProteinTranslation

let proteins rna = match rna with
                   | "AUG" -> ["Methionine"]
                   | "UUU" -> ["Phenylalanine"]
                   | _ -> []