def sum_of_multiples(limit: int, multiples: list[int]) -> int:
    return sum({num for factor in multiples 
                if factor != 0 
                for num in range(factor, limit, factor)})

    # return sum({num for num in range(limit) 
    #     for factor in multiples 
    #     if factor != 0 and num % factor == 0})

    #if not multiples: return 0

    # multiples_tracked = set()

    # for num in multiples:
    #     if num != 0:
    #         multiples_tracked.update(range(num, limit, num))

    #return sum(multiples_tracked)  