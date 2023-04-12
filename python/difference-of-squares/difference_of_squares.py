def square_of_sum(number: int) -> int:
    sum = 0

    for i in range(number):
        sum += i + 1
    
    return sum ** 2


def sum_of_squares(number: int) -> int:
    sum = 0

    for i in range(number):
        sum += (i+1) ** 2

    return sum


def difference_of_squares(number: int) -> int:
    return square_of_sum(number) - sum_of_squares(number)
