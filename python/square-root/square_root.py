def square_root(number: int) -> int:
    if number * number == number:
        return number
    
    number_guess = number // 2

    # Babylonian method to find square root
    while number_guess * number_guess != number:
        number_guess = (number_guess + (number // number_guess)) / 2

    return number_guess
