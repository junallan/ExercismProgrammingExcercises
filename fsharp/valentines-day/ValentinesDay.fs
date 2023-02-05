module ValentinesDay

type Approval =
    | Yes
    | No
    | Maybe

type Cuisine =
    | Korean
    | Turkish

// TODO: please define the 'Genre' discriminated union type
type Genre =
    | Crime
    | Horror
    | Romance
    | Thriller

// TODO: please define the 'Activity' discriminated union type

let rateActivity (activity: Activity): Approval = failwith "Please implement the 'rateActivity' function"
