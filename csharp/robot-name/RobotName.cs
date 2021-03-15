using System;
using System.Collections.Generic;

public class Robot
{    
    private const string AlphabetLetters = "ABCDEFGHIJKLMNOPQRSTUVWZYZ";

    private int _maxNames = AlphabetLetters.Length * AlphabetLetters.Length * 1_000 * 1_000;
    private string _name;
    private Random _random = new Random();

    public static HashSet<string> RobotNames = new HashSet<string>();

    public Robot()
    {
        Reset();
    }

    public string Name => _name;

    public void Reset()
    {
        if (RobotNames.Count == _maxNames)
        {
            throw new Exception("All potential Robot names have been utilized.  Cannot create anymore.");
        }

        string generatedName;

        do
        {
            generatedName = GenerateName();
        } while (RobotNames.Contains(generatedName));


        _name = generatedName;
        RobotNames.Add(_name);
    }

    private char GetRandomLetter()
    {
        return AlphabetLetters[_random.Next(AlphabetLetters.Length)];
    }

    private string GenerateName()
    {        
        string prefixName = $"{GetRandomLetter()}{GetRandomLetter()}";

        var suffixNumber = _random.Next(0, 1000).ToString("D3");

        return $"{prefixName}{suffixNumber}";
    }
}