import functools

def largest_product(series: str, size: int) -> int:
    if len(series) == size:
        digits = [int(number) for number in series] 
        product = functools.reduce(lambda d1, d2: d1 * d2, digits)

        return product

    pass