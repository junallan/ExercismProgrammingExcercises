module TisburyTreasureHunt

let getCoordinate (line: string * string): string = snd line

let convertCoordinate (coordinate: string): int * char =
    let coordinateParsed = Seq.toList coordinate
    let coordinatesLastIndex = List.length coordinateParsed - 1
    let letterCoordinate = coordinateParsed.[coordinatesLastIndex]
    let numberCoordinate = List.take coordinatesLastIndex coordinateParsed
    (int (string numberCoordinate.[0]),letterCoordinate)

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
     
