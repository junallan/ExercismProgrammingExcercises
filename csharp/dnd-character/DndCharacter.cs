using System;
using System.Collections.Generic;
using System.Linq;

public class DndCharacter
{
    public const int InitialHitPoint = 10;
    public const int MinScore = 1;
    public const int MaxScore = 6;
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
        var diceRole1 = new Random().Next(MinScore, MaxScore+1);
        var diceRole2 = new Random().Next(MinScore, MaxScore+1);
        var diceRole3 = new Random().Next(MinScore, MaxScore+1);
        var diceRole4 = new Random().Next(MinScore, MaxScore+1);
        
        var diceRoles = new []{ diceRole1, diceRole2, diceRole3, diceRole4 };
       
        return diceRoles.OrderByDescending(x => x).Take(diceRoles.Count()-1).Sum(x => x); 
    }

    public static DndCharacter Generate() =>new DndCharacter();
}
