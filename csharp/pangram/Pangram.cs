using System;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
       var alphabet = "abcdefghijklmnopqrstuvwxyz";

       return alphabet == new string(input.ToLower().Where(c => alphabet.Contains(c)).OrderBy(x => x).Distinct().ToArray());
    }
}
