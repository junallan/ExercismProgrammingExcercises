using System;
using System.Linq;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        //identifier.Where(element => Char.IsLetter(element)).ToString()

        return String.Concat(identifier.Replace(' ', '_').Replace("\0","CTRL").Where(element => Char.IsLetter(element) || element == '_' || element == '\0'));
    }
}
