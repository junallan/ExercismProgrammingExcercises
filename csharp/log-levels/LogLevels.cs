using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        int endOfMessageLevelIdentifier = logLine.IndexOf(":") + 1;

        return logLine.Substring(endOfMessageLevelIdentifier).Trim();
    }

    public static string LogLevel(string logLine)
    {
        int beginningMarkerForLogLevelIdentifier = logLine.IndexOf("[") + 1;
        int endingMarkerForLogLevelIdentifier = logLine.IndexOf("]");

        return logLine.Substring(beginningMarkerForLogLevelIdentifier, 
                                 endingMarkerForLogLevelIdentifier - beginningMarkerForLogLevelIdentifier)
                      .ToLower();
    }

    public static string Reformat(string logLine) => $"{Message(logLine)} ({LogLevel(logLine)})";
}
