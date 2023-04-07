TOTAL_SQUARES_ON_BOARD = 64

def square(number):
    if number < 1 or TOTAL_SQUARES_ON_BOARD < number:
        raise ValueError("square must be between 1 and 64")
    
    return 1 << (number-1)

    #Exponent method
    #return 2 ** (number-1)

    #Recursive method
    # if number == 1:
    #     return 1
    # else:
    #     return 2 * square(number-1)


def total():
    return (1 << TOTAL_SQUARES_ON_BOARD) - 1 

    #Exponent method
    #return 2 ** TOTAL_SQUARES_ON_BOARD - 1

    #Looping method
    #number_of_grains = 0

    # for number in range(1, TOTAL_SQUARES_ON_BOARD+1):
    #     number_of_grains += square(number)
    
    #return number_of_grains
