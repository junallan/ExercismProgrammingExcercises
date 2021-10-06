using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        int endOfMessageLevelIdentifier = logLine.IndexOf(":") + 2;

        return logLine.Substring(endOfMessageLevelIdentifier);
    }

    public static string LogLevel(string logLine)
    {
        throw new NotImplementedException("Please implement the (static) LogLine.LogLevel() method");
    }

    public static string Reformat(string logLine)
    {
        throw new NotImplementedException("Please implement the (static) LogLine.Reformat() method");
    }
}
