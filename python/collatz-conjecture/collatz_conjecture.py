def steps(number: int) -> int:
    if number < 1:
        raise ValueError("Only positive integers are allowed")
    
    steps = 0
   
    while number != 1:
        if number % 2 == 1:
            number = 3 * number + 1           
        else:
            number //=  2

        steps += 1
    
    return steps


