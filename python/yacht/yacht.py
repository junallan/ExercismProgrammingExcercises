from typing import Callable, List

# Score categories.
YACHT = lambda dice: 50 if all(d == dice[0] for d in dice) else 0
ONES = lambda dice: count(dice, 1)
TWOS = lambda dice: count(dice, 2)
THREES = lambda dice: count(dice, 3)
FOURS = lambda dice: count(dice, 4)
FIVES = lambda dice: count(dice, 5)
SIXES = lambda dice: count(dice, 6)
FULL_HOUSE = (lambda dice: sum(dice) 
    if len(distinct_numbers := set(dice)) == 2 
        and dice.count(distinct_numbers.pop()) in [2,3] 
    else 0)

def FOUR_OF_A_KIND(dice: list[int]) -> int:
    number_that_repeats_most = max(dice, key = lambda d: dice.count(d))
    count_of_most_repeated_number = dice.count(number_that_repeats_most)
 
    return (number_that_repeats_most * 4 
        if count_of_most_repeated_number >= 4 else 0)
LITTLE_STRAIGHT = lambda dice: straight(dice, 1, 5)
BIG_STRAIGHT = lambda dice: straight(dice, 2, 6)
CHOICE = sum

def score(dice: list, category:Callable[[List[int]], int]) -> int:
    return category(dice)

def count(dice: list, number: int) -> int:
    return dice.count(number) * number

def straight(dice: list[int], min_number: int, max_number: int) -> int:
    distinct_dices = list(set(dice))

    if len(distinct_dices) != 5:
        return 0
    elif min(dice) == min_number and max(dice) == max_number:
        return 30
    else:
        return 0 