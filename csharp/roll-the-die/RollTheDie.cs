using System;

public class Player
{
    private static readonly Random _randomNumberGenerator = new Random();
    private const int DieSides = 18;
    private const int SpellMaxStrength = 100;

    public int RollDie() => _randomNumberGenerator.Next(DieSides) + 1;

    public double GenerateSpellStrength() => _randomNumberGenerator.NextDouble() * SpellMaxStrength;
}
