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
            YachtCategory.Ones or YachtCategory.Twos or YachtCategory.Threes or YachtCategory.Fours or YachtCategory.Fives or YachtCategory.Sixes => NumberScore(dice, category),
            YachtCategory.FullHouse => FullHouseScore(dice),
            YachtCategory.FourOfAKind => FourOfAKindScore(dice),
            YachtCategory.LittleStraight => StraightScore(dice, (int)YachtCategory.Ones, (int)YachtCategory.Fives),
            YachtCategory.BigStraight => StraightScore(dice, (int)YachtCategory.Twos, (int)YachtCategory.Sixes),
            YachtCategory.Choice => ChoiceScore(dice),
            _ => 0
        }; ;

        return result;
    }

    private static int YachtScore(int[] dice) => dice.Distinct().Count() == 1 ? 50 : 0;

    private static int NumberScore(int[] dice, YachtCategory category) => dice.Where(diceNumber => diceNumber == (int)category).Sum();

    private static int FullHouseScore(int[] dice)
    {
        var diceNumberVariations = dice.GroupBy(d => d);

        if (diceNumberVariations.Count() != 2) return 0;

        var firstDistinctNumberScoreCount = dice.Count(diceNumber => diceNumber == diceNumberVariations.First().Key);
        var secondDistinctNumberScoreCount = dice.Count(diceNumber => diceNumber == diceNumberVariations.Last().Key);

        return ((firstDistinctNumberScoreCount == 2 && secondDistinctNumberScoreCount == 3) || (firstDistinctNumberScoreCount == 3 && secondDistinctNumberScoreCount == 5))
                    ? diceNumberVariations.Select(dv => dv.Count() * dv.Key).Sum() : 0;
    }

    private static int FourOfAKindScore(int[] dice) => dice.GroupBy(d => d).Where(d => d.Count() > 3).Sum(d => d.Key * 4);

    private static int StraightScore(int[] dice, int minDiceNumber, int maxDiceNumber) =>
        (dice.Count() == dice.Distinct().Count() && dice.Min() == minDiceNumber && dice.Max() == maxDiceNumber) ? 30 : 0;

    private static int ChoiceScore(int[] dice) => dice.Sum();
}

