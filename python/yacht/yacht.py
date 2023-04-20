from typing import Callable, List

# Score categories.
# Change the values as you see fit.
YACHT = lambda dice: 50 if all(d == dice[0] for d in dice) else 0
ONES = lambda dice: dice.count(1)
TWOS = lambda dice: dice.count(2) * 2
THREES = lambda dice: dice.count(3) * 3
FOURS = lambda dice: dice.count(4) * 4
FIVES = lambda dice: dice.count(5) * 5
SIXES = lambda dice: dice.count(6) * 6
def FULL_HOUSE(dice: list[int]) -> int: 
    distinct_dices = list(set(dice))

    if len(distinct_dices) != 2:
        return 0
    
    count_first_number = dice.count(distinct_dices[0])
    count_second_number = dice.count(distinct_dices[1])

    if ((count_first_number == 3 and count_second_number == 2) or
        (count_first_number == 2 and count_second_number == 3)):
        return sum(dice)
    else:
        return 0
def FOUR_OF_A_KIND(dice: list[int]) -> int:
    distinct_dices = list(set(dice))

    if len(distinct_dices) > 2:
        return 0
    if len(distinct_dices) == 1:
        return distinct_dices[0] * 4
    else:
        count_first_number = dice.count(distinct_dices[0])
        count_second_number = dice.count(distinct_dices[1])

        if count_first_number == 4:
            return distinct_dices[0] * count_first_number
        elif count_second_number == 4:
            return distinct_dices[1] * count_second_number
        else:
            return 0
LITTLE_STRAIGHT = lambda dice: straight(dice, 1, 5)
BIG_STRAIGHT = lambda dice: straight(dice, 2, 6)
CHOICE = lambda dice: sum(dice)

def score(dice: list, category:Callable[[List[int]], int]) -> int:
    return category(dice)

def straight(dice: list[int], min_number: int, max_number: int) -> int:
    distinct_dices = list(set(dice))

    if len(distinct_dices) != 5:
        return 0
    elif min(dice) == min_number and max(dice) == max_number:
        return 30
    else:
        return 0 