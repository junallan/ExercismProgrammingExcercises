def sum_of_multiples(limit: int, multiples: list[int]) -> int:
    if multiples and limit < multiples[0]: return 0

    multiples_less_than_or_equal_limit = [base for base in multiples if base <= limit]

    multiples_tracked = set()

    for base in multiples_less_than_or_equal_limit:
        counter = 1
        multiple = base * counter
        
        while limit >= multiple:
            multiples_tracked.add(multiple)
            counter += 1
            multiple = base * counter

    return sum(multiples_tracked)

