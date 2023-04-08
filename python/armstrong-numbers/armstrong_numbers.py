def is_armstrong_number(number):
    number_as_string = str(number)
    length = len(number_as_string)
    
    accumulated_total = 0

    for digit in number_as_string:
        accumulated_total += int(digit) ** length

    return number == accumulated_total
