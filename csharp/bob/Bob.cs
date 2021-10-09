using System;

public static class Bob
{
    private static bool IsStatementQuestion(string statement) => statement.EndsWith("?");

    public static string Response(string statement)
    {
        return statement switch
        {
           string val when IsStatementQuestion(val) => "Sure.",
           string val when val == val.ToUpper() => "Whoa, chill out!",
           _ => "Whatever."
        };
    }
}