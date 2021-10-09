using System;

public static class Bob
{
    public static string Response(string statement)
    {
        return statement switch
        {
           string val when val.EndsWith("?") => "Sure.",
           string val when val == val.ToUpper() => "Whoa, chill out!",
           _ => "Whatever."
        };
    }
}