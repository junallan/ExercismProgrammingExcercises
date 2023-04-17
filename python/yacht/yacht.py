# Score categories.
# Change the values as you see fit.
YACHT = None
ONES = None
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
            return 50
        else:
            return 0
         
    pass
