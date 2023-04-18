def square_root(number: int) -> int:
    number_squared = number * number

    if number_squared == number:
        return number
    
    number_guess = number // 2

    # Babylonian method to find square root
    while number_squared != number:
        number_guess = (number_guess + (number // number_guess)) / 2

    return number_guess
