def is_armstrong_number(number):
    number_as_string = str(number)
    
    length = len(number_as_string)
    
    return number == sum(
       int(digit) ** length
       for digit in number_as_string 
    )
