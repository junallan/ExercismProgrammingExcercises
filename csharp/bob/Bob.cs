using System;

public static class Bob
{
    private static bool IsAskingQuestion(string statement)          => statement.TrimEnd().EndsWith("?");
    private static bool IsShouting(string statement)                => statement == statement.ToUpper() && IsContainLetter(statement);
    private static bool IsContainLetter(string statement)           => statement.ToUpper() != statement.ToLower();

    public static string Response(string statement)
    {
        return statement switch
        {
           string val when val.Trim() == string.Empty               => "Fine. Be that way!",
           string val when IsAskingQuestion(val) && IsShouting(val) => "Calm down, I know what I'm doing!",
           string val when IsAskingQuestion(val)                    => "Sure.",
           string val when IsShouting(val)                          => "Whoa, chill out!",
           _                                                        => "Whatever."
        };
    }
}