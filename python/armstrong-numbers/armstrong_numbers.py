def is_armstrong_number(number):
    numberFormatted = str(number)
    length = len(numberFormatted)
    
    accumulated_total = 0

    for digit in numberFormatted:
        accumulated_total += int(digit) ** length

    return number == accumulated_total
