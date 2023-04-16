import functools

def largest_product(series: str, size: int) -> int:
    if size < 0:
        raise ValueError("span must not be negative")
    
    series_length = len(series)

    if series_length < size:
        raise ValueError("span must be smaller than string length")
    
    if series_length == 0 or size == 0:
        return 1

    if not series.isdigit():
        raise ValueError("digits input must only contain digits");
 
    start_index = 0
    end_index = size - 1
    largest_product = 0

    while end_index < series_length:
        digits = map(lambda number: int(number), series[start_index:end_index+1])
        product = functools.reduce(lambda d1, d2: d1 * d2, digits)

        if product > largest_product:
            largest_product = product
        
        start_index += 1
        end_index += 1

    return largest_product