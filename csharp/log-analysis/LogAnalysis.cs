using System;

public static class LogAnalysis 
{

    private static int IndexAfterDelimeter(this string message, string delimeter) => message.IndexOf(delimeter) + delimeter.Length;
    public static string SubstringAfter(this string message, string delimeter) => message.Substring(message.IndexAfterDelimeter(delimeter));
   
    public static string SubstringBetween(this string message, string beginningDelimeter, string endingDelimeter)
    {
        int indexAfterStartDelimeter = message.IndexAfterDelimeter(beginningDelimeter);
        int messageContentLength = message.IndexOf(endingDelimeter) - indexAfterStartDelimeter;

        return message.Substring(indexAfterStartDelimeter, messageContentLength);
    }

    public static string Message(this string message) => SubstringAfter(message, ": ");

    // TODO: define the 'LogLevel()' extension method on the `string` type
}