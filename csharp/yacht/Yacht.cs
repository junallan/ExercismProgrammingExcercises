using System;
using System.Linq;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{ 
    public static int Score(int[] dice, YachtCategory category)
    {
        var result = category switch
        {
            YachtCategory.Yacht => YachtScore(dice),
            YachtCategory.Ones or YachtCategory.Twos or YachtCategory.Threes or YachtCategory.Fours or YachtCategory.Fives or YachtCategory.Sixes  => NumberScore(dice, category),
            _ => 0
        };

        return result;
    }

    private static int YachtScore(int[] dice)=> dice.Distinct().Count() == 1 ? 50 : 0;

    private static int NumberScore(int[] dice, YachtCategory category) => dice.Where(diceNumber => diceNumber == (int)category).Sum();
}

