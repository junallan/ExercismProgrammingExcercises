TOTAL_SQUARES_ON_BOARD = 64

def square(number):
    if number < 1 or TOTAL_SQUARES_ON_BOARD < number:
        raise ValueError("square must be between 1 and 64")
    
    if number == 1:
        return 1
    else:
        return 2 * square(number-1)


def total():
    total = 0

    for i in range(TOTAL_SQUARES_ON_BOARD):
        total += square(i+1)
    
    return total
