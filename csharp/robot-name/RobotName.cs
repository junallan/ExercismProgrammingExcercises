using System;
using System.Collections.Generic;

public class Robot
{
    private string _name;

    public static List<string> RobotNames = new List<string>();

    public Robot()
    {
        Reset();
    }

    public string Name => _name;

    public void Reset()
    {
        string generatedName;

        do
        {
            generatedName = GenerateName();
        } while (RobotNames.Contains(generatedName));


        _name = generatedName;
        RobotNames.Add(_name);
    }

    private string GenerateName()
    {
        Random random = new Random();
        string alphabetLetters = "ABCDEFGHIJKLMNOPQRSTUVWZYZ";
        
        string prefixName = $"{alphabetLetters[random.Next(alphabetLetters.Length)]}{alphabetLetters[random.Next(alphabetLetters.Length)]}";

        string suffixNumber = random.Next(100, 999).ToString();

        return $"{prefixName}{suffixNumber}";
    }
}