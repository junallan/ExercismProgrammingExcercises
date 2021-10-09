using System;

public static class LogAnalysis 
{

    private static int IndexAfterDelimeter(this string message, string delimeter) => message.IndexOf(delimeter) + delimeter.Length;
    public static string SubstringAfter(this string message, string delimeter) => message.Substring(message.IndexAfterDelimeter(delimeter));
    // TODO: define the 'SubstringBetween()' extension method on the `string` type

    // TODO: define the 'Message()' extension method on the `string` type

    // TODO: define the 'LogLevel()' extension method on the `string` type
}