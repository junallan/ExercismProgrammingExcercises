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
        var diceNumberVariations = dice.Distinct();

        if (diceNumberVariations.Count() != 2) return 0;

        var firstDistictNumberScore = diceNumberVariations.First();
        var secondDistinctNumberScore = diceNumberVariations.Last();
        var firstDistinctNumberScoreCount = dice.Count(diceNumber => diceNumber == firstDistictNumberScore);
        var secondDistinctNumberScoreCount = dice.Count(diceNumber => diceNumber == secondDistinctNumberScore);

        if ((firstDistinctNumberScoreCount == 2 && secondDistinctNumberScoreCount == 3) || (firstDistinctNumberScoreCount == 3 && secondDistinctNumberScoreCount == 5))
            return firstDistictNumberScore * firstDistinctNumberScoreCount + secondDistinctNumberScore * secondDistinctNumberScoreCount;
        else
            return 0;
    }

    private static int FourOfAKindScore(int[] dice)
    {
        var diceNumberVariations = dice.Distinct();

        if (diceNumberVariations.Count() > 2) return 0;

        if (diceNumberVariations.Count() == 1) return diceNumberVariations.Single() * 4;

        var firstDistictNumberScore = diceNumberVariations.First();
        var secondDistinctNumberScore = diceNumberVariations.Last();

        var firstDistinctNumberScoreCount = dice.Count(diceNumber => diceNumber == firstDistictNumberScore);
        var secondDistinctNumberScoreCount = dice.Count(diceNumber => diceNumber == secondDistinctNumberScore);

        var scoreToTotal = firstDistinctNumberScoreCount > secondDistinctNumberScoreCount ? firstDistictNumberScore : secondDistinctNumberScore;

        if ((firstDistinctNumberScoreCount == 1 && secondDistinctNumberScoreCount == 4) || (firstDistinctNumberScoreCount == 4 && secondDistinctNumberScoreCount == 1))
            return scoreToTotal * 4;
        else
            return 0;
    }

    private static int StraightScore(int[] dice, int minDiceNumber, int maxDiceNumber)
    {
        var isAllDistinctNumbers = dice.Count() == dice.Distinct().Count();
        if (isAllDistinctNumbers && dice.Min() == minDiceNumber && dice.Max() == maxDiceNumber)
            return 30;
        else
            return 0;
    }

    private static int ChoiceScore(int[] dice)
    {
        return dice.Sum();
    }
}

