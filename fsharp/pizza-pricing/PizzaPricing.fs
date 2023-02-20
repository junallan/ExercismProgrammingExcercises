module PizzaPricing

type Pizza =
    | Margherita
    | Caprese
    | Formaggio
    | ExtraSauce of Pizza
    | ExtraToppings of Pizza

let rec pizzaPrice (pizza: Pizza): int =
        match pizza with
        | Margherita -> 7
        | Caprese -> 9
        | Formaggio -> 10
        | ExtraSauce p -> 1 + pizzaPrice p
        | ExtraToppings p -> 2 + pizzaPrice p

let orderPrice(pizzas: Pizza list): int =
    if pizzas.Length = 0 then
        0
    elif pizzas.Length = 1 then
        3 + pizzaPrice pizzas.Head
    elif pizzas.Length = 2 then
        2 + pizzaPrice pizzas.Head + pizzaPrice pizzas.[1]
    else 
        List.map (fun pizza -> pizzaPrice pizza) pizzas |> List.sum
