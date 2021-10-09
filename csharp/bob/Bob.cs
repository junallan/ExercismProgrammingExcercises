using System;

public static class Bob
{
    public static string Response(string statement)
    {
        if (statement == statement.ToUpper()) return "Whoa, chill out!";
        return "Whatever.";
    }
}