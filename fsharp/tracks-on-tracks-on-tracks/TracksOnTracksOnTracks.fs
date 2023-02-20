module TracksOnTracksOnTracks

let newList: string list = []

let existingList: string list = ["F#"; "Clojure"; "Haskell"]

let addLanguage (language: string) (languages: string list): string list = language :: languages

let countLanguages (languages: string list): int = languages.Length

let reverseList(languages: string list): string list = List.rev languages

let excitingList (languages: string list): bool =
    match languages with
    | l when l.Length > 0 && l.Head = "F#" -> true
    | [_; "F#"; _] | [_; "F#";] -> true
    | _ -> false
