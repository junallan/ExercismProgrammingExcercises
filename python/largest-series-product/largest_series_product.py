from functools import reduce
from operator import mul

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
 
    return  max(([reduce(mul, map(int, digits)) 
                  for digits in sliding_window(series, size)]))


def sliding_window(seq: str, size: int) -> list[str]:
    for start_index in range(len(seq) - size + 1):
        yield seq[start_index: start_index + size] 