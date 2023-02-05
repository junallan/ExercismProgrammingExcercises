module ValentinesDay

type Approval =
    | Yes
    | No
    | Maybe

type Cuisine =
    | Korean
    | Turkish

type Genre =
    | Crime
    | Horror
    | Romance
    | Thriller

type Activity =
    | BoardGame
    | Chill
    | Movie of Genre
    | Restaurant of Cuisine
    | Walk of int

let rateActivity (activity: Activity): Approval = 
    match activity with
    | BoardGame                       -> No
    | Chill                           -> No
    | Movie Genre.Romance             -> Yes
    | Movie _                         -> No
    | Restaurant Cuisine.Korean       -> Yes
    | Restaurant Cuisine.Turkish      -> Maybe
    | Walk activity when activity < 3 -> Yes
    | Walk activity when activity < 5 -> Maybe
    | _                               -> No 