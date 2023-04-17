def square_root(number: int) -> int:
    if number ** 2 == number:
        return number
    
    number_guess = number // 2

    # Babylonian method to find square root
    while pow(number_guess, 2) != number:
        number_guess = (number_guess + (number // number_guess)) / 2

    return number_guess
