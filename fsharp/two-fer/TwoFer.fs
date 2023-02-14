module TwoFer

let twoFer (input: string option): string =
  match input with
  | Some(input)  -> "One for " + input + ", one for me." 
  | _            -> "One for you, one for me."                      