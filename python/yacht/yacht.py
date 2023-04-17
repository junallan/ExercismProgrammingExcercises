# Score categories.
# Change the values as you see fit.
YACHT = 50
ONES = 1
TWOS = 2
THREES = 3
FOURS = 4
FIVES = 5
SIXES = 6
FULL_HOUSE = 7
FOUR_OF_A_KIND = 8
LITTLE_STRAIGHT = 30
BIG_STRAIGHT = 10
CHOICE = 11


def score(dice, category):
    if category == YACHT:
        if all(d == dice[0] for d in dice):
            return YACHT
        else:
            return 0
    elif ONES <= category <= SIXES:
        return dice.count(category) * category     
    elif category == FULL_HOUSE:
        distinct_dices = list(set(dice))

        if len(distinct_dices) != 2:
            return 0
        else:
            count_first_number = dice.count(distinct_dices[0])
            count_second_number = dice.count(distinct_dices[1])

            if ((count_first_number == 3 and count_second_number == 2) or
                (count_first_number == 2 and count_second_number == 3)):
                return sum(dice)
            else:
                return 0
    elif category == FOUR_OF_A_KIND:
        distinct_dices = list(set(dice))

        if len(distinct_dices) > 2:
            return 0
        if len(distinct_dices) == 1:
            return distinct_dices[0] * 5
        else:
            count_first_number = dice.count(distinct_dices[0])
            count_second_number = dice.count(distinct_dices[1])

            if count_first_number == 4:
                return distinct_dices[0] * count_first_number
            elif count_second_number == 4:
                return distinct_dices[1] * count_second_number
            else:
                return 0
    elif category == LITTLE_STRAIGHT:
        distinct_dices = list(set(dice))

        if len(distinct_dices) != 5:
            return 0
        elif max(dice) == 5:
            return LITTLE_STRAIGHT
        else:
            return 0
    pass
