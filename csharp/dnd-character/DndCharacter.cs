using System;

public class DndCharacter
{
    public const int InitialHitPoint = 10;
    public const int MinScore = 3;
    public const int MaxScore = 18;
    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

    public DndCharacter()
    {
        Strength = Ability();
        Dexterity = Ability();
        Constitution = Ability();
        Intelligence = Ability();
        Wisdom = Ability();
        Charisma = Ability();
        Hitpoints = InitialHitPoint + Modifier(Constitution);
    }
    public static int Modifier(int score)
    {
      decimal converstedScore = score;
      decimal value = Decimal.Divide(converstedScore - InitialHitPoint,  2m);
      MidpointRounding roundType = value > 0 ? MidpointRounding.ToZero : MidpointRounding.AwayFromZero;
      
      return (int)decimal.Round(value, roundType);
    }

    public static int Ability() 
    {
        return new Random().Next(MinScore, MaxScore);
    }

    public static DndCharacter Generate()
    {
        DndCharacter character = new DndCharacter();
        

        return character;
    }
}
