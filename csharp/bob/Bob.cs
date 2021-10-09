using System;

public static class Bob
{
    public static string Response(string statement)
    {
        if (statement.EndsWith("?")) return "Sure.";
        else if (statement == statement.ToUpper()) return "Whoa, chill out!";
        else return "Whatever.";
    }
}