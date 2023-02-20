module TracksOnTracksOnTracks

let newList: string list = []

let existingList: string list = ["F#"; "Clojure"; "Haskell"]

let addLanguage (language: string) (languages: string list): string list = language :: languages

let countLanguages (languages: string list): int = languages.Length

let reverseList(languages: string list): string list = failwith "Please implement the 'reverseList' function"

let excitingList (languages: string list): bool = failwith "Please implement the 'excitingList' function"
