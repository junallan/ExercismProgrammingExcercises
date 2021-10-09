using System;

public static class Bob
{
    private static bool IsAskingQuestion(string statement) => statement.EndsWith("?");
    private static bool IsShouting(string statement) => statement == statement.ToUpper();

    public static string Response(string statement)
    {
        return statement switch
        {
           string val when IsAskingQuestion(val) && IsShouting(val) => "Calm down, I know what I'm doing!",
           string val when IsAskingQuestion(val) => "Sure.",
           string val when IsShouting(val) => "Whoa, chill out!",
           _ => "Whatever."
        };
    }
}