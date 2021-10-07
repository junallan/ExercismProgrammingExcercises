using System;

public class Player
{
    private readonly Random _randomNumberGenerator = new Random();
    private const int DieSides = 18;

    public int RollDie() => _randomNumberGenerator.Next(DieSides) + 1;

    public double GenerateSpellStrength()
    {
        throw new NotImplementedException("Please implement the Player.GenerateSpellStrength() method");
    }
}
