module CarsAssemble

[<Literal>]
let CarsProductedPerHour = 221
[<Literal>]
let MinutesInHour = 60

let successRate = function
| 0 -> 0.0
| s when s < 5 -> 1.0
| s when s < 9 -> 0.9 
| 9 -> 0.8
| 10 -> 0.77
| _ -> failwith "Invalid speed, needs to be between 0 and 10" 

let productionRatePerHour (speed: int): float =
    float speed * float CarsProductedPerHour * successRate speed

let workingItemsPerMinute (speed: int): int =
    int (productionRatePerHour speed) / MinutesInHour

