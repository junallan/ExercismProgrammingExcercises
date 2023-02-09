using System;

public class DndCharacter
{
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
        Hitpoints = 10 + Modifier(Constitution);
    }
    public static int Modifier(int score)
    {
      decimal converstedScore = score;
      decimal value = Decimal.Divide(converstedScore - 10m,  2m);
      MidpointRounding roundType = value > 0 ? MidpointRounding.ToZero : MidpointRounding.AwayFromZero;
      
      return (int)decimal.Round(value, roundType);
    }

    public static int Ability() 
    {
        return new Random().Next(3,19);
    }

    public static DndCharacter Generate()
    {
        DndCharacter character = new DndCharacter();
        

        return character;
    }
}
