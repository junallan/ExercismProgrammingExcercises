module TisburyTreasureHunt

let getCoordinate (line: string * string): string = snd line

let convertCoordinate (coordinate: string): int * char =
    string coordinate.[0] |> int, coordinate.[1]

let compareRecords (azarasData: string * string) (ruisData: string * (int * char) * string) : bool = 
    let (_, coordinatesAzara) = azarasData
    let (_, coordinatesRui, _) = ruisData
    convertCoordinate coordinatesAzara = coordinatesRui

let createRecord (azarasData: string * string) (ruisData: string * (int * char) * string) : (string * string * string * string) =
    if compareRecords azarasData ruisData then
        let (treasure, coordinate) = azarasData
        let (location, _, quadrant) = ruisData
        (coordinate, location, quadrant, treasure)
    else
        ("","","","")
     
