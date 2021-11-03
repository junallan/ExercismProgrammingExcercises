using System;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        return identifier.Replace(' ', '_');
    }
}
