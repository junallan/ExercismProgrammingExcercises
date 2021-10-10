using System;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string message, string delimeter) => message.Split(delimeter)[1];
    public static string SubstringBetween(this string message, string beginningDelimeter, string endingDelimeter) => message.Split(endingDelimeter)[0].Substring(1);
    public static string Message(this string message) => message.SubstringAfter(": ");
    public static string LogLevel(this string message) => message.SubstringBetween("[", "]");
}