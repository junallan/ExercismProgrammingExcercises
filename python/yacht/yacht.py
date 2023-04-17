# Score categories.
# Change the values as you see fit.
YACHT = 50
ONES = 1
TWOS = None
THREES = None
FOURS = None
FIVES = None
SIXES = None
FULL_HOUSE = None
FOUR_OF_A_KIND = None
LITTLE_STRAIGHT = None
BIG_STRAIGHT = None
CHOICE = None


def score(dice, category):
    if category == YACHT:
        if all(d == dice[0] for d in dice):
            return YACHT
        else:
            return 0
    elif category == ONES:
        return dice.count(1)     
    pass
