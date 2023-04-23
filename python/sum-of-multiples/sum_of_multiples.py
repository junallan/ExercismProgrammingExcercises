def sum_of_multiples(limit: int, multiples: list[int]) -> int:
    if not multiples: return 0

    multiples_tracked = set()

    for num in multiples:
        if num != 0:
            multiples_tracked.update(range(num, limit, num))

    return sum(multiples_tracked)

