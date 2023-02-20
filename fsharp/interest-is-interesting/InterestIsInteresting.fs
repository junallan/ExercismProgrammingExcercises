module InterestIsInteresting

let interestRate (balance: decimal): single =
    match balance with
    | _ when balance < 0m -> 3.213f
    | _ when balance < 1000m -> 0.5f
    | _ when balance < 5000m -> 0f
    | _ -> 2.475f

let interest (balance: decimal): decimal =
   failwith "Please implement the 'interest' function"

let annualBalanceUpdate(balance: decimal): decimal =
   failwith "Please implement the 'annualBalanceUpdate' function"

let amountToDonate(balance: decimal) (taxFreePercentage: float): int =
   failwith "Please implement the 'amountToDonate' function"
