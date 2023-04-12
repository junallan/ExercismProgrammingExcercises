def steps(number: int) -> int:
    if number < 1:
        raise ValueError("Only positive integers are allowed")
    
    number_of_steps = 0
    current_number = number

    while current_number != 1:
        if current_number % 2 == 1:
            current_number = 3 * current_number + 1
            
        else:
            current_number = current_number / 2
        number_of_steps+=1
    
    return number_of_steps


