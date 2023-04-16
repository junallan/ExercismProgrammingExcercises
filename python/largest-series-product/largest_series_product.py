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
 
    largest_product = 0

    for digits in sliding_window(series, size):
        product = functools.reduce(lambda d1, d2: d1 * d2, map(int, digits))

        if product > largest_product:
            largest_product = product

    return largest_product

def sliding_window(seq: str, size: int) -> list[str]:
    for start_index in range(len(seq) - size + 1):
        yield seq[start_index: start_index + size] 