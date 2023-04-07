grain_count = 0;

def square(number):
    if number < 1 or 64 < number:
        raise ValueError("square must be between 1 and 64")
    
    if number == 1:
        return 1
    else:
        return 2 * square(number-1)


def total():
    pass
